using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour {

	private float startTime;

	public void RegisterStartTime() {
		startTime = Time.time;
	}

	public IEnumerator WaitForAtLeastSecondsCoroutine(float minimumDelayTime) {
		float currentTime = Time.time;
		float elapsedTime = currentTime - startTime;

		if (elapsedTime < minimumDelayTime)
			yield return new WaitForSeconds(minimumDelayTime - elapsedTime);

		Destroy(gameObject);
	}
	
}
