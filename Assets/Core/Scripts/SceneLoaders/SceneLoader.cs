using System.Collections;
using UnityEngine;

public abstract class SceneLoader : MonoBehaviour {

	public void Awake() {
		SceneManager.SetCurrentSceneLoader(this);
	}
	
	public abstract void OnUnloadScene();

	public void Start() {
		StartCoroutine(LoadSceneCoroutine());
	}
	
	protected abstract IEnumerator LoadSceneCoroutine();

}
