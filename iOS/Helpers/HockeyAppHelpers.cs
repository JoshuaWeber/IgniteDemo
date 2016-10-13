using System;
using Xamarin.Forms;
using IgniteDemo.iOS;
using HockeyApp.iOS;

[assembly:Dependency(typeof(HockeyAppHelpers))]
namespace IgniteDemo.iOS
{
	public class HockeyAppHelpers : IHockeyAppHelpers
	{
		public void SendFeedback()
		{
			var feedbackManager = BITHockeyManager.SharedHockeyManager.FeedbackManager;
			feedbackManager.ShowFeedbackComposeViewWithGeneratedScreenshot();

		}
	}
}
