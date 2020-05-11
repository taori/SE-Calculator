using System.Runtime.Serialization;
using Presentation.Caliburn;

namespace Presentation.Model
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

		private int _mass;
		[DataMember]
		public int Mass
		{
			get => _mass;
			set => SetValue(ref _mass, value, nameof(Mass));
		}

		public string DisplayName
		{
			get { return $"{Name}, {PowerOutput} kW"; }
		}
	}
}