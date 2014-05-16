using UnityEngine;

public class RoomTeleporter : InteractiveObject {

	public string cursorLabelTextId;
	public string targetRoomId;
	private string cursorLabelText;

	public void Awake() {
		cursorLabelText = LanguageManager.GetText(cursorLabelTextId);
	}

	public override void OnDefocus() {
		InputManager.ClearCursorLabel();
		InputManager.ClearForcedOrder();
	}
	
	public override void OnFocus() {
		InputManager.SetCursorLabel(cursorLabelText);
		InputManager.SetForcedOrder(P.ORDER_TELEPORT);
	}
	
	public override void OnOrderTeleport() {
		// TODO
		Debug.Log("teleport: " + targetRoomId);
	}
	
	public override void OnQuickOrderTeleport() {
		Teleport();
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		Teleport();
	}

	private void Teleport() {
		RoomManager.LoadRoom(targetRoomId);
	}

	/*public Room room;

	public override void OnTeleport() {
		Character playerCharacter = Game.GetPlayerCharacter();
		Vector2 position = transform.position;

		playerCharacter.CancelScheduledActions();
		playerCharacter.Look(position);
		playerCharacter.Walk(position);
	}*/

}
