using System.Collections;
using UnityEngine;

namespace SaguFramework {
	
	public class Masker : Worker {
		
		private static Masker instance;
		
		public static Masker GetInstance() {
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

		public float GetFadeSpeed() {
			return fadeSpeed;
		}

		public float GetFadeTextureOpacity() {
			return fadeTextureOpacity;
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

		private void Fade() {
			if (fadeTexture == null)
				fadeTexture = Parameters.GetFadeTexture();

			fadeTextureOpacity += fadeSpeed * Time.deltaTime;
			float clampedFadeTextureOpacity = Mathf.Clamp01(fadeTextureOpacity);

			Rect gameRectangle = Geometry.GetGameRectangleInGui();

			GUI.color = Utilities.GetColor(GUI.color, clampedFadeTextureOpacity);
			GUI.DrawTexture(gameRectangle, fadeTexture);
		}

		private void Windowbox() {
			Texture2D windowboxTexture = Parameters.GetWindowboxTexture();
			Rect[] windowboxRectangles = Geometry.GetWindowboxRectanglesInGui();

			GUI.color = Utilities.GetColor(GUI.color, 1);
			foreach (Rect windowboxingRectangle in windowboxRectangles)
				GUI.DrawTexture(windowboxingRectangle, windowboxTexture);
		}

	}
	
}
