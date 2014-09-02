using System.Collections;

namespace SaguFramework {
	
	public class SpecialLoader : Loader {

		protected override IEnumerator LoadSceneCoroutine() {
			// TODO

			// Fades in
			yield return StartCoroutine(Masker.GetInstance().FadeInCoroutine(ParameterManager.GetSpecialLoaderParameters().FadingIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			// Fades out
			yield return StartCoroutine(Masker.GetInstance().FadeOutCoroutine(ParameterManager.GetSpecialLoaderParameters().FadingOut));
		}

	}
	
}
