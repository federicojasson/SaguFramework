using UnityEngine;

public static class Utility {
	
	public static bool AreEqual(float f1, float f2) {
		return Mathf.Abs(f1 - f2) < P.DELTA;
	}
	
}
