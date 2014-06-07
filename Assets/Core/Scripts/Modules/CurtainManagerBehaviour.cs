using System.Collections;
using UnityEngine;

public class CurtainManagerBehaviour : MonoBehaviour {

	public Texture2D fadeTexture;
	private float alphaChannelValue;
	private float fadeSpeed;
	
	public void Awake() {
		enabled = false;
		CurtainManager.SetBehaviour(this);
	}
	
	public IEnumerator FadeInCoroutine() {
		alphaChannelValue = 1;
		fadeSpeed = Configurations.CURTAIN_FADE_IN_SPEED;
		enabled = true;
		
		while (alphaChannelValue > 0)
			yield return null;
		
		enabled = false;
	}
	
	public IEnumerator FadeOutCoroutine() {
		alphaChannelValue = 0;
		fadeSpeed = Configurations.CURTAIN_FADE_OUT_SPEED;
		enabled = true;
		
		while (alphaChannelValue < 1)
			yield return null;
		
		enabled = false;
	}

	public void OnGUI() {
		alphaChannelValue += fadeSpeed * Time.deltaTime;
		float clampedAlphaChannelValue = Mathf.Clamp01(alphaChannelValue);

		// TODO: draw the texture (using the clamped value)
	}
	
}
