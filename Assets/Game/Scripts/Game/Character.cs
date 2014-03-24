using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	// TODO: maybe add semaphores to access???? is it necessary?
	private Queue<CharacterAction> scheduledActions;

	public void Awake() {
		scheduledActions = new Queue<CharacterAction>();
	}

	public void CancelScheduledActions() {
		scheduledActions.Clear();

		// TODO: cancel current action
	}

	public void Look(Vector2 position) {
		CharacterAction action = new CharacterAction(P.CHARACTER_ACTION_LOOK, position);
		scheduledActions.Enqueue(action);
	}

	public void Say(Speech speech) {
		CharacterAction action = new CharacterAction(P.CHARACTER_ACTION_SAY, speech);
		scheduledActions.Enqueue(action);
	}

	public void Walk(Vector2 position) {
		CharacterAction action = new CharacterAction(P.CHARACTER_ACTION_WALK, position);
		scheduledActions.Enqueue(action);
	}

	private void ExecuteNextScheduledAction() {
		CharacterAction action = scheduledActions.Dequeue();

		switch (action.GetId()) {
			case P.CHARACTER_ACTION_LOOK : {
				// TODO
				break;
			}
			
			case P.CHARACTER_ACTION_SAY : {
				// TODO
				break;
			}
			
			case P.CHARACTER_ACTION_WALK : {
				// TODO
				break;
			}
		}
	}

	/*// TODO: maybe add semaphores to access???? is it necessary?
	private bool executingAction;
	private Queue<CharacterAction> scheduledActions;

	public void CancelScheduledActions() {
		scheduledActions.Clear();

		if (executingAction)
			;// TODO: should also cancel the current action
	}

	public void ScheduleAction(int actionId, params object[] parameters) {
		CharacterAction action = new CharacterAction(this, actionId, parameters);
		scheduledActions.Enqueue(action);
		ExecuteNextScheduledAction();
	}

	private void ExecuteNextScheduledAction() {
		if (! executingAction && scheduledActions.Count > 0) {
			CharacterAction action = scheduledActions.Dequeue();
			action.Execute();
		}
	}

	public void Awake() {
		executingAction = false;
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
		executingAction = true;
		GetComponent<Animator>().SetBool("IsSaying", true);

		Factory.GetSpeechText(speech.GetText(), this);
		
		audio.clip = speech.GetAudio();
		audio.Play();
		
		Invoke("SayCallback", audio.clip.length);
	}
	
	public void Walk(Vector2 position) {
		executingAction = true;
		Look(position);
		StopCoroutine("WalkCoroutine");
		StartCoroutine("WalkCoroutine", position);
	}
	
	private void SayCallback() {
		Factory.DisposeSpeechText();
		audio.Stop();
		
		GetComponent<Animator>().SetBool("IsSaying", false);
		executingAction = false;
		ExecuteNextScheduledAction();
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
		executingAction = false;
		ExecuteNextScheduledAction();
	}*/
	
}
