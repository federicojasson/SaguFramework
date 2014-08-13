using System.Collections;
using UnityEngine;

public class RoomLoader : MonoBehaviour {
	
	public void Start() {
		StartCoroutine(LoadCoroutine());
	}
	
	private IEnumerator LoadCoroutine() {
		Timer timer = HelperModule.CreateTimer();
		timer.RegisterStartTime();
		
		IEnumerator fadeInCoroutine = CurtainModule.FadeInCoroutine(Configuration.RoomCurtainFadeInSpeed);
		yield return StartCoroutine(fadeInCoroutine);
		
		// TODO: load resources here
		
		float minimumDelayTime = Configuration.RoomMinimumDelayTime;
		yield return StartCoroutine(timer.WaitForAtLeastSecondsCoroutine(minimumDelayTime));
		
		IEnumerator fadeOutCoroutine = CurtainModule.FadeOutCoroutine(Configuration.RoomCurtainFadeOutSpeed);
		yield return StartCoroutine(fadeOutCoroutine);
	}
	
}
