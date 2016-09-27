using Xamarin.Forms;

namespace IgniteDemo
{
	public partial class App : Application
	{
		public App(params View[] children)
		{
			InitializeComponent();

			//MainPage = new IgniteDemoPage();
			MainPage = new NavigationPage(new IgniteDemoPage(children));
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
