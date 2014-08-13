using System.Collections;
using UnityEngine;

public class CurtainManagerWorker : MonoBehaviour {

	private float alphaChannelValue;
	private float fadeSpeed;
	
	public void Awake() {
		CurtainManager.SetWorker(this);
		alphaChannelValue = 1;
		fadeSpeed = 0;
	}
	
	public IEnumerator FadeInCoroutine(float fadeInSpeed) {
		alphaChannelValue = 1;
		fadeSpeed = fadeInSpeed;
		
		while (alphaChannelValue > 0)
			yield return null;
		
		alphaChannelValue = 0;
		fadeSpeed = 0;
	}
	
	public IEnumerator FadeOutCoroutine(float fadeOutSpeed) {
		alphaChannelValue = 0;
		fadeSpeed = fadeOutSpeed;
		
		while (alphaChannelValue < 1)
			yield return null;
		
		alphaChannelValue = 1;
		fadeSpeed = 0;
	}

	public void OnGUI() {
		if (Event.current.type == EventType.Repaint) {
			// Exactly one repaint event is sent every frame

			// Updates the alpha channel value
			alphaChannelValue += fadeSpeed * Time.deltaTime;
			float clampedAlphaChannelValue = Mathf.Clamp01(alphaChannelValue);

			// Draws the fade texture
			GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, clampedAlphaChannelValue);
			GUI.DrawTexture(CameraManager.GetScreenRectangle(), GuiManager.FadeTexture);
		}
	}
	
}
