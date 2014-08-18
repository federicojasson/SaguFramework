using UnityEngine;

public partial class DisplayEffector : MonoBehaviour {
	
	private float fadeSpeed;
	private Texture2D fadeTexture;
	private float fadeTextureAlphaValue;

	public void Awake() {
		instance = this;

		// The fade is initially deactivated
		fadeSpeed = 0;

		if (Parameters.UseFadeAtMain)
			// The main scene uses fade
			fadeTextureAlphaValue = 1;
		else
			// The main scene doesn't use fade
			fadeTextureAlphaValue = 0;
	}

	public void OnGUI() {
		if (Event.current.type == EventType.Repaint) {
			// Exactly one repaint event is sent every frame
			
			// Updates the fade texture's alpha value
			fadeTextureAlphaValue += fadeSpeed * Time.deltaTime;
			float clampedfadeTextureAlphaValue = Mathf.Clamp01(fadeTextureAlphaValue);
			
			// Draws the fade texture
			GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, clampedfadeTextureAlphaValue);
			GUI.DrawTexture(UtilityManager.ComputeScreenRectangle(), fadeTexture);
		}
	}
	
}
