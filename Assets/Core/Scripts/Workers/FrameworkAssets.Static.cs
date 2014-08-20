using UnityEngine;

public partial class FrameworkAssets : MonoBehaviour {
	
	private static FrameworkAssets instance; // Singleton instance

	public static Timer CreateTimer() {
		// Instantiates the timer prefab
		return UtilityManager.Instantiate<Timer>(instance.TimerPrefab);
	}
	
}
