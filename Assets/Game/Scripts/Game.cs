using UnityEngine;

public class Game : MonoBehaviour {

	public static Game instance;
	public PlayerCharacter playerCharacter;
	public Texture2D lookCursorTexture;
	public Texture2D walkCursorTexture;
	public Texture2D teleportCursorTexture;
	private int previousAction;
	private int currentAction;

	public void Awake() {
		instance = this;
		previousAction = P.ACTION_WALK;
		currentAction = P.ACTION_WALK;
	}

	public int GetCurrentAction() {
		return currentAction;
	}

	public void SetAction(int action) {
		previousAction = currentAction;
		currentAction = action;
		CursorManager.UpdateCursor();
	}
	
	public void SetNextAction() {
		if (! SpecialActionSet())
			SetAction((currentAction + 1) % P.ACTIONS);
	}
	
	public void SetPreviousAction() {
		SetAction(previousAction);
	}

	public void Update() {
		InputManager.CheckInput();
	}

	private bool SpecialActionSet() {
		return currentAction >= P.ACTIONS;
	}

}
