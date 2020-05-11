using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using SpaceEngineersCalculator.Desktop.Interfaces;
using SpaceEngineersCalculator.Desktop.Model;
using SpaceEngineersCalculator.Desktop.ViewModels.Sections;

namespace SpaceEngineersCalculator.Desktop.ViewModels.Windows
{
	public enum TabOptions
	{
		ReactorOverview,
		ThrusterOverview,
		NewSmallShip,
		NewLargeShip
	}

	public class ShellViewModel : Conductor<IMainTabsControl>.Collection.OneActive, IShell
	{
		public ShellViewModel()
		{
			if (Execute.InDesignMode)
			{
				OpenTab(TabOptions.ThrusterOverview);
			}
		}

		protected override async void OnInitialize()
		{
			base.OnInitialize();

			await Task.Delay(1000);

			OpenTab(TabOptions.ThrusterOverview);
			OpenTab(TabOptions.ReactorOverview);
			OpenTab(TabOptions.NewSmallShip);
		}

		public override string DisplayName
		{
			get { return "Space Engineer Calculator"; }
			set { }
		}

		public void OpenTab(TabOptions tab)
		{
			switch (tab)
			{
				case TabOptions.ReactorOverview:
					OpenReactorTab();
					break;
				case TabOptions.ThrusterOverview:
					OpenThrusterTab();
					break;
				case TabOptions.NewSmallShip:
					OpenNewShipTab(ShipSize.Small);
					break;
				case TabOptions.NewLargeShip:
					OpenNewShipTab(ShipSize.Large);
					break;
				default:
					return;
			}
		}

		private void OpenNewShipTab(ShipSize size)
		{
			IMainTabsControl newTab;
			newTab = new NewShipViewModel(size);
			newTab.DisplayName = $"Neues Schiff ({size})";
			this.Items.Add(newTab);
			ActivateItem(newTab);
		}

		private void OpenThrusterTab()
		{
			var tab = Items.FirstOrDefault(d => d.GetType() == typeof (ThrusterOverviewViewModel));
			if (tab != null)
			{
				ActivateItem(tab);
				return;
			}
				
			IMainTabsControl newTab;
			newTab = new ThrusterOverviewViewModel();
			newTab.DisplayName = "Triebwerksübersicht";
			this.Items.Add(newTab);
			ActivateItem(newTab);
		}

		private void OpenReactorTab()
		{
			var tab = Items.FirstOrDefault(d => d.GetType() == typeof(EnergySourceOverviewViewModel));
			if (tab != null)
			{
				ActivateItem(tab);
				return;
			}

			IMainTabsControl newTab;
			newTab = new EnergySourceOverviewViewModel();
			newTab.DisplayName = "Energiequellen";
			this.Items.Add(newTab);
			ActivateItem(newTab);
		}

		public void CloseQuery(IMainTabsControl item)
		{
			item.TryClose();
		}
	}
}