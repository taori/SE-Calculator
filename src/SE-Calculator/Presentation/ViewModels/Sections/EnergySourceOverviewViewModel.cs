using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Presentation.Caliburn;
using Presentation.Framework;
using Presentation.Interfaces;
using Presentation.Model;
using Presentation.Resources;
using Presentation.ViewModels.Shared;
using Action = System.Action;

namespace Presentation.ViewModels.Sections
{
	public class EnergySourceOverviewViewModel : PersistedItemsScreenBase<EnergySource>, IMainTabsControl
	{
		public int Order { get; } = 0;

		protected override List<EnergySource> LoadItemsFromDefaultFactory()
		{
			return DefaultValueFactory.GetDefaultEnergySources();
		}

		protected override string GetPersistanceFileName()
		{
			return "energysources.json";
		}
	}

	public class EnergySource : PropertyChangedValidationBase
	{
		private int _powerOutput;
		/// <summary>
		/// kW
		/// </summary>
		public int PowerOutput
		{
			get { return _powerOutput; }
			set { SetValue(ref _powerOutput, value, nameof(PowerOutput)); }
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set { SetValue(ref _name, value, nameof(Name)); }
		}

		private ShipSize _shipSize;

		public ShipSize ShipSize
		{
			get { return _shipSize; }
			set { SetValue(ref _shipSize, value, nameof(ShipSize)); }
		}
	}
}