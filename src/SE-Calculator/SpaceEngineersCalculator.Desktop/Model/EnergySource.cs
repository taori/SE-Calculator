using System.Runtime.Serialization;
using SpaceEngineersCalculator.Desktop.Caliburn;

namespace SpaceEngineersCalculator.Desktop.Model
{
	[DataContract]
	public class EnergySource : PropertyChangedValidationBase
	{
		private int _powerOutput;
		/// <summary>
		/// kW
		/// </summary>
		[DataMember]
		public int PowerOutput
		{
			get { return _powerOutput; }
			set { SetValue(ref _powerOutput, value, nameof(PowerOutput)); }
		}

		private string _name;
		[DataMember]
		public string Name
		{
			get { return _name; }
			set { SetValue(ref _name, value, nameof(Name)); }
		}

		private ShipSize _shipSize;
		[DataMember]
		public ShipSize ShipSize
		{
			get { return _shipSize; }
			set { SetValue(ref _shipSize, value, nameof(ShipSize)); }
		}

		public string DisplayName
		{
			get { return $"{Name}, {PowerOutput} kW"; }
		}
	}
}