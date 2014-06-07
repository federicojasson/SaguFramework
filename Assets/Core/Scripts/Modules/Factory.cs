using UnityEngine;

public static class Factory {
	
	private static FactoryBehaviour behaviour;

	public static Timer CreateTimer() {
		Timer model = behaviour.timerModel;
		Timer timer = (Timer) Object.Instantiate(model);

		return timer;
	}

	public static void SetBehaviour(FactoryBehaviour behaviour) {
		Factory.behaviour = behaviour;
	}
	
}
