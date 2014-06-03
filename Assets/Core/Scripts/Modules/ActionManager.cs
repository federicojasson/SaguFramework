using System.Collections.Generic;
using UnityEngine;

//
// ActionManager - Module class
//
// TODO: write class description
//
public static class ActionManager {
	
	public static void Look(InteractiveObject interactiveObject, string text, AudioClip audio) {
		Vector2 gamePoint = CoordinatesManager.WorldToGamePoint(interactiveObject.transform.position);

		PlayerCharacterBehaviour playerCharacterBehaviour = CharacterManager.GetPlayerCharacter().GetBehaviour();
		Vector2 playerCharacterPoint = CoordinatesManager.WorldToGamePoint(playerCharacterBehaviour.transform.position);

		Queue<CharacterAction> actions = new Queue<CharacterAction>();
		actions.Enqueue(new CharacterAction(C.CHARACTER_ACTION_LOOK, gamePoint));

		if (Mathf.Abs(playerCharacterPoint.x - gamePoint.x) > C.LOOK_DISTANCE) {
			// The character is far away from the object

			Vector2 walkOffset = new Vector2(C.LOOK_DISTANCE, 0);
			if (playerCharacterPoint.x > gamePoint.x)
				// The character is at the right of the object
				actions.Enqueue(new CharacterAction(C.CHARACTER_ACTION_WALK, gamePoint + walkOffset));
			else
				// The character is at the left of the object
				actions.Enqueue(new CharacterAction(C.CHARACTER_ACTION_WALK, gamePoint - walkOffset));
		}

		actions.Enqueue(new CharacterAction(C.CHARACTER_ACTION_SAY, text, audio));
		
		playerCharacterBehaviour.ExecuteActions(actions);
	}

	public static void LookQuick(InteractiveObject interactiveObject, string text, AudioClip audio) {
		Vector2 gamePoint = CoordinatesManager.WorldToGamePoint(interactiveObject.transform.position);
		
		Queue<CharacterAction> actions = new Queue<CharacterAction>();
		actions.Enqueue(new CharacterAction(C.CHARACTER_ACTION_LOOK, gamePoint));
		actions.Enqueue(new CharacterAction(C.CHARACTER_ACTION_SAY, text, audio));
		
		CharacterManager.GetPlayerCharacter().GetBehaviour().ExecuteActions(actions);
	}

	public static void Walk(Vector2 gamePoint) {
		Queue<CharacterAction> actions = new Queue<CharacterAction>();
		actions.Enqueue(new CharacterAction(C.CHARACTER_ACTION_LOOK, gamePoint));
		actions.Enqueue(new CharacterAction(C.CHARACTER_ACTION_WALK, gamePoint));

		CharacterManager.GetPlayerCharacter().GetBehaviour().ExecuteActions(actions);
	}
	
}
