using Xamarin.Forms;

namespace IgniteDemo
{
	public partial class IgniteDemoPage : ContentPage
	{
		View[] feedbackBtns;
		public IgniteDemoPage(params View[] children)
		{
			feedbackBtns = children;
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			TapGestureRecognizer tgr = new TapGestureRecognizer();
			tgr.Tapped += async (sender, e) =>
			{
				await Navigation.PushAsync(new BMWQuestionPage(feedbackBtns));
			};

			this.Content.GestureRecognizers.Add(tgr);

			//Content.FindByName<StackLayout> ("stackContainer").clicked
		}
	}
}
