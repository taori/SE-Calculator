using Caliburn.Micro;
using Presentation.Mef;

namespace Presentation.Interfaces
{
	[PartCreationPolicy(true)]
	[InheritedExport(typeof(IMainTabsControl))]
	public interface IMainTabsControl : IScreen
	{
		int Order { get; }
	}
}