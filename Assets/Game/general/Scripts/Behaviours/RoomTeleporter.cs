using UnityEngine;

public class RoomTeleporter : InteractiveObject {

	/*public Room room;

	public override void OnDefocus() {
		base.OnDefocus();
		InputManager.ClearForcedAction();
	}

	public override void OnFocus() {
		base.OnFocus();
		InputManager.SetForcedAction(P.CURSOR_ACTION_TELEPORT);
	}

	public override void OnTeleport() {
		Character playerCharacter = Game.GetPlayerCharacter();
		Vector2 position = transform.position;

		playerCharacter.CancelScheduledActions();
		playerCharacter.Look(position);
		playerCharacter.Walk(position);
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		Application.LoadLevel(room.id);
	}*/

}

/*using UnityEngine;
// TODO
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
