using UnityEngine;

public static class SceneManager {

	private static SceneLoader currentSceneLoader;
	
	public static void LoadScene(string scene) {
		currentSceneLoader.OnUnloadScene();
		Application.LoadLevel(scene);
	}

	public static void SetCurrentSceneLoader(SceneLoader sceneLoader) {
		currentSceneLoader = sceneLoader;
	}

}
