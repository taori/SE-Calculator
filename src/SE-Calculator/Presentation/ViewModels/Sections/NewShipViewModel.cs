using System.Windows;
using System.Windows.Controls;
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

		public async void AddThrusterDialog()
		{
			await this.ShowDialogAsync(new NewThrusterDialogViewModel());
		}

		public async void AddEnergySourceDialog()
		{
			await this.ShowDialogAsync(new NewEnergySourceViewModel());
		}
	}
}