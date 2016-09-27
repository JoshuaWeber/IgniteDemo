using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IgniteDemo
{
	public partial class HockeyQuestionPage : ContentPage
	{
		public HockeyQuestionPage(params View[] feedbackBtn)
		{
			InitializeComponent();

			stkBottom.Children.Insert(0, feedbackBtn[0]);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			var teams = new List<Team>();

			teams.Add(new Team() { Name = "Boston Bruins", PhotoResource = "IgniteDemo.Images.Teams.Bruins.png" });
			teams.Add(new Team() { Name = "Buffalo Sabres", PhotoResource = "IgniteDemo.Images.Teams.Sabres.png" });
			teams.Add(new Team() { Name = "Detroit Redwings", PhotoResource = "IgniteDemo.Images.Teams.Redwings.png" });
			teams.Add(new Team() { Name = "Florida Panthers", PhotoResource = "IgniteDemo.Images.Teams.Panthers.png" });
			teams.Add(new Team() { Name = "Montréal Canadiens", PhotoResource = "IgniteDemo.Images.Teams.Canadiens.png" });
			teams.Add(new Team() { Name = "Ottawa Senators", PhotoResource = "IgniteDemo.Images.Teams.Senators.png" });
			teams.Add(new Team() { Name = "Tampa Bay Lightning", PhotoResource = "IgniteDemo.Images.Teams.Lightning.png" });
			teams.Add(new Team() { Name = "Toronto Maple Leafs", PhotoResource = "IgniteDemo.Images.Teams.Maple Leafs.png" });

			listView.ItemsSource = teams;

			Content.FindByName<Button>("btnCancel").Clicked += async (sender, e) =>
		   {
			   await Navigation.PushAsync(new IgniteDemoPage());
		   };
			Content.FindByName<Button>("btnNext").Clicked += async (sender, e) =>
			{
				string eventName = "Team: ";
				Team item = (Team)listView.SelectedItem;
				eventName += item.Name;
				HockeyApp.MetricsManager.TrackEvent(eventName);

				await Navigation.PushAsync(new IgniteDemoPage());
			};
		}
	}
}
