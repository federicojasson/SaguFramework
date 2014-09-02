using System.Collections;
using UnityEngine;

namespace SaguFramework {

	public abstract class Loader : MonoBehaviour {
		
		public void Awake() {
			Objects.RegisterLoader(this);
		}
		
		public void ChangeScene(string id) {
			StartCoroutine(ChangeSceneCoroutine(id));
		}
		
		public void OnDestroy() {
			Objects.UnregisterLoader();
		}

		public void Start() {
			StartCoroutine(LoadSceneCoroutine());
		}

		protected abstract IEnumerator LoadSceneCoroutine();
		
		protected abstract IEnumerator UnloadSceneCoroutine();
		
		private IEnumerator ChangeSceneCoroutine(string id) {
			yield return StartCoroutine(UnloadSceneCoroutine());
			Application.LoadLevel(id);
		}

	}

}
