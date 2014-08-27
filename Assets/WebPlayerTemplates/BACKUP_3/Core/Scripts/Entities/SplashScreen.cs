using System.Collections;
using UnityEngine;

namespace FrameworkNamespace {

	public class SplashScreen : MonoBehaviour {

		public FadeParameters FadeInParameters;
		public FadeParameters FadeOutParameters;
		public GameImageParameters ImageParameters;
		public float MinimumDelayTime;

		private float startTime;

		public virtual void Awake() {
			if (FadeInParameters.Texture == null)
				FadeInParameters.Texture = GuiManager.GetDefaultFadeTexture();
			
			if (FadeOutParameters.Texture == null)
				FadeOutParameters.Texture = GuiManager.GetDefaultFadeTexture();
			
			if (ImageParameters.SortingLayer.Length == 0)
				ImageParameters.SortingLayer = Parameters.SplashScreenImageSortingLayer;

			// Registers the current time
			startTime = Time.time;
		}

		public IEnumerator Delay() {
			float currentTime = Time.time;
			float elapsedTime = currentTime - startTime;
			
			if (elapsedTime < MinimumDelayTime)
				yield return new WaitForSeconds(MinimumDelayTime - elapsedTime);
		}

	}

}
