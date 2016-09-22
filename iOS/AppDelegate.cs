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

			var manager = BITHockeyManager.SharedHockeyManager;
			manager.Configure("$fb44b2bf8fce44318d3f9ae6e6f67af9");
			manager.StartManager();
			//manager.Authenticator.AuthenticateInstallation(); // This line is obsolete in crash only builds


			LoadApplication(new App());


			return base.FinishedLaunching(app, options);
		}
	}
}
