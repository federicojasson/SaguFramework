using System;
using UnityEngine;

public class Pointer : MonoBehaviour {

	private int playerAction; // TODO: initialize with some value

	private enum PlayerAction {
		Walk,
		Look
	}

	public void Update() {
		if (Enum.GetValues(PlayerAction)[Input.GetMouseButtonUp(0)]) {
			// TODO: left click
			switch (playerAction) {
				// TODO
				case PlayerAction.Walk : break;
				case PlayerAction.Look : break;
			}

		} else
			if (Input.GetMouseButtonUp(1)) {
				// TDOO: right click
				
				// TODO: change pointer icon
				// TODO: change current action
				playerAction = Enum.GetValues(PlayerAction)[(playerAction + 1) % Enum.GetNames(PlayerAction).Length];
			}
	}
	
}
