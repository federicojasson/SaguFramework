using System;
using System.Collections;
using UnityEngine;

namespace SaguFramework {

	public abstract class Loader : MonoBehaviour {

		public void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterLoader(this);
		}
		
		public void LoadScene(string sceneId) {
			// Starts a coroutine to unload the scene in a non-blocking way and load the new scene
			StartCoroutine(UnloadSceneAndLoadNewSceneCoroutine(sceneId));
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

		private IEnumerator UnloadSceneAndLoadNewSceneCoroutine(string sceneId) {
			// Unloads the scene
			yield return StartCoroutine(UnloadSceneCoroutine());

			// Loads the new scene
			Application.LoadLevel(sceneId);
		}

	}

}
