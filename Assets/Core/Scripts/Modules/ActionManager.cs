using System.Collections.Generic;
using UnityEngine;

//
// ActionManager - Module class
//
// TODO: write class description
//
public static class ActionManager {
	
	public static void Look(InteractiveObject interactiveObject) {
		// TODO

		Vector2 position = interactiveObject.transform.position;

		Queue<CharacterAction> actions = new Queue<CharacterAction>();
		actions.Enqueue(new CharacterAction(C.CHARACTER_ACTION_LOOK, position));
		actions.Enqueue(new CharacterAction(C.CHARACTER_ACTION_WALK, position));
		actions.Enqueue(new CharacterAction(C.CHARACTER_ACTION_SAY, /* TODO */));

		Character playerCharacter = CharacterManager.GetPlayerCharacter();

		// TODO: send actions somehow
		playerCharacter.ExecuteActions(actions);
	}

	public static void LookQuick(InteractiveObject interactiveObject) {
		// TODO
		
		Vector2 position = interactiveObject.transform.position;
		
		Queue<CharacterAction> actions = new Queue<CharacterAction>();
		actions.Enqueue(new CharacterAction(C.CHARACTER_ACTION_LOOK, position));
		actions.Enqueue(new CharacterAction(C.CHARACTER_ACTION_SAY, /* TODO */));
		
		Character playerCharacter = CharacterManager.GetPlayerCharacter();
		
		// TODO: send actions somehow
		playerCharacter.ExecuteActions(actions);
	}
	
}
