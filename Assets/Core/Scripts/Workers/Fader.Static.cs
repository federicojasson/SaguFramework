using System.Collections;
using UnityEngine;

public partial class Fader : MonoBehaviour {
	
	private static Fader instance; // Singleton instance

	public static IEnumerator FadeInCoroutine(float speed, Sprite sprite) {
		// Sets the fade speed and sprite
		instance.fadeSpeed = - speed;
		instance.fadeImage.SetSprite(sprite);
		
		while (instance.fadeImage.GetOpacity() > 0)
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
		instance.fadeImage.SetSprite(sprite);
		
		while (instance.fadeImage.GetOpacity() < 1)
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
