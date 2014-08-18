using UnityEngine;

public partial class Utilities : MonoBehaviour {

	private static Utilities instance; // Singleton instance
	
	public static Timer CreateTimer() {
		// Clones the timer model
		return (Timer) Object.Instantiate(instance.TimerModel);
	}
	
}
