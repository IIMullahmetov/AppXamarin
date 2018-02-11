using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppXamarin.Models;
using AppXamarin.ViewModels;
using AppXamarin.Services;

namespace AppXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsPage : ContentPage
	{
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel(new MockDataStore());
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
			Item item = args.SelectedItem as Item;
            if (item == null)
			{
				return;
			}

			await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(new MockDataStore(), item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
			{
				viewModel.LoadItemsCommand.Execute(null);
			}
		}
    }
}