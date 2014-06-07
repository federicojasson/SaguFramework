using UnityEngine;

public static class Drawer {
	
	private static DrawerBehaviour behaviour;

	public static void SetBehaviour(DrawerBehaviour behaviour) {
		Drawer.behaviour = behaviour;
	}
	
}
