using System;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using Presentation.Interfaces;
using Presentation.Resources;
using Presentation.ViewModels.Sections;

namespace Presentation.ViewModels.Windows
{
	public enum TabOptions
	{
		ReactorOverview,
		ThrusterOverview,
		NewShip
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

			OpenTab(TabOptions.NewShip);
		}

		public override string DisplayName
		{
			get { return "Space Engineer Calculator"; }
			set { }
		}

		public void OpenTab(TabOptions tab)
		{
			IMainTabsControl newTab;

			switch (tab)
			{
				case TabOptions.ReactorOverview:
					OpenReactorTab();
					break;
				case TabOptions.ThrusterOverview:
					OpenThrusterTab();
					break;
				case TabOptions.NewShip:
					OpenNewShipTab();
					break;
				default:
					return;
			}
		}

		private void OpenNewShipTab()
		{
			IMainTabsControl newTab;
			newTab = new NewShipViewModel();
			newTab.DisplayName = "Neues Schiff";
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
			var tab = Items.FirstOrDefault(d => d.GetType() == typeof(EnergySourceViewModel));
			if (tab != null)
			{
				ActivateItem(tab);
				return;
			}

			IMainTabsControl newTab;
			newTab = new EnergySourceViewModel();
			newTab.DisplayName = "Reaktorübersicht";
			this.Items.Add(newTab);
			ActivateItem(newTab);
		}

		public void CloseQuery(IMainTabsControl item)
		{
			item.TryClose();
		}
	}
}