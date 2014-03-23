using System.Collections.Generic;
using UnityEngine;

public class CharacterAction {
	
	private int actionId;
	private Character character;
	private List<object> parameters;

	public CharacterAction(Character character, int actionId, params object[] parameters) {
		this.actionId = actionId;
		this.character = character;

		// TODO: do this here? or maybe use Utility to pack parameters?
		this.parameters = new List<object>();
		for (int i = 0; i < parameters.Length; ++i)
			this.parameters[i] = parameters[i];
	}

	public void Execute() {
		switch (actionId) {
			case P.CHARACTER_ACTION_LOOK : {
				character.Look((Vector2) parameters[0]);
				break;
			}
			
			case P.CHARACTER_ACTION_SAY : {
				character.Say((Speech) parameters[0]);
				break;
			}
			
			case P.CHARACTER_ACTION_WALK : {
				character.Walk((Vector2) parameters[0]);
				break;
			}
		}
	}

}
