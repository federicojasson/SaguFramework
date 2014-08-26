using System.Collections;
using UnityEngine;

namespace FrameworkNamespace {

	public static partial class GuiManager {
		
		public static IEnumerator FadeInCoroutine(FadeParameters fadeParameters) {
			if (fadeParameters.Ignore)
				return null;
			
			return Fader.FadeInCoroutine(fadeParameters.Speed, fadeParameters.Texture);
		}
		
		public static IEnumerator FadeOutCoroutine(FadeParameters fadeParameters) {
			if (fadeParameters.Ignore)
				return null;
			
			return Fader.FadeOutCoroutine(fadeParameters.Speed, fadeParameters.Texture);
		}
		
		public static Texture2D GetDefaultFadeTexture() {
			return GuiAssets.GetDefaultFadeTexture();
		}
		
	}

}
