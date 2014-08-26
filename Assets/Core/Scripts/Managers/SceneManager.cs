using System;
using System.Collections;
using UnityEngine;

namespace FrameworkNamespace {

	public static class SceneManager {

		private static Loader currentLoader;
		
		public static void LoadScene(string scene) {
			GuiManager.ClearMenus();

			Action onUnloadSceneAction = () => {
				Application.LoadLevel(scene);
			};

			currentLoader.UnloadScene(onUnloadSceneAction);
		}

		public static void SetCurrentLoader(Loader loader) {
			currentLoader = loader;
		}

	}

}
