using System;
using System.Runtime.Serialization;
using Presentation.Caliburn;

namespace Presentation.Model
{
	[DataContract]
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

		private int _thrust;
		/// <summary>
		/// kN
		/// </summary>
		[DataMember]
		public int Thrust
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