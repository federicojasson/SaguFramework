using UnityEngine;

public static class SkinManager {

	public static Texture2D FadeTexture;

	public static void SetWorker(SkinManagerWorker worker) {
		FadeTexture = worker.FadeTexture;
	}

}
