using Caliburn.Micro;
using SpaceEngineersCalculator.Desktop.Caliburn;
using SpaceEngineersCalculator.Desktop.Model;

namespace SpaceEngineersCalculator.Desktop.ViewModels.Dialogs
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