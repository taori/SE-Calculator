using System.Collections.Generic;
using Caliburn.Micro;
using SpaceEngineersCalculator.Desktop.Interfaces;
using SpaceEngineersCalculator.Desktop.Model;
using SpaceEngineersCalculator.Desktop.ViewModels.Shared;

namespace SpaceEngineersCalculator.Desktop.ViewModels.Sections
{
	public class ThrusterOverviewViewModel : PersistedItemsScreenBase<Thruster>, IMainTabsControl
	{
		public int Order { get; } = 0;

		public BindableCollection<ShipSize> ShipSizeOptions { get; } = new BindableCollection<ShipSize>();

		public BindableCollection<EngineSize> EngineSizeOptions { get; } = new BindableCollection<EngineSize>();

		public BindableCollection<ThrusterCategory> ThrusterCategoryOptions { get; } = new BindableCollection<ThrusterCategory>();

		private Thruster _newItem;

		public Thruster NewItem
		{
			get { return _newItem; }
			set { SetValue(ref _newItem, value, nameof(NewItem)); }
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();

			NewItem = new Thruster();

			ShipSizeOptions.Add(ShipSize.Small);
			ShipSizeOptions.Add(ShipSize.Large);

			EngineSizeOptions.Add(EngineSize.Large);
			EngineSizeOptions.Add(EngineSize.Small);

			ThrusterCategoryOptions.Add(ThrusterCategory.Atmospheric);
			ThrusterCategoryOptions.Add(ThrusterCategory.Hydrogen);
			ThrusterCategoryOptions.Add(ThrusterCategory.Ionic);
		}

		public async void CreateNewThruster()
		{
			Items.Add(NewItem);
			await SaveItemsAsync();
			NewItem = new Thruster();
		}

		protected override List<Thruster> LoadItemsFromDefaultFactory()
		{
			return DefaultValueFactory.GetDefaultThrusters();
		}

		protected override string GetPersistanceFileName()
		{
			return "thrusters.json";
		}
	}
}