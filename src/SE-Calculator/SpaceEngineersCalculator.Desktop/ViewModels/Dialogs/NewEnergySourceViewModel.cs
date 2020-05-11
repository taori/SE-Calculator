using Caliburn.Micro;
using SpaceEngineersCalculator.Desktop.Caliburn;
using SpaceEngineersCalculator.Desktop.Model;

namespace SpaceEngineersCalculator.Desktop.ViewModels.Dialogs
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