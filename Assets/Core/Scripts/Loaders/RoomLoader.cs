using System.Collections;
using UnityEngine;

public class RoomLoader : MonoBehaviour {
	
	public void Start() {
		StartCoroutine(LoadCoroutine());
	}
	
	private IEnumerator LoadCoroutine() {
		StateManager.CreateCurrentRoom();

		float fadeInSpeed = ConfigurationManager.RoomCurtainFadeInSpeed;
		yield return StartCoroutine(CurtainManager.FadeInCoroutine(fadeInSpeed));
	}
	
}
