using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Caliburn.Micro;
using Newtonsoft.Json;
using Presentation.Caliburn;
using Presentation.Extensions;
using Presentation.Helpers;

namespace Presentation.ViewModels.Shared
{
	public abstract class PersistedItemsScreenBase<TItemType> : ScreenValidationBase
	{
		protected PersistedItemsScreenBase()
		{
			if (Execute.InDesignMode)
			{
				LoadItemsAsync();
			}
		}

		public BindableCollection<TItemType> Items { get; } = new BindableCollection<TItemType>();

		protected override async void OnInitialize()
		{
			base.OnInitialize();
			await LoadItemsAsync();
		}

		public async Task LoadItemsAsync()
		{
			Items.Clear();

			var items = await LoadItemsFromFileAsync();
			if (items.Count == 0)
			{
				items = LoadItemsFromDefaultFactory();
				Items.AddRange(items);
				await SaveItemsAsync();
			}
			else
			{
				Items.AddRange(items);
			}
		}

		public async Task RestoreItemsAsync()
		{
			var confirmed = await this.ConfirmAsync("Frage", "Sollen wirklich alle Daten gelöscht und die Werkseinstellungen geladen werden?");
			if (!confirmed)
				return;

			Items.Clear();
			Items.AddRange(LoadItemsFromDefaultFactory());
			await SaveItemsAsync();
		}

		public async Task SaveItemsAsync()
		{
			var serialized = JsonConvert.SerializeObject(Items);
			File.WriteAllText(await GetFileNameAndEnsureDirectoryAsync(), serialized);
		}

		protected abstract List<TItemType> LoadItemsFromDefaultFactory();

		protected abstract string GetPersistanceFileName();

		public async Task<List<TItemType>> LoadItemsFromFileAsync()
		{
			var path = await GetFileNameAndEnsureDirectoryAsync();
			if (!File.Exists(path))
				return new List<TItemType>();

			var content = File.ReadAllText(path);
			var deserialized = JsonConvert.DeserializeObject<List<TItemType>>(content);
			return deserialized;
		}

		protected async Task<string> GetFileNameAndEnsureDirectoryAsync()
		{
			var thrusterFileName = IoHelper.GetFileName(IoHelper.SpecialFolder.Environment, GetPersistanceFileName());
			await IoHelper.EnsureDirectoryAsync(Path.GetDirectoryName(thrusterFileName));

			return thrusterFileName;
		}
	}
}