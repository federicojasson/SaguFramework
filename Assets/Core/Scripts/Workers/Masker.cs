using System.Collections;
using UnityEngine;

namespace SaguFramework {

	public partial class Masker : MonoBehaviour {

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
				fadingTexture = ParameterManager.GetFadingTexture();
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
				fadingTexture = ParameterManager.GetFadingTexture();
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

				// Fading
				Fade();

				// Windowboxing
				Windowbox();
			}
		}

		private void Fade() {
			// Updates the texture's opacity
			fadingTextureOpacity += fadingSpeed * Time.deltaTime;
			float clampedFadeTextureOpacity = Mathf.Clamp01(fadingTextureOpacity);
			
			if (fadingTexture != null) {
				// There is a fading texture to draw
				
				// Gets the game rectangle in the screen space
				Rect gameRectangle = UtilityManager.GetGameRectangleInScreen();
				
				// Sets the texture's opacity
				GUI.color = UtilityManager.GetColor(GUI.color, clampedFadeTextureOpacity);
				
				// Draws the texture
				GUI.DrawTexture(UtilityManager.GetGuiRectangle(gameRectangle), fadingTexture);
			}
		}

		private void Windowbox() {
			// Gets the windowboxing rectangles in the screen space
			Rect[] windowboxingRectangles = UtilityManager.GetWindowboxingRectanglesInScreen();

			// Sets the texture's opacity
			GUI.color = UtilityManager.GetColor(GUI.color, 1);
			
			// Gets the windowboxing texture
			Texture2D windowboxingTexture = ParameterManager.GetWindowboxingTexture();

			// Draws the textures
			foreach (Rect windowboxingRectangle in windowboxingRectangles)
				GUI.DrawTexture(UtilityManager.GetGuiRectangle(windowboxingRectangle), windowboxingTexture);
		}

	}

}
