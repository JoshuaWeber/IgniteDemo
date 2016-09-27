using System;
using Xamarin.Forms;

namespace IgniteDemo
{
	public class Team
	{
		string photoResource;

		public Team()
		{
		}

		public string Name { get; set; }

		public ImageSource PhotoSource
		{
			get
			{
				if (String.IsNullOrEmpty(photoResource))
					return ImageSource.FromResource("IgniteDemo.Images.image_120.png");
				else
					return ImageSource.FromResource(photoResource);
			}
		}
		public string PhotoResource
		{
			set
			{
				photoResource = value;
			}
		}
	}
}
