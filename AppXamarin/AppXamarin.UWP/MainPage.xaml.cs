namespace AppXamarin.UWP
{
	public sealed partial class MainPage
    {
        public MainPage()
        {
			InitializeComponent();

            LoadApplication(new AppXamarin.App(new Setup()));
        }
    }
}
