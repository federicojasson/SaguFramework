using System;
using UnityEngine;

namespace SaguFramework.Structures.Serializable {
	
	[Serializable]
	public class GameParameters {
		
		public CharacterParametersMap CharacterParameters;
		public float GameAspectRatio;
		public InventoryItemParametersMap InventoryItemParameters;
		public InventoryParameters InventoryParameters;
		public ItemParametersMap ItemParameters;
		public MainMenuParameters MainMenuParameters;
		public SplashScreenParameters MainSplashScreenParameters;
		public MenuParametersMap MenuParameters;
		public RoomParametersMap RoomParameters;
		public SplashScreenParameters[] SplashScreensParameters;
		public string StateFilesDirectoryPath;
		
	}
	
}
