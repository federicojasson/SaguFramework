using System.Collections;

namespace SaguFramework {
	
	public class SpecialLoader : Loader {

		protected override IEnumerator LoadSceneCoroutine() {
			yield break;
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield break;
		}

	}
	
}
