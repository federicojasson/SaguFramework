using System;
using System.Collections;
using UnityEngine;

namespace FrameworkNamespace {

	public abstract class Loader : MonoBehaviour {

		public void Awake() {
			SceneManager.SetCurrentLoader(this);
		}

		public void Start() {
			StartCoroutine(LoadSceneCoroutine());
		}
		
		public void UnloadScene(Action onUnloadSceneAction) {
			StartCoroutine(UnloadSceneAndInvokeActionCoroutine(onUnloadSceneAction));
		}
		
		protected abstract IEnumerator LoadSceneCoroutine();

		protected abstract IEnumerator UnloadSceneCoroutine();

		private IEnumerator UnloadSceneAndInvokeActionCoroutine(Action onUnloadSceneAction) {
			yield return StartCoroutine(UnloadSceneCoroutine());
			onUnloadSceneAction.Invoke();
		}

	}

}
