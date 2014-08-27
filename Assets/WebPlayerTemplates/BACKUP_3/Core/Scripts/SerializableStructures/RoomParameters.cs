using System;

namespace FrameworkNamespace {

	[Serializable]
	public class RoomParameters {

		public GameImageParameters BackgroundImageParameters;
		public Vector2Map EntryPositions;
		public FadeParameters FadeInParameters;
		public FadeParameters FadeOutParameters;
		public GameImageParameters ForegroundImageParameters;
		public float ScaleFactor;

	}

}
