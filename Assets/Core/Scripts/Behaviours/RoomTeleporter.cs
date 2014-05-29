public abstract class RoomTeleporter : InteractiveObject {

	public string target;

	public override void DoDefocus() {
		base.DoDefocus();
		OrderManager.ClearForcedOrder();
	}

	public override void DoFocus() {
		base.DoFocus();
		OrderManager.SetForcedOrder(C.ORDER_TELEPORT);
	}

	public override void DoTeleport() {
		RoomManager.LoadRoom(target);
	}
	
}
