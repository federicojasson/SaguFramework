using System;

namespace SaguFramework {

	[Serializable]
	public class GameParameters {

		public string GameDirectoryPath;
		public float GameAspectRatio;
		public RoomParametersMap Rooms;
		public CharacterParametersMap Characters;
		public ItemParametersMap Items;
		public MenusParameters Menus;
		public SplashScreensParameters SplashScreens;
		public SoundsParameters Sounds;
		public LoadersParameters Loaders;

	}

}
