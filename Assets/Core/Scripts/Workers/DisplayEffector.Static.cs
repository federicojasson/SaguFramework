using System.Collections;
using UnityEngine;

public partial class DisplayEffector : MonoBehaviour {
	
	private static DisplayEffector instance; // Singleton instance

	public static IEnumerator FadeInCoroutine(float fadeSpeed, Sprite fadeSprite) {
		// Sets the fade speed and texture
		instance.fadeSpeed = - fadeSpeed;
		instance.fadeTexture = fadeTexture;
		
		while (instance.fadeTextureAlphaValue > 0)
			if (instance.fadeSpeed >= 0)
				// The fade speed has been reverted, so the coroutine has to end
				yield break;
			else
				// Waits until the fade texture's alpha value is lower than 0
				yield return null;

		// Stops the fade-in
		instance.fadeSpeed = 0;
		instance.fadeTextureAlphaValue = 0;
	}

	public static IEnumerator FadeOutCoroutine(float fadeSpeed, Sprite fadeSprite) {
		// Sets the fade speed and texture
		instance.fadeSpeed = fadeSpeed;
		instance.fadeTexture = fadeTexture;
		
		while (instance.fadeTextureAlphaValue < 1)
			if (instance.fadeSpeed <= 0)
				// The fade speed has been reverted, so the coroutine has to end
				yield break;
			else
				// Waits until the fade texture's alpha value is greater than 0
				yield return null;
		
		// Stops the fade-out
		instance.fadeSpeed = 0;
		instance.fadeTextureAlphaValue = 1;
	}

}
