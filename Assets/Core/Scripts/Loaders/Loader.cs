using System;
using System.Collections;
using UnityEngine;

namespace SaguFramework {

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

		public void UnloadScene(Action onUnloadSceneAction) {
			// Starts a coroutine to unload the scene in a non-blocking way and execute an action afterwards
			StartCoroutine(UnloadSceneAndExecuteActionCoroutine(onUnloadSceneAction));
		}

		protected abstract IEnumerator LoadSceneCoroutine();
		
		protected abstract IEnumerator UnloadSceneCoroutine();

		private IEnumerator UnloadSceneAndExecuteActionCoroutine(Action onUnloadSceneAction) {
			// Unloads the scene
			yield return StartCoroutine(UnloadSceneCoroutine());

			// Executes the action
			onUnloadSceneAction.Invoke();
		}

	}

}
