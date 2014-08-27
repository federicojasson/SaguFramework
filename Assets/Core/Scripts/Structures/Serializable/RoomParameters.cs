using System;

namespace SaguFramework.Structures.Serializable {
	
	[Serializable]
	public class RoomParameters {

		public ImageParameters BackgroundImage;
		public Vector2Map EntryPositions;
		public ImageParameters ForegroundImage;
		public float ScaleFactor;

	}
	
}
