using System.Collections;
using UnityEngine;

public class MainMenuLoader : MonoBehaviour {

	public void Start() {
		// Starts a coroutine to load resources and assets
		StartCoroutine(LoadCoroutine());
	}
	
	private IEnumerator LoadCoroutine() {
		yield break; // TODO
	}

}
