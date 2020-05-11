using System.Collections.Generic;
using SpaceEngineersCalculator.Desktop.Interfaces;
using SpaceEngineersCalculator.Desktop.Model;
using SpaceEngineersCalculator.Desktop.ViewModels.Shared;

namespace SpaceEngineersCalculator.Desktop.ViewModels.Sections
{
	public class EnergySourceOverviewViewModel : PersistedItemsScreenBase<EnergySource>, IMainTabsControl
	{
		public int Order { get; } = 0;

		protected override List<EnergySource> LoadItemsFromDefaultFactory()
		{
			return DefaultValueFactory.GetDefaultEnergySources();
		}

		protected override string GetPersistanceFileName()
		{
			return "energysources.json";
		}
	}
}