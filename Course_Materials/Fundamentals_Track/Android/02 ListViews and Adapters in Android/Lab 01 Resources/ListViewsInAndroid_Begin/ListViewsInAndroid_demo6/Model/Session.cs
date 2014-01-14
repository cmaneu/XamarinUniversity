using System;

namespace ListViewsInAndroid.Model
{
	public class Session
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Abstract { get; set; }

		public string Location { get; set; }

		public DateTime Begins { get; set; }

		public DateTime Ends { get; set; }

        public string Speaker { get; set; }
	}
}