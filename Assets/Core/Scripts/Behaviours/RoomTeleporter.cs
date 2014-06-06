public abstract class RoomTeleporter : InteractiveObject {

	public override void DoDefocus() {
		base.DoDefocus();
		OrderManager.ClearForcedOrder();
		GUIManager.ClearCursorLabel();
	}

	public override void DoFocus() {
		base.DoFocus();
		OrderManager.SetForcedOrder(C.ORDER_TELEPORT);
		GUIManager.SetCursorLabel(GetLabelText());
	}

	public override void DoTeleport() {
		RoomManager.LoadRoom(GetTarget());
	}

	protected abstract string GetLabelText();

	protected abstract string GetTarget();
	
}
