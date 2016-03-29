using Presentation.Mef;

namespace Presentation.Interfaces
{
	[PartCreationPolicy(true)]
	[InheritedExport(typeof(IShell))]
	public interface IShell
	{

	}
}