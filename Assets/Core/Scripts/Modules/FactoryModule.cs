using UnityEngine;

public static class FactoryModule {
	
	private static FactoryModuleBehaviour behaviour;

	public static Timer CreateTimer() {
		Timer timerModel = behaviour.timerModel;
		Timer timer = (Timer) Object.Instantiate(timerModel);

		return timer;
	}

	public static void SetBehaviour(FactoryModuleBehaviour behaviour) {
		FactoryModule.behaviour = behaviour;
	}
	
}
