using System.Collections;
using UnityEngine;

namespace FrameworkNamespace {

	public partial class Fader : MonoBehaviour {
		
		private static Fader instance; // Singleton instance

		public static IEnumerator FadeInCoroutine(float speed, Texture2D texture) {
			// Sets the fade speed and texture
			instance.fadeSpeed = - speed;
			instance.fadeTexture = texture;
			
			while (instance.fadeTextureOpacity > 0)
				if (instance.fadeSpeed >= 0)
					// The fade speed has been reverted, so the coroutine has to end
					yield break;
				else
					// Waits until the fade texture's opacity is lower than 0
					yield return null;

			// Stops the fade-in
			instance.fadeSpeed = 0;
		}

		public static IEnumerator FadeOutCoroutine(float speed, Texture2D texture) {
			// Sets the fade speed and texture
			instance.fadeSpeed = speed;
			instance.fadeTexture = texture;
			
			while (instance.fadeTextureOpacity < 1)
				if (instance.fadeSpeed <= 0)
					// The fade speed has been reverted, so the coroutine has to end
					yield break;
				else
					// Waits until the fade texture's opacity is greater than 0
					yield return null;
			
			// Stops the fade-out
			instance.fadeSpeed = 0;
		}

	}

}
