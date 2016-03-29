using Caliburn.Micro;
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

			if (!Execute.InDesignMode)
				return;
		}
	}
}