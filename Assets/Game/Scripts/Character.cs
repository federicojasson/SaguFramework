using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	// TODO
	private Queue<CharacterAction> scheduledActions;

	public void CancelScheduledActions() {
		scheduledActions.Clear();

		// TODO: should also cancel the current action
	}

	public void ScheduleAction(int actionId, params object[] parameters) {
		CharacterAction action = new CharacterAction(this, actionId, parameters);
		scheduledActions.Enqueue(action);
		CheckScheduledActions();
	}

	private void CheckScheduledActions() {
		// TODO: execute next scheduled action
	}

	public void Awake() {
		scheduledActions = new Queue<CharacterAction>();
	}



	public float walkSpeed = 2;
	
	public void Look(Vector2 position) {
		if (position.x - transform.position.x > 0)
			GetComponent<Animator>().SetBool("FacingLeft", false);
		else
			GetComponent<Animator>().SetBool("FacingLeft", true);
	}
	
	public void Say(Speech speech) {
		GetComponent<Animator>().SetBool("IsSaying", true);
		
		Vector2 position = Utility.FromWorldToViewportPosition((Vector2) transform.position + new Vector2(0, GetComponent<BoxCollider2D>().size.y / 2) + P.OFFSET_SPEECH_TEXT);
		Factory.GetSpeechText(speech.GetText(), position);
		
		audio.clip = speech.GetAudio();
		audio.Play();
		
		Invoke("SayCallback", audio.clip.length);
	}
	
	public void Walk(Vector2 position) {
		Look(position);
		StopCoroutine("WalkCoroutine");
		StartCoroutine("WalkCoroutine", position);
	}
	
	private void SayCallback() {
		Factory.DisposeSpeechText();
		audio.Stop();
		
		GetComponent<Animator>().SetBool("IsSaying", false);
	}
	
	private IEnumerator WalkCoroutine(Vector2 position) {
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
		
		GetComponent<Animator>().SetBool("IsWalking", false);
	}
	
}
