using System;

namespace SaguFramework {
	
	[Serializable]
	public class RoomParameters {

		public ImageParameters BackgroundImage;
		public Vector2Map EntryPositions;
		public FadingParameters FadingIn;
		public FadingParameters FadingOut;
		public ImageParameters ForegroundImage;
		public float ScaleFactor = 1f;

	}
	
}
