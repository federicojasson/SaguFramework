using System.Collections;
using UnityEngine;

namespace SaguFramework {
	
	public class SplashScreen : MonoBehaviour {

		private float creationTime;
		private float minimumDelayTime;
		
		public void Awake() {
			Objects.RegisterSplashScreen(this);
			Hide();
			creationTime = Time.time;
		}

		public IEnumerator Delay() {
			float currentTime = Time.time;
			float elapsedTime = currentTime - creationTime;
			
			if (elapsedTime < minimumDelayTime)
				yield return new WaitForSeconds(minimumDelayTime - elapsedTime);
		}
		
		public void Hide() {
			gameObject.SetActive(false);
		}
		
		public void OnDestroy() {
			Objects.UnregisterSplashScreen();
		}

		public void OnEnable() {
			SetPosition(GameCamera.GetInstance().GetPosition());
		}

		public void SetMinimumDelayTime(float minimumDelayTime) {
			this.minimumDelayTime = minimumDelayTime;
		}
		
		public void Show() {
			gameObject.SetActive(true);
		}

		private void SetPosition(Vector2 position) {
			transform.position = Utilities.GetPosition(position, transform.position.z);
		}

	}
	
}
