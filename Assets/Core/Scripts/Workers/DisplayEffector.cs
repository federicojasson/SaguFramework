using UnityEngine;

public partial class DisplayEffector : MonoBehaviour {
	
	private float fadeSpeed;
	private Texture2D fadeTexture;
	private float fadeTextureAlphaValue;

	public void Awake() {
		fadeSpeed = 0;
		fadeTextureAlphaValue = 1;
		instance = this;
	}

	public void OnGUI() {
		if (Event.current.type == EventType.Repaint) {
			// Exactly one repaint event is sent every frame

			if (fadeTexture != null) {
				// Updates the fade texture's alpha value
				fadeTextureAlphaValue += fadeSpeed * Time.deltaTime;
				float clampedfadeTextureAlphaValue = Mathf.Clamp01(fadeTextureAlphaValue);
				
				// Draws the fade texture
				GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, clampedfadeTextureAlphaValue);
				GUI.DrawTexture(UtilityManager.GetScreenRectangle(), fadeTexture);
			}
		}
	}
	
}
