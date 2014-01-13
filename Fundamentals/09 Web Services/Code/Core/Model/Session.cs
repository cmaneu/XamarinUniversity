using System;
#if __ANDROID__
using Android.Runtime;
#else
using MonoTouch.Foundation;
#endif

namespace EvolveLite
{
	// TODO: Demo1a: Session class
	[Preserve(AllMembers=true)]
	public class Session
	{
		public int Id { get; set; }

		public Speaker Speaker { get; set; }

		public string Title { get; set; }

		public string Abstract { get; set; }

		public string Location { get; set; }

		public DateTime Begins { get; set; }

		public DateTime Ends { get; set; }

		public Session ()
		{
		}
	}
}

