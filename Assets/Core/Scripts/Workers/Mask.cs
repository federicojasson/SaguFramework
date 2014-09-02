using UnityEngine;

namespace SaguFramework {
	
	public class Mask : Worker {
		
		private static Mask instance;
		
		public static Mask GetInstance() {
			return instance;
		}

		private float fadeSpeed;
		private Texture2D fadeTexture;
		private float fadeTextureOpacity;

		public override void Awake() {
			base.Awake();
			instance = this;
			fadeSpeed = 0;
			fadeTextureOpacity = 1;
		}

		public void OnGUI() {
			if (Event.current.type == EventType.Repaint) {
				// Exactly one repaint event is sent every frame
				Fade();
				Windowbox();
			}
		}

		public void SetFadeSpeed(float speed) {
			fadeSpeed = speed;
		}

		public void SetFadeTexture(Texture2D texture) {
			fadeTexture = texture;
		}

		public void SetFadeTextureOpacity(float opacity) {
			fadeTextureOpacity = opacity;
		}

		private void Fade() {
			if (fadeTexture != null) {
				fadeTextureOpacity += fadeSpeed * Time.deltaTime;
				float clampedFadeTextureOpacity = Mathf.Clamp01(fadeTextureOpacity);

				Rect gameRectangle = Geometry.GetGameRectangleInGui();

				GUI.color = Utilities.GetColor(GUI.color, clampedFadeTextureOpacity);
				GUI.DrawTexture(gameRectangle, fadeTexture);
			}
		}

		private void Windowbox() {
			Texture2D windowboxingTexture = Parameters.GetWindowboxingTexture();
			Rect[] windowboxingRectangles = Geometry.GetWindowboxingRectanglesInGui();

			GUI.color = Utilities.GetColor(GUI.color, 1);
			foreach (Rect windowboxingRectangle in windowboxingRectangles)
				GUI.DrawTexture(windowboxingRectangle, windowboxingTexture);
		}

	}
	
}
