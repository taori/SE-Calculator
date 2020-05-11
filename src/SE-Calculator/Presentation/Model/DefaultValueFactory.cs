using System.Collections.Generic;
using Presentation.ViewModels.Sections;

namespace Presentation.Model
{
	public class DefaultValueFactory
	{
		public static List<EnergySource> GetDefaultEnergySources()
		{
			/* based on 
			** http://www.spaceengineerswiki.com/Reactor
			** http://www.spaceengineerswiki.com/Small_Reactor
			** http://www.spaceengineerswiki.com/Battery
			*/
			
			var result = new List<EnergySource>();
			result.Add(new EnergySource()
			{
				Name = "Großer Reaktor",
				ShipSize = ShipSize.Large,
				PowerOutput = 300000,
				Mass = 73795
			});
			result.Add(new EnergySource()
			{
				Name = "Großer Reaktor",
				ShipSize = ShipSize.Small,
				PowerOutput = 14750,
				Mass = 3901
			});
			result.Add(new EnergySource()
			{
				Name = "Kleiner Reaktor",
				ShipSize = ShipSize.Large,
				PowerOutput = 15000,
				Mass = 4793
			});
			result.Add(new EnergySource()
			{
				Name = "Kleiner Reaktor",
				ShipSize = ShipSize.Small,
				PowerOutput = 500,
				Mass = 278
			});

			result.Add(new EnergySource()
			{
				Name = "Batterie",
				ShipSize = ShipSize.Large,
				PowerOutput = 12000,
				Mass = 3845
			});
			result.Add(new EnergySource()
			{
				Name = "Batterie",
				ShipSize = ShipSize.Small,
				PowerOutput = 4000,
				Mass = 1040
			});

			return result;
		}

		public static List<Thruster> GetDefaultThrusters()
		{
			// based on http://www.spaceengineerswiki.com/Thruster

			var result = new List<Thruster>();
			
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Ionic,
				ShipSize = ShipSize.Large,
				EngineSize = EngineSize.Large,
				Thrust = 4320,
				Mass = 43200,
				PowerConsumption = 33600,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Ionic,
				ShipSize = ShipSize.Small,
				EngineSize = EngineSize.Large,
				Thrust = 172,
				Mass = 721,
				PowerConsumption = 2400,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Ionic,
				ShipSize = ShipSize.Large,
				EngineSize = EngineSize.Small,
				Thrust = 345,
				Mass = 4380,
				PowerConsumption = 3360,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Ionic,
				ShipSize = ShipSize.Small,
				EngineSize = EngineSize.Small,
				Thrust = 14,
				Mass = 121,
				PowerConsumption = 200,
			});
			
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Hydrogen,
				ShipSize = ShipSize.Large,
				EngineSize = EngineSize.Large,
				Thrust = 7200,
				Mass = 6940,
				PowerConsumption = 7500,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Hydrogen,
				ShipSize = ShipSize.Small,
				EngineSize = EngineSize.Large,
				Thrust = 480,
				Mass = 1222,
				PowerConsumption = 600,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Hydrogen,
				ShipSize = ShipSize.Large,
				EngineSize = EngineSize.Small,
				Thrust = 1080,
				Mass = 1420,
				PowerConsumption = 1250,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Hydrogen,
				ShipSize = ShipSize.Small,
				EngineSize = EngineSize.Small,
				Thrust = 98,
				Mass = 334,
				PowerConsumption = 125,
			});
			
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Atmospheric,
				ShipSize = ShipSize.Large,
				EngineSize = EngineSize.Large,
				Thrust = 6480,
				Mass = 32970,
				PowerConsumption = 16800,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Atmospheric,
				ShipSize = ShipSize.Small,
				EngineSize = EngineSize.Large,
				Thrust = 576,
				Mass = 2948,
				PowerConsumption = 2400,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Atmospheric,
				ShipSize = ShipSize.Large,
				EngineSize = EngineSize.Small,
				Thrust = 648,
				Mass = 4000,
				PowerConsumption = 2400,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Atmospheric,
				ShipSize = ShipSize.Small,
				EngineSize = EngineSize.Small,
				Thrust = 96,
				Mass = 699,
				PowerConsumption = 600,
			});


			return result;
		}
	}
}