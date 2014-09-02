using System;

namespace SaguFramework {

	[Serializable]
	public class GameParameters {

		public string GameDirectoryPath;
		public float GameAspectRatio;
		public RoomParametersMap Rooms;
		public ItemParametersMap Items;
		public SoundParameters Sound;

	}

}
