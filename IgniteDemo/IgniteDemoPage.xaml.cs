using Xamarin.Forms;

namespace IgniteDemo
{
	public partial class IgniteDemoPage : ContentPage
	{
		public IgniteDemoPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			TapGestureRecognizer tgr = new TapGestureRecognizer();
			tgr.Tapped += async (sender, e) =>
			{
				await Navigation.PushAsync(new QuestionPage());
			};

			this.Content.GestureRecognizers.Add(tgr);

			//Content.FindByName<StackLayout> ("stackContainer").clicked
		}
	}
}
