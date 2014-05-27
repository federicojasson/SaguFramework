public class Teleporter : InteractiveObject {

	public override void DoDefocus() {
		base.DoDefocus();
		OrderManager.ClearForcedOrder();
	}

	public override void DoFocus() {
		base.DoFocus();
		OrderManager.SetForcedOrder(C.ORDER_TELEPORT);
	}
	
}
