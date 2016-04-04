using Caliburn.Micro;
using Presentation.Caliburn;
using Presentation.ViewModels.Sections;

namespace Presentation.ViewModels.Dialogs
{
	public class NewThrusterDialogViewModel : ScreenValidationBase
	{
		private BindableCollection<Thruster> _items = new BindableCollection<Thruster>();

		public BindableCollection<Thruster> Items
		{
			get { return _items; }
			set { SetValue(ref _items, value, nameof(Items)); }
		}
	}
}