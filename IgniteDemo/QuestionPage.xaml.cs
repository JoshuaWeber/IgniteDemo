using System;
using System.Collections.Generic;
using HockeyApp;

using Xamarin.Forms;

namespace IgniteDemo
{
	public partial class QuestionPage : ContentPage
	{
		
		public QuestionPage()
		{
			InitializeComponent();


		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			var answers = new List<Answer>();
			answers.Add(new Answer() { Name = "Anthony Beauvillier", PhotoResource="IgniteDemo.Images.Rookies.Anthony_Beauvillier_r.png" });
			answers.Add(new Answer() { Name = "Auston Matthews", PhotoResource = "IgniteDemo.Images.Rookies.Auston_Matthews_r.png" });
			answers.Add(new Answer() { Name = "Devin Shore", PhotoResource = "IgniteDemo.Images.Rookies.Devin_Shore_r.png" });
			answers.Add(new Answer() { Name = "Jimmy Vesey", PhotoResource = "IgniteDemo.Images.Rookies.Jimmy_Vesey_r.png" });
			answers.Add(new Answer() { Name = "Patrik Laine", PhotoResource = "IgniteDemo.Images.Rookies.Patrik_Laine_r.png" });
			answers.Add(new Answer() { Name = "Travis Konecny", PhotoResource = "IgniteDemo.Images.Rookies.Travis_Konecny_r.png" });
			answers.Add(new Answer() { Name = "William Nylander", PhotoResource = "IgniteDemo.Images.Rookies.William_Nylander_r.png" });
			answers.Add(new Answer() { Name = "Zach Werenski", PhotoResource = "IgniteDemo.Images.Rookies.Zach_Werenski_r.png" });
			listView.ItemsSource = answers;

			btnCancel.Clicked += async (sender, e) =>
		   {
			   await Navigation.PopAsync();
		   };
			btnNext.Clicked += async (sender, e) =>
			{
				string eventName = "Rookie: ";
				Answer item = (Answer) listView.SelectedItem;
				eventName += item.Name;
				HockeyApp.MetricsManager.TrackEvent(eventName);

				if (item.Name != "Auston Matthews" && item.Name != "William Nylander")
				{
					TorontoRookies();
				}

				await Navigation.PopAsync();
			};
		}

		protected void TorontoRookies()
		{
			throw new Exception("Only has support for Toronto Maple Leafs Rookies");
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			DependencyService.Get<IHockeyAppHelpers>()?.SendFeedback();
		}
	}
}
