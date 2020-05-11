using Caliburn.Micro;
using SpaceEngineersCalculator.Desktop.Mef;

namespace SpaceEngineersCalculator.Desktop.Interfaces
{
	[PartCreationPolicy(true)]
	[InheritedExport(typeof(IMainTabsControl))]
	public interface IMainTabsControl : IScreen
	{
		int Order { get; }
	}
}