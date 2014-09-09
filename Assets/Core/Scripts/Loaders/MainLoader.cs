using System.Collections;

namespace SaguFramework {
	
	public class MainLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			// TODO
			Loader.ChangeScene(Parameters.SceneRoom);

			yield break;
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield break;
		}

	}
	
}
