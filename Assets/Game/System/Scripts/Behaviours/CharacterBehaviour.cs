using System.Collections.Generic;
using UnityEngine;

public partial class CharacterBehaviour : InteractiveObject {

	private Queue<CharacterAction> scheduledActions;

	public void Awake() {
		scheduledActions = new Queue<CharacterAction>();
	}

	public void CancelScheduledActions() {
		scheduledActions.Clear();

		// TODO: cancel current action
	}

	public void Look(Vector2 position) {
		CharacterAction action = new CharacterAction(P.ACTION_LOOK, position);
		scheduledActions.Enqueue(action);
	}
	
	public void Say(Speech speech) {
		CharacterAction action = new CharacterAction(P.ACTION_SAY, speech);
		scheduledActions.Enqueue(action);
	}
	
	public void Walk(Vector2 position) {
		CharacterAction action = new CharacterAction(P.ACTION_WALK, position);
		scheduledActions.Enqueue(action);
	}

	/*public float walkSpeed = 2;
	private CharacterAction currentAction;
	private bool isIdle;
	private Queue<CharacterAction> scheduledActions; // TODO: maybe add semaphores to access???? is it necessary?

	public void Awake() {
		currentAction = null;
		isIdle = true;
		scheduledActions = new Queue<CharacterAction>();
	}

	public void CancelScheduledActions() {
		scheduledActions.Clear();

		if (! isIdle)
			switch (currentAction.GetId()) {
				case P.CHARACTER_ACTION_LOOK : {
					StopCoroutine("ExecuteLookCoroutine");
					ExecuteLookCallback();
					break;
				}
				
				case P.CHARACTER_ACTION_SAY : {
					StopCoroutine("ExecuteSayCoroutine");
					ExecuteSayCallback();
					break;
				}
				
				case P.CHARACTER_ACTION_WALK : {
					StopCoroutine("ExecuteWalkCoroutine");
					ExecuteWalkCallback();
					break;
				}
			}
	}

	public void Look(Vector2 position) {
		CharacterAction action = new CharacterAction(P.CHARACTER_ACTION_LOOK, position);
		scheduledActions.Enqueue(action);

		if (isIdle)
			ExecuteNextScheduledAction();
	}

	public void Say(Speech speech) {
		CharacterAction action = new CharacterAction(P.CHARACTER_ACTION_SAY, speech);
		scheduledActions.Enqueue(action);

		if (isIdle)
			ExecuteNextScheduledAction();
	}

	public void Walk(Vector2 position) {
		CharacterAction action = new CharacterAction(P.CHARACTER_ACTION_WALK, position);
		scheduledActions.Enqueue(action);

		if (isIdle)
			ExecuteNextScheduledAction();
	}

	private void ExecuteNextScheduledAction() {
		if (scheduledActions.Count == 0)
			return;

		currentAction = scheduledActions.Dequeue();
		isIdle = false;
		object[] parameters = currentAction.GetParameters();

		switch (currentAction.GetId()) {
			case P.CHARACTER_ACTION_LOOK : {
				ExecuteLook((Vector2) parameters[0]);
				break;
			}
			
			case P.CHARACTER_ACTION_SAY : {
				ExecuteSay((Speech) parameters[0]);
				break;
			}
			
			case P.CHARACTER_ACTION_WALK : {
				ExecuteWalk((Vector2) parameters[0]);
				break;
			}
		}
	}*/

}
