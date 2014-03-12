using UnityEngine;

public class SceneTeleporter : InteractiveObject {

	public string target;
	private float doubleClickStartTime;

	public void Awake() {
		doubleClickStartTime = -P.DOUBLE_CLICK_SENSITIVITY;
	}
	
	public void OnMouseDown() {
		if ((Time.time - doubleClickStartTime) < P.DOUBLE_CLICK_SENSITIVITY) {
			doubleClickStartTime = -P.DOUBLE_CLICK_SENSITIVITY;
			OnDoubleClick();
		} else {
			doubleClickStartTime = Time.time;
			onSingleClick();
		}
	}

	public override void OnMouseEnter() {
		base.OnMouseEnter();
		InputManager.SetAction(P.SPECIAL_ACTION_TELEPORT);
	}
	
	public override void OnMouseExit() {
		base.OnMouseExit();
		InputManager.SetPreviousAction();
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		Application.LoadLevel(target);
	}
	
	private void OnDoubleClick() {
		Application.LoadLevel(target);
	}
	
	private void onSingleClick() {
		Game.instance.playerCharacter.Walk(transform.position.x);
	}
	
}
