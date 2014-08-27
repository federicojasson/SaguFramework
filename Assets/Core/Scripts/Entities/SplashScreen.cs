using SaguFramework.Managers;
using UnityEngine;

namespace SaguFramework.Entities {
	
	public class SplashScreen : MonoBehaviour {

		public void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterSplashScreen(this);
		}

		public void OnDestroy() {
			// Unregisters itself from the ObjectManager
			ObjectManager.UnregisterSplashScreen();
		}

	}
	
}
