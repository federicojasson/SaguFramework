using System.Collections;
using UnityEngine;

public partial class DisplayEffector : MonoBehaviour {
	
	private static DisplayEffector instance; // Singleton instance

	public static IEnumerator FadeInCoroutine(float speed, Sprite sprite) {
		// Sets the fade speed and sprite
		instance.fadeSpeed = - speed;
		instance.spriteRenderer.sprite = sprite;
		
		while (instance.spriteRenderer.color.a > 0)
			if (instance.fadeSpeed >= 0)
				// The fade speed has been reverted, so the coroutine has to end
				yield break;
			else
				// Waits until the fade sprite's opacity is lower than 0
				yield return null;

		// Stops the fade-in
		instance.fadeSpeed = 0;
	}

	public static IEnumerator FadeOutCoroutine(float speed, Sprite sprite) {
		// Sets the fade speed and sprite
		instance.fadeSpeed = speed;
		instance.spriteRenderer.sprite = sprite;
		
		while (instance.spriteRenderer.color.a < 1)
			if (instance.fadeSpeed <= 0)
				// The fade speed has been reverted, so the coroutine has to end
				yield break;
			else
				// Waits until the fade sprite's opacity is greater than 0
				yield return null;
		
		// Stops the fade-out
		instance.fadeSpeed = 0;
	}

}
