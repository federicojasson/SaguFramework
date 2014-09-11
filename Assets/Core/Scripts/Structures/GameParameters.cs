using System;

namespace SaguFramework {

	[Serializable]
	public class GameParameters {

		public string GameDirectoryPath;
		public EntitiesParameters Entities;
		public GraphicsParameters Graphics;
		public SoundsParameters Sounds;
		public ControlsParameters Controls;
		public LoadersParameters Loaders;

	}
	
}
