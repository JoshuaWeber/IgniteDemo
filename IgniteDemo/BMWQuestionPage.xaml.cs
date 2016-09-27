using System;
using System.Collections.Generic;
using HockeyApp;

using Xamarin.Forms;

namespace IgniteDemo
{
	public partial class BMWQuestionPage : ContentPage
	{
		public BMWQuestionPage(params View[] feedbackBtn)
		{
			InitializeComponent();

			//stkBottom.Children.Insert(0, feedbackBtn[0]);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			var cars = new List<Car>();
			cars.Add(new Car() { Name = "1993 BMW M5", PhotoResource="IgniteDemo.Images.Cars.1993_bmw_m5.jpg" });
			cars.Add(new Car() { Name = "1997 BMW M3", PhotoResource = "IgniteDemo.Images.Cars.97_bmw_m3.jpg" });
			cars.Add(new Car() { Name = "1997 BMW 840 CI", PhotoResource = "IgniteDemo.Images.Cars.97_bmw_840.jpg" });
			cars.Add(new Car() { Name = "2001 BMW M3", PhotoResource = "IgniteDemo.Images.Cars.01_bmw_m3.jpg" });
			cars.Add(new Car() { Name = "2001 BMW 740 i Sport", PhotoResource = "IgniteDemo.Images.Cars.01_bmw_740.jpg" });
			cars.Add(new Car() { Name = "2005 BMW K 1200 S", PhotoResource = "IgniteDemo.Images.Cars.05_bmw_k1200.jpg" });
			cars.Add(new Car() { Name = "2006 BMW X5", PhotoResource = "IgniteDemo.Images.Cars.06_bmw_x5.jpg" });
			cars.Add(new Car() { Name = "2005 Mercedes E55 AMG", PhotoResource = "IgniteDemo.Images.Cars.05_mercedes_e55.jpg" });
			listView.ItemsSource = cars;

			Content.FindByName<Button>("btnCancel").Clicked += async (sender, e) =>
		   {
				await Navigation.PushAsync(new IgniteDemoPage());
		   };
			Content.FindByName<Button>("btnNext").Clicked += async (sender, e) =>
			{
				string eventName = "Car: ";
				Car item = (Car) listView.SelectedItem;
				eventName += item.Name;
				HockeyApp.MetricsManager.TrackEvent(eventName);

				await Navigation.PushAsync(new HockeyQuestionPage());
			};

			//var tgr = new TapGestureRecognizer((obj) =>
			//{
				//var feedbackManager = 
				//Xamarin.Forms.DependencyService.Get<IHockeySDK>().openFeedback(); 
			//});
			//lblFeedback.GestureRecognizers.Add(tgr);
		}
	}
}
