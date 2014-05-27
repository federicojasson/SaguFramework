using UnityEngine;

//
// OrderManager - Module class
//
// TODO: write class description
//
public static class OrderManager {

	private static int currentOrder;
	private static bool isCurrentOrderForced;
	private static int rotativeOrdersIndex;
	private static InteractiveObject target;

	static OrderManager() {
		isCurrentOrderForced = false;
		rotativeOrdersIndex = 0;
		currentOrder = C.ROTATIVE_ORDERS[rotativeOrdersIndex];
	}

	public static void ClearForcedOrder() {
		isCurrentOrderForced = false;
		
		// Sets the former rotative order
		SetOrder(C.ROTATIVE_ORDERS[rotativeOrdersIndex]);
	}

	public static void ClearTarget() {
		target = null;
	}
	
	public static void ExecuteCurrentOrder() {
		if (target == null) {
			// There is no target
		} else {
			// There is a target
		}

		// TODO: execute currentOrder on target (if it is not null, etc)
	}

	public static int GetCurrentOrder() {
		return currentOrder;
	}

	public static void SetForcedOrder(int order) {
		isCurrentOrderForced = true;
		
		// Sets the forced order
		SetOrder(order);
	}

	public static void SetNextRotativeOrder() {
		if (! isCurrentOrderForced) {
			rotativeOrdersIndex = (rotativeOrdersIndex + 1) % C.ROTATIVE_ORDERS.Length;
			SetOrder(C.ROTATIVE_ORDERS[rotativeOrdersIndex]);
		}
	}

	public static void SetTarget(InteractiveObject target) {
		OrderManager.target = target;
	}
	
	private static void SetOrder(int order) {
		currentOrder = order;
		InputManager.NotifySetOrder();
	}

}
