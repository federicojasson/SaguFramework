using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour {

	private float startTime;

	public void RegisterStartTime() {
		startTime = Time.time;
	}

	public IEnumerator WaitForAtLeastSecondsCoroutine(float minDelay) {
		float currentTime = Time.time;
		float timeInterval = currentTime - startTime;

		if (timeInterval < minDelay) {
			yield return new WaitForSeconds(minDelay - timeInterval);
		}

		Destroy(gameObject);
	}
	
}
