using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Caliburn.Micro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Newtonsoft.Json;
using Presentation.Caliburn;
using Presentation.Interfaces;

namespace Presentation.ViewModels.Sections
{
	public class NewShipViewModel : ScreenValidationBase, IMainTabsControl
	{
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

		public void AddThrusterDialog()
		{
//			var view = ViewLocator.lo
			var w = App.Current.MainWindow as MetroWindow;
			if (w == null)
				return;
			w.ShowMetroDialogAsync(new NewThrusterDialog(), new MetroDialogSettings()
			{
				AffirmativeButtonText = "OK",
				AnimateShow = true,
				NegativeButtonText = "Go away!",
				FirstAuxiliaryButtonText = "Cancel",
			});
		}

		public void AddEnergySourceDialog()
		{
			var w = App.Current.MainWindow as MetroWindow;
			if (w == null)
				return;
			w.ShowMetroDialogAsync(new NewEnergySourceDialog(), new MetroDialogSettings()
			{
				AffirmativeButtonText = "OK",
				AnimateShow = true,
				NegativeButtonText = "Go away!",
				FirstAuxiliaryButtonText = "Cancel",
			});

		}
	}

	public class NewThrusterDialog : CustomDialog
	{
		public NewThrusterDialog()
		{
			Background = Brushes.Red;
			Content = new DockPanel();
			{
				Background = Brushes.Purple;
				Content = new Border()
				{
					Margin = new Thickness(10),
					Background = Brushes.Green
				};
			};
		}
	}

	public class NewEnergySourceDialog : CustomDialog
	{
		public NewEnergySourceDialog()
		{
			Background = Brushes.Red;
			Content = new DockPanel();
			{
				Background = Brushes.Purple;
				Content = new Border()
				{
					Margin = new Thickness(10),
					Background = Brushes.Green
				};
			};
		}
	}
}