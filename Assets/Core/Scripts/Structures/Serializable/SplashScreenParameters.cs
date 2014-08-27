using System;

namespace SaguFramework {
	
	[Serializable]
	public class SplashScreenParameters {

		public FadingParameters FadingIn;
		public FadingParameters FadingOut;
		public ImageParameters Image;
		public float MinimumDelayTime = 2f;

	}
	
}
