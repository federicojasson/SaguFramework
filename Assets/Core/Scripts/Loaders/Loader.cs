using SaguFramework.Managers;
using System.Collections;
using UnityEngine;

namespace SaguFramework.Loaders {

	public abstract class Loader : MonoBehaviour {

		public void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterLoader(this);
		}

		public void OnDestroy() {
			// Unregisters itself from the ObjectManager
			ObjectManager.UnregisterLoader();
		}

		public void Start() {
			// Starts a coroutine to load the scene in a non-blocking way
			StartCoroutine(LoadSceneCoroutine());
		}

		protected abstract IEnumerator LoadSceneCoroutine();
		
		protected abstract IEnumerator UnloadSceneCoroutine();

	}

}
