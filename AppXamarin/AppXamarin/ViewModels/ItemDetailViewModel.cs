using System;
using System.Windows.Input;
using AppXamarin.Models;
using AppXamarin.Services;
using Xamarin.Forms;

namespace AppXamarin.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(IDataStore<Item> dataStore,
			Item item = null) : base(dataStore)
        {
            Title = item?.Name;
            Item = item;
        }

		private string _name, _password, _url;

		public string Name
		{
			get => _name;
			set
			{
				_name = value;
				OnPropertyChanged("Name");
			}
		}

		public string Url
		{
			get => _url;
			set
			{
				_url = value;
				OnPropertyChanged("Url");
			}
		}

		public string Password
		{
			get => _password;
			set
			{
				_password = value;
				OnPropertyChanged("Password");
			}
		}

		public ICommand Save => new Command(() =>
		{

			Item.Name = _name;
			Item.Password = _password;
			Item.Url = _url;
		});
    }
}
