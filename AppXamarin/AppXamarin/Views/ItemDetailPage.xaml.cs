using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppXamarin.Models;
using AppXamarin.ViewModels;
using AppXamarin.Services;

namespace AppXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

			Item item = new Item
            {
                Name = "Item 1",
                Password = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(new MockDataStore(), item);
            BindingContext = viewModel;
        }
    }
}