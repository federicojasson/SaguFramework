using System.Collections;
using UnityEngine;

namespace SaguFramework {

	public partial class Fader : MonoBehaviour {

		private float fadingSpeed;
		private Texture2D fadingTexture;
		private float fadingTextureOpacity;

		public void Awake() {
			// Sets itself as the singleton instance
			instance = this;

			// Initializes the speed and texture's opacity
			fadingSpeed = 0;
			fadingTextureOpacity = 1;
		}

		public IEnumerator FadeInCoroutine(FadingParameters fadingParameters) {
			if (fadingParameters.Ignore)
				// Ignores the fading-in
				yield break;

			// Sets the speed
			fadingSpeed = - fadingParameters.Speed;
			
			// Sets the texture
			if (fadingParameters.Texture == null)
				fadingTexture = ParameterManager.GetDefaultFadingTexture();
			else
				fadingTexture = fadingParameters.Texture;

			while (fadingTextureOpacity > 0)
				if (fadingSpeed >= 0)
					// The speed has been reverted, so the coroutine has to end
					yield break;
				else
					// Waits until the texture's opacity is lower than 0
					yield return null;

			// Stops the fading-in
			fadingSpeed = 0;
		}
		
		public IEnumerator FadeOutCoroutine(FadingParameters fadingParameters) {
			if (fadingParameters.Ignore)
				// Ignores the fading-out
				yield break;

			// Sets the speed
			fadingSpeed = fadingParameters.Speed;

			// Sets the texture
			if (fadingParameters.Texture == null)
				fadingTexture = ParameterManager.GetDefaultFadingTexture();
			else
				fadingTexture = fadingParameters.Texture;
			
			while (fadingTextureOpacity < 1)
				if (fadingSpeed <= 0)
					// The speed has been reverted, so the coroutine has to end
					yield break;
				else
					// Waits until the texture's opacity is greater than 0
					yield return null;
			
			// Stops the fading-out
			fadingSpeed = 0;
		}

		public void OnGUI() {
			if (Event.current.type == EventType.Repaint) {
				// Exactly one repaint event is sent every frame
				
				// Updates the texture's opacity
				fadingTextureOpacity += fadingSpeed * Time.deltaTime;
				float clampedFadeTextureOpacity = Mathf.Clamp01(fadingTextureOpacity);

				if (fadingTexture != null) {
					// There is a fading texture to draw

					// Sets the texture's opacity
					GUI.color = UtilityManager.GetColor(GUI.color, clampedFadeTextureOpacity);

					// Gets the game rectangle in pixels
					Rect gameRectangle = UtilityManager.GetGameRectangleInScreen();
					
					// GUI space has (0, 0) at top-left
					gameRectangle.y = UtilityManager.GetScreenHeightPixels() - gameRectangle.y;

					// Draws the texture
					GUI.DrawTexture(gameRectangle, fadingTexture);
				}
			}
		}

	}

}
