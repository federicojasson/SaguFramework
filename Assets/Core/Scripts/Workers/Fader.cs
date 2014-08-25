using UnityEngine;

public partial class Fader : MonoBehaviour {

	private float fadeSpeed;
	private Texture2D fadeTexture;
	private float fadeTextureOpacity;

	public void Awake() {
		fadeSpeed = 0;
		fadeTextureOpacity = 1;
		instance = this;
	}

	public void OnGUI() {
		if (Event.current.type == EventType.Repaint) {
			// Exactly one repaint event is sent every frame

			// Updates the fade texture's opacity
			fadeTextureOpacity += fadeSpeed * Time.deltaTime;
			float clampedFadeTextureOpacity = Mathf.Clamp01(fadeTextureOpacity);

			if (fadeTexture != null) {
				// Draws the fade texture
				GUI.color = UtilityManager.GetColor(GUI.color, clampedFadeTextureOpacity);
				Rect gameRectangle = UtilityManager.GetGameRectangle();

				// GUI space has (0, 0) at top-left
				gameRectangle.y = UtilityManager.GetScreenHeightPixels() - gameRectangle.y;

				GUI.DrawTexture(gameRectangle, fadeTexture);
			}
		}
	}
	
}
