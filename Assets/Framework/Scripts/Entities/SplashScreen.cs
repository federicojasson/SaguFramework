using System.Collections;
using UnityEngine;

namespace SaguFramework {

	/// A splash screen.
	public sealed class SplashScreen : Entity {

		private float creationTime; // The creation time
		private float minimumDelayTime; // The minimum delay time

		public override void Awake() {
			base.Awake();

			// Registers the creation time
			creationTime = Time.time;
		}

		/// Delays the execution until reaching the minimum delay time.
		public IEnumerator Delay() {
			// Gets the current time and calculates the elapsed time
			float currentTime = Time.time;
			float elapsedTime = currentTime - creationTime;
			
			if (elapsedTime < minimumDelayTime)
				// The minimum delay time has not been reached yet
				yield return new WaitForSeconds(minimumDelayTime - elapsedTime);
		}

		/// Sets the minimum delay time.
		public void SetMinimumDelayTime(float minimumDelayTime) {
			this.minimumDelayTime = minimumDelayTime;
		}

		public void Update() {
			// Follows the camera
			SetPosition(CameraHandler.GetCameraPosition());
		}

	}
	
}
