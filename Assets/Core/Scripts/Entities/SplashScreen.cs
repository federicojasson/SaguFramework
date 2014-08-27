using System.Collections;
using UnityEngine;

namespace SaguFramework {
	
	public class SplashScreen : MonoBehaviour {

		private float creationTime;

		public void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterSplashScreen(this);

			// Sets itself as the game camera's passive target
			GameCamera.GetInstance().SetTarget(transform, false);

			// Registers the current time
			creationTime = Time.time;
		}

		public IEnumerator Delay(float minimumDelayTime) {
			float currentTime = Time.time;
			float elapsedTime = currentTime - creationTime;
			
			if (elapsedTime < minimumDelayTime)
				yield return new WaitForSeconds(minimumDelayTime - elapsedTime);
		}

		public void OnDestroy() {
			// Unregisters itself from the ObjectManager
			ObjectManager.UnregisterSplashScreen();
		}

	}
	
}
