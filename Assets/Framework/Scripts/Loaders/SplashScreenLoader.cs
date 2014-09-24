using System.Collections;

namespace SaguFramework {

	/// Loader of the splash screen scene.
	/// Tasks:
	/// - Show random splash screen.
	public sealed class SplashScreenLoader : Loader {
		
		/// Performs the loading tasks.
		protected override IEnumerator LoadSceneCoroutine() {
			// Shows a random splash screen from the current group
			SplashScreenManager.ShowSplashScreenFromCurrentGroup();

			// Fades in
			yield return StartCoroutine(Drawer.FadeIn(Parameters.GetSplashScreenLoaderParameters().FadeIn));

			// Delays the execution to show the splash screen
			yield return StartCoroutine(SplashScreenManager.Delay());

			// Changes to the room scene
			Loader.ChangeScene(Parameters.SceneRoom);
		}
		
		/// Performs the unloading tasks.
		protected override IEnumerator UnloadSceneCoroutine() {
			// Fades out
			yield return StartCoroutine(Drawer.FadeOut(Parameters.GetSplashScreenLoaderParameters().FadeOut));
		}

	}
	
}
