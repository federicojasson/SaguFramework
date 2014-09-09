using System.Collections;

namespace SaguFramework {
	
	public class SpecialLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			yield return StartCoroutine(FadeInCoroutine(Parameters.GetSpecialLoaderParameters().FadeIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(FadeOutCoroutine(Parameters.GetSpecialLoaderParameters().FadeOut));
		}

	}
	
}
