using System.Collections;
using UnityEngine;

public class RoomLoader : MonoBehaviour {
	
	public void Start() {
		StartCoroutine(LoadCoroutine());
	}
	
	private IEnumerator LoadCoroutine() {
		Timer timer = FactoryModule.CreateTimer();
		timer.RegisterStartTime();
		
		IEnumerator fadeInCoroutine = CurtainModule.GetFadeInCoroutine(ConfigurationModule.roomCurtainFadeInSpeed);
		yield return StartCoroutine(fadeInCoroutine);
		
		// TODO: load resources here
		
		float minimumDelayTime = ConfigurationModule.roomMinimumDelayTime;
		yield return StartCoroutine(timer.WaitForAtLeastSecondsCoroutine(minimumDelayTime));
		
		IEnumerator fadeOutCoroutine = CurtainModule.GetFadeOutCoroutine(ConfigurationModule.roomCurtainFadeOutSpeed);
		yield return StartCoroutine(fadeOutCoroutine);
	}
	
}
