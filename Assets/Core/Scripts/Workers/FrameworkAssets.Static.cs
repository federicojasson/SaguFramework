using UnityEngine;

public partial class FrameworkAssets : MonoBehaviour {
	
	private static FrameworkAssets instance; // Singleton instance

	public static Timer CreateTimer() {
		// Clones the timer prefab
		return (Timer) Object.Instantiate(instance.TimerPrefab);
	}
	
}
