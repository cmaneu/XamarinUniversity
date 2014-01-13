using System;

namespace Xamarin.WebServices.Core
{
	public class Session
	{
		public int Id { get; set; }

		public Speaker Speaker { get; set; }

		public string Title { get; set; }

		public string Abstract { get; set; }

		public string Location { get; set; }

		public DateTime Begins { get; set; }

		public DateTime Ends { get; set; }
	}
}

