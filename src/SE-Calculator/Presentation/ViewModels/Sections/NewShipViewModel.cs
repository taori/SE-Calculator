using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Caliburn.Micro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Newtonsoft.Json;
using Presentation.Caliburn;
using Presentation.Extensions;
using Presentation.Interfaces;
using Presentation.ViewModels.Dialogs;

namespace Presentation.ViewModels.Sections
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
		}

		public BindableCollection<EnergySource> EnergySources { get; } = new BindableCollection<EnergySource>();

		public BindableCollection<Thruster> Thrusters { get; } = new BindableCollection<Thruster>();

		private ShipSize _shipSize;

		public ShipSize ShipSize
		{
			get { return _shipSize; }
			set { SetValue(ref _shipSize, value, nameof(ShipSize)); }
		}
		
		private int _desiredMass;

		/// <summary>
		/// kg
		/// </summary>
		public int DesiredMass
		{
			get { return _desiredMass; }
			set { SetValue(ref _desiredMass, value, nameof(DesiredMass)); }
		}

		private float _gravity;
		/// <summary>
		/// m/s²
		/// </summary>
		public float Gravity
		{
			get { return _gravity; }
			set { SetValue(ref _gravity, value, nameof(Gravity)); }
		}

		private float _efficiency;

		public float Efficiency
		{
			get { return _efficiency; }
			set { SetValue(ref _efficiency, value, nameof(Efficiency)); }
		}

		public async void AddThrusterDialog()
		{
//			var b = await this.ConfirmAsync("hi", "no");
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
			}, "Übernehmen");
			await dialog.ShowAsync();
		}

		public async void AddEnergySourceDialog()
		{
			//			var b = await this.ConfirmAsync("hi", "no");
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
			}, "Übernehmen");
			await dialog.ShowAsync();
		}
	}
}