using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Caliburn.Micro;
using SpaceEngineersCalculator.Desktop.Caliburn;
using SpaceEngineersCalculator.Desktop.Extensions;
using SpaceEngineersCalculator.Desktop.Interfaces;
using SpaceEngineersCalculator.Desktop.Model;
using SpaceEngineersCalculator.Desktop.ViewModels.Dialogs;

namespace SpaceEngineersCalculator.Desktop.ViewModels.Sections
{
	public class NewShipViewModel : ScreenValidationBase, IMainTabsControl
	{
		public NewShipViewModel(ShipSize size)
		{
			ShipSize = size;
		}

		public int Order { get; } = 0;

		protected override void OnInitialize()
		{
			base.OnInitialize();

			DesiredMass = 200000;
			Gravity = 9.81f;
			Efficiency = 0.9f;

			EnergySources.CollectionChanged += EnergySourcesChanged;
			Thrusters.CollectionChanged += ThrustersChanged;

			var view = CollectionViewSource.GetDefaultView(EnergySources);
			view.SortDescriptions.Add(new SortDescription(nameof(EnergySource.DisplayName), ListSortDirection.Ascending));

			view = CollectionViewSource.GetDefaultView(Thrusters);
			view.SortDescriptions.Add(new SortDescription(nameof(Thruster.DisplayName), ListSortDirection.Ascending));
		}

		private void ThrustersChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.NewItems != null)
			{
				foreach (Thruster item in e.NewItems)
				{
					item.PropertyChanged += CalculationPropertyChanged;
				}
			}

			if (e.OldItems != null)
			{
				foreach (Thruster item in e.OldItems)
				{
					item.PropertyChanged -= CalculationPropertyChanged;
				}
			}
			RecalculateValues();
		}

		private void EnergySourcesChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.NewItems != null)
			{
				foreach (EnergySource item in e.NewItems)
				{
					item.PropertyChanged += CalculationPropertyChanged;
				}
			}

			if (e.OldItems != null)
			{
				foreach (EnergySource item in e.OldItems)
				{
					item.PropertyChanged -= CalculationPropertyChanged;
				}
			}
			RecalculateValues();
		}

		private void CalculationPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
		{
			RecalculateValues();
		}

		private void RecalculateValues()
		{
			AvailableThrust = Thrusters.Sum(s => s.Thrust);
			AvailableEnergyOutput = EnergySources.Sum(s => s.PowerOutput);
			TotalPowerConsumption = Thrusters.Sum(s => s.PowerConsumption);

			// http://www.spaceengineerswiki.com/Thruster
			//  Lift [kg] = engine force [N] * effectivity [unitless] / acceleration due to gravity [m/s²]
			AvailableLiftForce = (int)((AvailableThrust*1000*Efficiency) / Gravity);
			var liftPowerFactor = ((float)AvailableEnergyOutput/ (float)TotalPowerConsumption).Clamp(0,1);
			AvailableLiftWithMaxPower = ((int)(AvailableLiftForce*liftPowerFactor)).Clamp(0, int.MaxValue);

			HasInsufficientPower = AvailableThrust > 0 && AvailableLiftWithMaxPower < AvailableLiftForce;
			
			EnergySourcesSummary = string.Join(Environment.NewLine, EnergySources.GroupBy(d => d.DisplayName).Select(group => group.Key + " " + group.Count()));
			ThrustersSummary = string.Join(Environment.NewLine, Thrusters.GroupBy(d => d.DisplayName).Select(group => group.Key + " " + group.Count()));
		}

		private int _availableLiftWithMaxPower;

		public int AvailableLiftWithMaxPower
		{
			get { return _availableLiftWithMaxPower; }
			set { SetValue(ref _availableLiftWithMaxPower, value, nameof(AvailableLiftWithMaxPower)); }
		}

		private string _thrustersSummary;

		public string ThrustersSummary
		{
			get { return _thrustersSummary; }
			set { SetValue(ref _thrustersSummary, value, nameof(ThrustersSummary)); }
		}

		private string _energySourcesSummary;

		public string EnergySourcesSummary
		{
			get { return _energySourcesSummary; }
			set { SetValue(ref _energySourcesSummary, value, nameof(EnergySourcesSummary)); }
		}

		private int _totalPowerConsumption;

		/// <summary>
		/// kW
		/// </summary>
		public int TotalPowerConsumption
		{
			get { return _totalPowerConsumption; }
			set { SetValue(ref _totalPowerConsumption, value, nameof(TotalPowerConsumption)); }
		}

		private int _availableThrust;

		/// <summary>
		/// kN
		/// </summary>
		public int AvailableThrust
		{
			get { return _availableThrust; }
			set { SetValue(ref _availableThrust, value, nameof(AvailableThrust)); }
		}

		private int _availableLiftForce;
		/// <summary>
		/// kg
		/// </summary>
		public int AvailableLiftForce
		{
			get { return _availableLiftForce; }
			set { SetValue(ref _availableLiftForce, value, nameof(AvailableLiftForce)); }
		}

		private int _availableEnergyOutput;

		/// <summary>
		/// kW
		/// </summary>
		public int AvailableEnergyOutput
		{
			get { return _availableEnergyOutput; }
			set { SetValue(ref _availableEnergyOutput, value, nameof(AvailableEnergyOutput)); }
		}

		private bool _hasInsufficientPower;

		public bool HasInsufficientPower
		{
			get { return _hasInsufficientPower; }
			set { SetValue(ref _hasInsufficientPower, value, nameof(HasInsufficientPower)); }
		}

		public BindableCollection<EnergySource> EnergySources { get; } = new BindableCollection<EnergySource>();

		public BindableCollection<Thruster> Thrusters { get; } = new BindableCollection<Thruster>();

		private ShipSize _shipSize;

		public ShipSize ShipSize
		{
			get { return _shipSize; }
			set
			{
				SetValue(ref _shipSize, value, nameof(ShipSize));
				RecalculateValues();
			}
		}

		private int _desiredMass;

		/// <summary>
		/// kg
		/// </summary>
		public int DesiredMass
		{
			get { return _desiredMass; }
			set
			{
				SetValue(ref _desiredMass, value, nameof(DesiredMass));
				RecalculateValues();
			}
		}

		private float _gravity;

		/// <summary>
		/// m/s²
		/// </summary>
		public float Gravity
		{
			get { return _gravity; }
			set
			{
				SetValue(ref _gravity, value, nameof(Gravity));
				RecalculateValues();
			}
		}

		private float _efficiency;

		public float Efficiency
		{
			get { return _efficiency; }
			set
			{
				SetValue(ref _efficiency, value, nameof(Efficiency));
				RecalculateValues();
			}
		}

		public async void DeleteThruster(Thruster item)
		{
			Thrusters.Remove(item);
		}

		public async void CopyThruster(Thruster item)
		{
			Thrusters.Add(item.Clone() as Thruster);
		}

		public async void DeleteEnergySource(EnergySource item)
		{
			EnergySources.Remove(item);
		}

		public async void CopyEnergySource(EnergySource item)
		{
			EnergySources.Add(item.Clone() as EnergySource);
		}

		public async void AddEnergySourceDialog()
		{
			var item = new NewEnergySourceViewModel();
			var source = new EnergySourceOverviewViewModel();
			item.Items.AddRange((await source.LoadItemsFromFileAsync()).Where(d => d.ShipSize == ShipSize));
			var dialog = await this.CreateDialogAsync(item);
			dialog.Title = "Neue Energiequelle auswählen:";
			dialog.AddButton(async () =>
			{
				var cvs = CollectionViewSource.GetDefaultView(item.Items);
				var current = cvs.CurrentItem as EnergySource;
				EnergySources.Add(current);
				await dialog.HideAsync();
			}, "Übernehmen", true);

			await dialog.ShowAsync(false);
		}

		public async void AddThrusterDialog()
		{
			var item = new NewThrusterDialogViewModel();
			var source = new ThrusterOverviewViewModel();
			item.Items.AddRange((await source.LoadItemsFromFileAsync()).Where(d => d.ShipSize == ShipSize));
			var dialog = await this.CreateDialogAsync(item);
			dialog.Title = "Neues Triebwerk auswählen:";
			dialog.AddButton(async () =>
			{
				var cvs = CollectionViewSource.GetDefaultView(item.Items);
				var current = cvs.CurrentItem as Thruster;
				Thrusters.Add(current);
				await dialog.HideAsync();
			}, "Übernehmen", true);

			await dialog.ShowAsync(false);
		}
	}
}