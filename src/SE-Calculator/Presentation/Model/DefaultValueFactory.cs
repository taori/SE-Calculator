using System.Collections.Generic;
using Presentation.ViewModels.Sections;

namespace Presentation.Model
{
	public class DefaultValueFactory
	{
		public static List<EnergySource> GetDefaultEnergySources()
		{
			// based on http://www.spaceengineerswiki.com/Reactor / http://www.spaceengineerswiki.com/Small_Reactor

			var result = new List<EnergySource>();
			result.Add(new EnergySource()
			{
				Name = "Großer Reaktor",
				ShipSize = ShipSize.Large,
				PowerOutput = 300000
			});
			result.Add(new EnergySource()
			{
				Name = "Großer Reaktor",
				ShipSize = ShipSize.Small,
				PowerOutput = 147500
			});
			result.Add(new EnergySource()
			{
				Name = "Kleiner Reaktor",
				ShipSize = ShipSize.Large,
				PowerOutput = 15000
			});
			result.Add(new EnergySource()
			{
				Name = "Kleiner Reaktor",
				ShipSize = ShipSize.Small,
				PowerOutput = 500
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
				Thrust = 3600,
				Mass = 43200,
				PowerConsumption = 33600,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Ionic,
				ShipSize = ShipSize.Small,
				EngineSize = EngineSize.Large,
				Thrust = 144,
				Mass = 721,
				PowerConsumption = 2400,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Ionic,
				ShipSize = ShipSize.Large,
				EngineSize = EngineSize.Small,
				Thrust = 288,
				Mass = 4384,
				PowerConsumption = 3360,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Ionic,
				ShipSize = ShipSize.Small,
				EngineSize = EngineSize.Small,
				Thrust = 12,
				Mass = 93,
				PowerConsumption = 201,
			});
			
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Hydrogen,
				ShipSize = ShipSize.Large,
				EngineSize = EngineSize.Large,
				Thrust = 6000,
				Mass = 6940,
				PowerConsumption = 10000,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Hydrogen,
				ShipSize = ShipSize.Small,
				EngineSize = EngineSize.Large,
				Thrust = 400,
				Mass = 1222,
				PowerConsumption = 800,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Hydrogen,
				ShipSize = ShipSize.Large,
				EngineSize = EngineSize.Small,
				Thrust = 900,
				Mass = 1420,
				PowerConsumption = 1700,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Hydrogen,
				ShipSize = ShipSize.Small,
				EngineSize = EngineSize.Small,
				Thrust = 82,
				Mass = 334,
				PowerConsumption = 170,
			});
			
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Atmospheric,
				ShipSize = ShipSize.Large,
				EngineSize = EngineSize.Large,
				Thrust = 5400,
				Mass = 33834,
				PowerConsumption = 16360,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Atmospheric,
				ShipSize = ShipSize.Small,
				EngineSize = EngineSize.Large,
				Thrust = 408,
				Mass = 4244,
				PowerConsumption = 2400,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Atmospheric,
				ShipSize = ShipSize.Large,
				EngineSize = EngineSize.Small,
				Thrust = 420,
				Mass = 4072,
				PowerConsumption = 2360,
			});
			result.Add(new Thruster()
			{
				Category = ThrusterCategory.Atmospheric,
				ShipSize = ShipSize.Small,
				EngineSize = EngineSize.Small,
				Thrust = 80,
				Mass = 539,
				PowerConsumption = 701,
			});


			return result;
		}
	}
}