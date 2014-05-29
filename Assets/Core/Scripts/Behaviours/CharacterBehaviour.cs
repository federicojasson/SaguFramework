using System.Collections.Generic;

public partial class CharacterBehaviour : InteractiveObject {
	
	private string currentCoroutine;
	private bool isIdle;
	private Queue<CharacterAction> scheduledActions;
	
	public void Awake() {
		isIdle = true;
		scheduledActions = new Queue<CharacterAction>();
	}
	
	public void ExecuteActions(Queue<CharacterAction> actions) {
		// Stops the currently executing coroutines
		StopAllCoroutines();

		if (scheduledActions.Count > 0)
			// There are some unexecuted scheduled actions
			scheduledActions.Clear();

		isIdle = true;
		scheduledActions = actions;
	}

	public void Update() {
		if (scheduledActions.Count > 0 && isIdle)
			ExecuteScheduledAction();
	}

	private void ExecuteScheduledAction() {
		isIdle = false;

		CharacterAction action = scheduledActions.Dequeue();
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
	}

}
