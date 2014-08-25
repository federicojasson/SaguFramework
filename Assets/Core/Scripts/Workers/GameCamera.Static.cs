using UnityEngine;

public partial class GameCamera : MonoBehaviour {

	private static GameCamera instance; // Singleton instance

	public static void SetTarget(Transform target) {
		instance.target = target;
	}

}
