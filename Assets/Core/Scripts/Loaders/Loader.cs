using System.Collections;
using UnityEngine;

namespace SaguFramework {
	
	public abstract class Loader : MonoBehaviour {

		private static Loader instance;

		public static void ChangeScene(string sceneId) {
			instance.StartCoroutine(instance.ChangeSceneCoroutine(sceneId));
		}

		public void Awake() {
			instance = this;
		}

		public void Start() {
			StartCoroutine(LoadSceneCoroutine());
		}

		protected abstract IEnumerator LoadSceneCoroutine();
		
		protected abstract IEnumerator UnloadSceneCoroutine();

		private IEnumerator ChangeSceneCoroutine(string sceneId) {
			yield return StartCoroutine(UnloadSceneCoroutine());
			Application.LoadLevel(sceneId);
		}

	}
	
}
