using UnityEngine;

public static class UtilityManager {
	
	private static UtilityManagerWorker worker;
	
	public static Timer CreateTimer() {
		Timer timerModel = worker.TimerModel;
		Timer timer = (Timer) Object.Instantiate(timerModel);
		
		return timer;
	}
	
	public static void SetWorker(UtilityManagerWorker worker) {
		UtilityManager.worker = worker;
	}
	
}
