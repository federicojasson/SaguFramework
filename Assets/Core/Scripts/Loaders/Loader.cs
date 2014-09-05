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
		
		protected IEnumerator FadeInCoroutine(FadeParameters fadeParameters) {
			if (fadeParameters.Ignore)
				yield break;

			Masker masker = Masker.GetInstance();
			masker.SetFadeTexture(fadeParameters.Texture);
			masker.SetFadeSpeed(- fadeParameters.Speed);
			
			while (masker.GetFadeTextureOpacity() > 0)
				if (masker.GetFadeSpeed() >= 0)
					yield break;
			else
				yield return null;
			
			masker.SetFadeSpeed(0);
		}
		
		protected IEnumerator FadeOutCoroutine(FadeParameters fadeParameters) {
			if (fadeParameters.Ignore)
				yield break;

			Masker masker = Masker.GetInstance();
			masker.SetFadeTexture(fadeParameters.Texture);
			masker.SetFadeSpeed(fadeParameters.Speed);
			
			while (masker.GetFadeTextureOpacity() < 1)
				if (masker.GetFadeSpeed() <= 0)
					yield break;
			else
				yield return null;
			
			masker.SetFadeSpeed(0);
		}

		protected abstract IEnumerator LoadSceneCoroutine();
		
		protected abstract IEnumerator UnloadSceneCoroutine();
		
		private IEnumerator ChangeSceneCoroutine(string id) {
			yield return StartCoroutine(UnloadSceneCoroutine());
			Application.LoadLevel(id);
		}

	}

}
