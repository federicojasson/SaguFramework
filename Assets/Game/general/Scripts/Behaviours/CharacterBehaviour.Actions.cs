using System.Collections;
using UnityEngine;

public partial class CharacterBehaviour : InteractiveObject {

	/*private void ExecuteLook(Vector2 position) {
		StartCoroutine("ExecuteLookCoroutine", position);
	}
	
	private void ExecuteLookCallback() {
		currentAction = null;
		isIdle = true;
		ExecuteNextScheduledAction();
	}
	
	private IEnumerator ExecuteLookCoroutine(Vector2 position) {
		bool facingLeft = transform.position.x > position.x;
		GetComponent<Animator>().SetBool("FacingLeft", facingLeft);

		ExecuteLookCallback();

		yield break;
	}

	private void ExecuteSay(Speech speech) {
		StartCoroutine("ExecuteSayCoroutine", speech);
	}
	
	private void ExecuteSayCallback() {
		GetComponent<Animator>().SetBool("IsSaying", false);
		Factory.DisposeSpeechText();
		audio.Stop();

		currentAction = null;
		isIdle = true;
		ExecuteNextScheduledAction();
	}
	
	private IEnumerator ExecuteSayCoroutine(Speech speech) {
		GetComponent<Animator>().SetBool("IsSaying", true);
		Factory.GetSpeechText(this, speech.GetText());
		audio.clip = speech.GetAudio();
		audio.Play();

		yield return new WaitForSeconds(audio.clip.length);

		ExecuteSayCallback();
	}

	private void ExecuteWalk(Vector2 position) {
		StartCoroutine("ExecuteWalkCoroutine", position);
	}
	
	private void ExecuteWalkCallback() {
		GetComponent<Animator>().SetBool("IsWalking", false);

		currentAction = null;
		isIdle = true;
		ExecuteNextScheduledAction();
	}
	
	private IEnumerator ExecuteWalkCoroutine(Vector2 position) {
		GetComponent<Animator>().SetBool("IsWalking", true);

		float positionX = position.x;
		float currentX = transform.position.x;
		
		while (! Utility.AreEqual(currentX, positionX, P.DELTA_WALK)) {
			rigidbody2D.velocity = new Vector2(Mathf.Sign(positionX - currentX) * walkSpeed, 0);
			yield return new WaitForFixedUpdate();
			
			float previousX = currentX;
			currentX = transform.position.x;
			
			if (Utility.AreEqual(previousX, currentX, P.DELTA_EQUAL))
				// The character stopped walking for some reason
				break;
		}

		ExecuteWalkCallback();
	}*/
	
}
