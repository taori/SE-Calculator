using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Caliburn.Micro;
using Newtonsoft.Json;
using Presentation.Caliburn;
using Presentation.Extensions;
using Presentation.Helpers;
using Presentation.Interfaces;
using Presentation.Model;
using Presentation.ViewModels.Shared;

namespace Presentation.ViewModels.Sections
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

	public enum ThrusterCategory
	{
		Atmospheric,
		Ionic,
		Hydrogen
	}

	public enum ShipSize
	{
		Small,
		Large
	}

	public enum EngineSize
	{
		Small,
		Large
	}

	public class Thruster : PropertyChangedValidationBase
	{
		private ShipSize _shipSize;
		[DataMember]
		public ShipSize ShipSize
		{
			get { return _shipSize; }
			set { SetValue(ref _shipSize, value, nameof(ShipSize)); }
		}

		private EngineSize _engineSize;
		[DataMember]
		public EngineSize EngineSize
		{
			get { return _engineSize; }
			set { SetValue(ref _engineSize, value, nameof(EngineSize)); }
		}

		private ThrusterCategory _category;
		[DataMember]
		public ThrusterCategory Category
		{
			get { return _category; }
			set { SetValue(ref _category, value, nameof(Category)); }
		}

		private long _thrust;
		/// <summary>
		/// kN
		/// </summary>
		[DataMember]
		public long Thrust
		{
			get { return _thrust; }
			set { SetValue(ref _thrust, value, nameof(Thrust)); }
		}

		private int _powerConsumption;
		/// <summary>
		/// kW
		/// </summary>
		[DataMember]
		public int PowerConsumption
		{
			get { return _powerConsumption; }
			set { SetValue(ref _powerConsumption, value, nameof(PowerConsumption)); }
		}

		private int _mass;
		/// <summary>
		/// kg
		/// </summary>
		[DataMember]
		public int Mass
		{
			get { return _mass; }
			set { SetValue(ref _mass, value, nameof(Mass)); }
		}

		public string DisplayName => $"{Category} {EngineSize}, {Thrust}kN, {PowerConsumption}kW, {Mass}kg";
	}
}