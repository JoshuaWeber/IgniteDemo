using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using HockeyApp.iOS;

namespace IgniteDemo.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			// Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif

			app.ApplicationSupportsShakeToEdit = true;


			var manager = BITHockeyManager.SharedHockeyManager;
			manager.Configure("fb44b2bf8fce44318d3f9ae6e6f67af9");
			manager.StartManager();
			//manager.Authenticator.AuthenticateInstallation(); // This line is obsolete in crash only builds

			// Create a Feedback Button
			var btnFeedback = new Xamarin.Forms.Button
			{
				Text = "Send Feedback",
				TextColor = Xamarin.Forms.Color.White,
				HorizontalOptions = Xamarin.Forms.LayoutOptions.Start,
				VerticalOptions = Xamarin.Forms.LayoutOptions.Center,
				Margin = new Xamarin.Forms.Thickness(10, 10)
			};
			btnFeedback.Clicked += (sender, e) =>
			{
				var feedbackManager = BITHockeyManager.SharedHockeyManager.FeedbackManager;
				feedbackManager.ShowFeedbackComposeView();
			};


			LoadApplication(new App(btnFeedback));


			return base.FinishedLaunching(app, options);
		}
	}
}
