using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using AppXamarin.Models;

[assembly: Xamarin.Forms.Dependency(typeof(AppXamarin.Services.MockDataStore))]
namespace AppXamarin.Services
{
	public class MockDataStore : IDataStore<Item>
	{
		public static List<Item> items;

		static MockDataStore()
		{
			AddElements();
		}

		private static void AddElements()
		{
			Assembly assembly = typeof(MockDataStore).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("AppXamarin.Items.xml");
			using (StreamReader reader = new StreamReader(stream))
			{
				XDocument doc = XDocument.Load(stream);
				items = new List<Item>(doc.Descendants().Select(n => new Item
				{
					Name = n.Element("Name")?.Value,
					Password = n.Element("Password")?.Value,
					Id = n.Element("Id")?.Value,
					Url = n.Element("Url")?.Value
				}));
			}
		}

		public async Task<bool> AddItemAsync(Item item)
		{
			Assembly assembly = typeof(MockDataStore).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("AppXamarin.Items.xml");
			using (StreamReader reader = new StreamReader(stream))
			{
				XDocument doc = XDocument.Load(stream);
				doc.Root.Add(item);
				Stream str = new MemoryStream();
				doc.Save(str);
				bool b =File.Exists("AppXamarin.Items.xml");
			}
			items.Add(item);
			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			Item _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(Item item)
		{
			Item _item = items.FirstOrDefault((Item arg) => arg.Id == item.Id);
			items.Remove(_item);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{
			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(items);
		}
	}
}