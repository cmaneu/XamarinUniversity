using System.Collections.Generic;

namespace ListViewsInAndroid.Model
{
	public class Speaker
	{
		public Speaker ()
		{
			Sessions = new List<Session> ();
		}

		public string Company  { get; set; }

		public int Id { get; set; }

		public string Name { get; set; }

		public string TwitterHandle { get; set; }

		public string Bio { get; set; }

		public string HeadshotUrl { get; set; }

		public List<Session> Sessions { get; set; }
	}
}

