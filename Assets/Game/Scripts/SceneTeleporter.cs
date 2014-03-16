/*using UnityEngine;

public class SceneTeleporter : InteractiveObject {

	public string target;
	private float doubleClickStartTime;

	public void Awake() {
		doubleClickStartTime = -P.DELAY_DOUBLE_CLICK;
	}

	public override void OnMouseDown() {
		if ((Time.time - doubleClickStartTime) < P.DELAY_DOUBLE_CLICK) {
			doubleClickStartTime = -P.DELAY_DOUBLE_CLICK;
			OnDoubleClick();
		} else {
			doubleClickStartTime = Time.time;
			OnSingleClick();
		}
	}

	public override void OnMouseEnter() {
		base.OnMouseEnter();
		CursorManager.DeactivateInputCheck();
		CursorManager.SetAction(P.ACTION_TELEPORT);
	}

	public override void OnMouseExit() {
		base.OnMouseExit();
		CursorManager.SetAction(CursorManager.GetPreviousAction());
		CursorManager.ActivateInputCheck();
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		Application.LoadLevel(target);
	}

	private void OnDoubleClick() {
		Application.LoadLevel(target);
	}
	
	private void OnSingleClick() {
		Game.GetPlayerCharacter().Walk(Utility.ToVector2(transform.position));
	}

}*/
