using System;
using UnityEngine;

namespace SaguFramework {
	
	[Serializable]
	public class GameParameters {

		// TODO: order

		public float GameAspectRatio = 1f;
		public string GameDirectoryPath;
		
		public RoomParametersMap RoomParameters;
		public CharacterParametersMap CharacterParameters;
		public ItemParametersMap ItemParameters;

		public InventoryParameters InventoryParameters;
		public InventoryItemParametersMap InventoryItemParameters;
		
		public MenuParameters MainMenuParameters;
		public MenuParametersMap MenuParameters;
		public SplashScreenParameters GameSplashScreenParameters;
		public SplashScreenParameters[] SplashScreensParameters;
		
		public LoaderParameters MainLoaderParameters;
		public LoaderParameters MainMenuLoaderParameters;
		public LoaderParameters RoomLoaderParameters;
		public LoaderParameters SpecialLoaderParameters;
		public LoaderParameters SplashScreenLoaderParameters;

		public AudioClip MainSong;
		public AudioClip MainMenuSong;
		public AudioClip[] Songs;
		public float DelayBetweenSongs = 1;
		public bool ShuffleSongs = false;

		public Color CameraBackgroundColor;
		
	}
	
}
