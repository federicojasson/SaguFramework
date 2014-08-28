using System;
using UnityEngine;

namespace SaguFramework {
	
	[Serializable]
	public class GameParameters {

		public Color CameraBackgroundColor;
		public CharacterParametersMap CharacterParameters;
		public Texture2D DefaultFadingTexture;
		public float GameAspectRatio = 1f;
		public MainMenuParameters GameMainMenuParameters;
		public SplashScreenParameters GameSplashScreenParameters;
		public InventoryItemParametersMap InventoryItemParameters;
		public InventoryParameters InventoryParameters;
		public ItemParametersMap ItemParameters;
		public MenuParametersMap MenuParameters;
		public RoomParametersMap RoomParameters;
		public SplashScreenParameters[] SplashScreensParameters;
		public string StateFilesDirectoryPath;
		
	}
	
}
