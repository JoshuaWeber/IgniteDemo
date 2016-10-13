using System;
using System.Collections.Generic;
using HockeyApp;

using Xamarin.Forms;

namespace IgniteDemo
{
	public partial class QuestionPage : ContentPage
	{
		View[] passBtn;

		public QuestionPage(params View[] feedbackBtn)
		{
			InitializeComponent();

			passBtn = feedbackBtn;

			Device.OnPlatform(iOS: () =>
			{
				stkBottom.Children.Insert(0, feedbackBtn[0]);
			});

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			var answers = new List<Answer>();
			answers.Add(new Answer() { Name = "象山 (Elephant Mountain)", PhotoResource="IgniteDemo.Images.Destinations.Elephant_Mountain.png" });
			answers.Add(new Answer() { Name = "貓空纜車 (Maokong Gondola)", PhotoResource = "IgniteDemo.Images.Destinations.Maokong.png" });
			answers.Add(new Answer() { Name = "艋舺龍山寺 (Lungshan Temple)", PhotoResource = "IgniteDemo.Images.Destinations.Lungshan.png" });
			answers.Add(new Answer() { Name = "中正紀念堂 (Chiang Kai-shek Memorial Hall)", PhotoResource = "IgniteDemo.Images.Destinations.Chiang_Kai-shek.png" });
			answers.Add(new Answer() { Name = "國立故宮博物院 (National Palace Museum)", PhotoResource = "IgniteDemo.Images.Destinations.National_Palace.png" });
			answers.Add(new Answer() { Name = "臺北101 (Taipei 101)", PhotoResource = "IgniteDemo.Images.Taipei_101.png" });
			answers.Add(new Answer() { Name = "臺北市立動物園 (Taipei Zoo)", PhotoResource = "IgniteDemo.Images.Destinations.Taipei_Zoo.png" });
			answers.Add(new Answer() { Name = "北投區 (Beitou Hot Spring)", PhotoResource = "IgniteDemo.Images.Destinations.Beitou.png" });
			listView.ItemsSource = answers;

			Content.FindByName<Button>("btnCancel").Clicked += async (sender, e) =>
		   {
				await Navigation.PushAsync(new IgniteDemoPage(passBtn));
		   };
			Content.FindByName<Button>("btnNext").Clicked += async (sender, e) =>
			{
				string eventName = "Destination: ";
				Answer item = (Answer) listView.SelectedItem;
				eventName += item.Name;
				HockeyApp.MetricsManager.TrackEvent(eventName);

				if (item.Name == "臺北101 (Taipei 101)")
				{
					MissingImageCrash();
				}

				await Navigation.PushAsync(new IgniteDemoPage(passBtn));
			};
		}

		protected void MissingImageCrash()
		{
			throw new Exception("A Missing Image Caused a Crash");
		}
	}
}
