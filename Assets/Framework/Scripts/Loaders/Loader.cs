using System.Collections;
using UnityEngine;

namespace SaguFramework {

	/// Performs scene's loading and unloading tasks.
	/// The actual tasks are defined in the subclasses, as every scene has its own needs.
	public abstract class Loader : MonoBehaviour {

		private static Loader instance; // The current loader

		/// Changes the current scene.
		/// Receives the new scene's ID.
		public static void ChangeScene(string sceneId) {
			// Locks the input
			InputReader.LockInput();

			instance.StartCoroutine(instance.ChangeSceneCoroutine(sceneId));
		}

		public void Awake() {
			// Sets this loader as the current one
			instance = this;
		}

		public void Start() {
			// Loads the current scene
			StartCoroutine(LoadSceneCoroutine());
		}

		/// Performs the loading tasks.
		/// Each subclass must override this method to define the corresponding tasks.
		protected abstract IEnumerator LoadSceneCoroutine();

		/// Performs the unloading tasks.
		/// Each subclass must override this method to define the corresponding tasks.
		protected abstract IEnumerator UnloadSceneCoroutine();

		/// Unloads the current scene and, after that, loads the new one.
		/// Receives the new scene's ID.
		private IEnumerator ChangeSceneCoroutine(string sceneId) {
			yield return StartCoroutine(UnloadSceneCoroutine());
			Application.LoadLevel(sceneId);
		}

	}
	
}
