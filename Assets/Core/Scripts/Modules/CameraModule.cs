using UnityEngine;

public static class CameraModule {
	
	private static CameraModuleBehaviour behaviour;

	public static Rect GetScreenRectangle() {
		// TODO: calculate this somehow
		return new Rect(0, 0, 1600, 900);
	}

	public static void SetBehaviour(CameraModuleBehaviour behaviour) {
		CameraModule.behaviour = behaviour;
	}
	
}
