public abstract class RoomTeleporter : InteractiveObject {

	public override void DoDefocus() {
		base.DoDefocus();
		OrderManager.ClearForcedOrder();
	}

	public override void DoFocus() {
		base.DoFocus();
		OrderManager.SetForcedOrder(C.ORDER_TELEPORT);
	}

	public virtual void DoTeleport() {
		RoomManager.LoadRoom(GetTarget());
	}

	protected abstract string GetTarget();
	
}
