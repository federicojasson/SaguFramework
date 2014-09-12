using System;

namespace SaguFramework {

	[Serializable]
	public class RoomParameters {
		
		public float Height;
		public float ScaleFactor;
		public ImageParameters BackgroundImage;
		public ImageParameters ForegroundImage;
		public RoomTriggerParameters[] Triggers;
		public EntryParametersMap Entries;

	}
	
}
