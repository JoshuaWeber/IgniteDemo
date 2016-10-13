using System;
using System.Collections.Generic;
using HockeyApp;

using Xamarin.Forms;

namespace IgniteDemo
{
	public partial class BMWQuestionPage : ContentPage
	{
		View[] passBtn;

		public BMWQuestionPage(params View[] feedbackBtn)
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

			var destinations = new List<Destination>();
			destinations.Add(new Destination() { Name = "象山 (Elephant Mountain)", PhotoResource="IgniteDemo.Images.Destinations.Elephant_Mountain.png" });
			destinations.Add(new Destination() { Name = "貓空纜車 (Maokong Gondola)", PhotoResource = "IgniteDemo.Images.Destinations.Maokong.png" });
			destinations.Add(new Destination() { Name = "艋舺龍山寺 (Lungshan Temple)", PhotoResource = "IgniteDemo.Images.Destinations.Lungshan.png" });
			destinations.Add(new Destination() { Name = "中正紀念堂 (Chiang Kai-shek Memorial Hall)", PhotoResource = "IgniteDemo.Images.Destinations.Chiang_Kai-shek.png" });
			destinations.Add(new Destination() { Name = "國立故宮博物院 (National Palace Museum)", PhotoResource = "IgniteDemo.Images.Destinations.National_Palace.png" });
			destinations.Add(new Destination() { Name = "臺北101 (Taipei 101)", PhotoResource = "IgniteDemo.Images.Taipei_101.png" });
			destinations.Add(new Destination() { Name = "臺北市立動物園 (Taipei Zoo)", PhotoResource = "IgniteDemo.Images.Destinations.Taipei_Zoo.png" });
			destinations.Add(new Destination() { Name = "北投區 (Beitou Hot Spring)", PhotoResource = "IgniteDemo.Images.Destinations.Beitou.png" });
			listView.ItemsSource = destinations;

			Content.FindByName<Button>("btnCancel").Clicked += async (sender, e) =>
		   {
				await Navigation.PushAsync(new IgniteDemoPage());
		   };
			Content.FindByName<Button>("btnNext").Clicked += async (sender, e) =>
			{
				string eventName = "Destination: ";
				Destination item = (Destination) listView.SelectedItem;
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
