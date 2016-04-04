using Caliburn.Micro;
using Presentation.Caliburn;
using Presentation.ViewModels.Sections;

namespace Presentation.ViewModels.Dialogs
{
	public class NewEnergySourceViewModel : ScreenValidationBase
	{
		private BindableCollection<EnergySource> _items = new BindableCollection<EnergySource>();

		public BindableCollection<EnergySource> Items
		{
			get { return _items; }
			set { SetValue(ref _items, value, nameof(Items)); }
		}
	}
}