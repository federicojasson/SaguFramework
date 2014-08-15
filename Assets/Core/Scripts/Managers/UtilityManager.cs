using System.Globalization;
using System.IO;
using UnityEngine;

public static class UtilityManager {
	
	private static UtilityManagerWorker worker;
	
	public static Timer CreateTimer() {
		Timer timerModel = worker.TimerModel;
		Timer timer = (Timer) Object.Instantiate(timerModel);
		
		return timer;
	}

	public static string ReadTextFileContent(string path) {
		return File.ReadAllText(path);
	}
	
	public static void SetWorker(UtilityManagerWorker worker) {
		UtilityManager.worker = worker;
	}

	public static float StringToFloat(string floatString) {
		return float.Parse(floatString, CultureInfo.InvariantCulture);
	}
	
}
