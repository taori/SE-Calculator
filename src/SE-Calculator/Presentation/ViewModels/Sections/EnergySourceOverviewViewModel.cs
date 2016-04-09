using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
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
}