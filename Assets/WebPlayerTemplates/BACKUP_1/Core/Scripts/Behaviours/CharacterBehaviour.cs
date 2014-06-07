using System.Collections.Generic;

public abstract partial class CharacterBehaviour : InteractiveObject {
	
	private string currentCoroutine;
	private bool isIdle;
	private Queue<CharacterAction> scheduledActions;
	
	public void Awake() {
		isIdle = true;
		scheduledActions = new Queue<CharacterAction>();
	}
	
	public void ExecuteActions(Queue<CharacterAction> actions) {
		if (scheduledActions.Count > 0) {
			// Stops the currently executing coroutine
			StopAllCoroutines();

			// Executes the currently executing coroutine callback function
			switch (scheduledActions.Peek().GetId()) {
				case C.CHARACTER_ACTION_LOOK : {
					ExecuteLookCoroutineCallback();
					break;
				}
					
				case C.CHARACTER_ACTION_SAY : {
					ExecuteSayCoroutineCallback();
					break;
				}
					
				case C.CHARACTER_ACTION_WALK : {
					ExecuteWalkCoroutineCallback();
					break;
				}
			}

			// Clears the scheduled actions
			scheduledActions.Clear();
		}

		isIdle = true;
		scheduledActions = actions;
	}

	public void Update() {
		if (scheduledActions.Count > 0 && isIdle)
			ExecuteScheduledAction();
	}

	private void ExecuteScheduledAction() {
		isIdle = false;
		CharacterAction action = scheduledActions.Peek();
		object[] parameters = action.GetParameters();
		
		switch (action.GetId()) {
			case C.CHARACTER_ACTION_LOOK : {
				ExecuteLook(parameters);
				break;
			}
			
			case C.CHARACTER_ACTION_SAY : {
				ExecuteSay(parameters);
				break;
			}
			
			case C.CHARACTER_ACTION_WALK : {
				ExecuteWalk(parameters);
				break;
			}
		}
	}

	private void OnScheduledActionFinished() {
		isIdle = true;
		scheduledActions.Dequeue();
	}

}
