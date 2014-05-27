using System.Collections.Generic;
using UnityEngine;

public class ActionCharacter : MonoBehaviour {

	private Queue<CharacterAction> scheduledActions;

	public void Awake() {
		scheduledActions = new Queue<CharacterAction>();
	}

	public void ExecuteActions(Queue<CharacterAction> actions) {
		if (scheduledActions.Count > 0)
			// There are some unexecuted scheduled actions
			scheduledActions.Clear();

		scheduledActions = actions;
	}

	public void Look(Vector2 position) {
		CharacterAction action = new CharacterAction(C.CHARACTER_ACTION_LOOK, position);
		scheduledActions.Enqueue(action);
	}
	
	public void Say(string text) {
		CharacterAction action = new CharacterAction(C.CHARACTER_ACTION_SAY, text);
		scheduledActions.Enqueue(action);
	}
	
	public void Walk(Vector2 position) {
		CharacterAction action = new CharacterAction(C.CHARACTER_ACTION_WALK, position);
		scheduledActions.Enqueue(action);
	}
	
}
