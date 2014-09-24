using System.Collections;
using UnityEngine;

namespace SaguFramework {

	/// A splash screen.
	public sealed class SplashScreen : Entity {

		private float creationTime; // The splash screen's creation time
		private float minimumDelayTime; // The splash screen's minimum delay time

		public override void Awake() {
			base.Awake();

			// Registers the creation time
			creationTime = Time.time;
		}

		/// Delays the execution until reaching the minimum delay time.
		public IEnumerator Delay() {
			// Gets the current time
			float currentTime = Time.time;

			// Calculates the elapsed time
			float elapsedTime = currentTime - creationTime;
			
			if (elapsedTime < minimumDelayTime)
				// The minimum delay time has not been reached yet
				yield return new WaitForSeconds(minimumDelayTime - elapsedTime);
		}

		/// Returns the splash screen's creation time.
		public float GetCreationTime() {
			return creationTime;
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
