using UnityEngine;

public static class ErrorManager {

	public static void Terminate(string context, string message) {
		if (Debug.isDebugBuild)
			// Prints an error message (debugging purposes)
			Debug.LogError(context + ": " + message);
		else
			// TODO: maybe write message to log text file
			Debug.Log("TODO: maybe write message to log text file");

		// Quits the application
		Application.Quit();
	}

}
