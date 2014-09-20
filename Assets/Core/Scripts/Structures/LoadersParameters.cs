using System;

namespace SaguFramework {
	
	[Serializable]
	public sealed class LoadersParameters {
		
		public LoaderParameters Main;
		public LoaderParameters MainMenu;
		public LoaderParameters Room;
		public LoaderParameters SplashScreen;
		
	}
	
}
