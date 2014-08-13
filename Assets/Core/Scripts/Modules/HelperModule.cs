using UnityEngine;

public static class HelperModule {
	
	private static HelperModuleBehaviour behaviour;
	
	public static Timer CreateTimer() {
		Timer timerModel = behaviour.TimerModel;
		Timer timer = (Timer) Object.Instantiate(timerModel);
		
		return timer;
	}
	
	public static void SetBehaviour(HelperModuleBehaviour behaviour) {
		HelperModule.behaviour = behaviour;
	}
	
}
