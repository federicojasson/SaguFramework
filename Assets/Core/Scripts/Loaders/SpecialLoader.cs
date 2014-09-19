using System.Collections;

namespace SaguFramework {
	
	public sealed class SpecialLoader : Loader {

		// TODO

		protected override IEnumerator LoadSceneCoroutine() {
			yield return StartCoroutine(Drawer.FadeIn(Parameters.GetSpecialLoaderParameters().FadeIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(Drawer.FadeOut(Parameters.GetSpecialLoaderParameters().FadeOut));
		}

	}
	
}
