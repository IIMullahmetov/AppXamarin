﻿using AppXamarin.Views;
using Xamarin.Forms;

namespace AppXamarin
{
	public partial class App : Application
	{

		public App (Setup setup)
		{
			AppContainer.Container = setup.CreateContainer();
			InitializeComponent();
            MainPage = new MainPage();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
