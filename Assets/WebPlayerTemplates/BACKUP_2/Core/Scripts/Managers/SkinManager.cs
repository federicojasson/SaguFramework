using UnityEngine;

public static class SkinManager {

	public static GUISkin DefaultSkin;
	public static Texture2D FadeTexture;

	public static void SetWorker(SkinManagerWorker worker) {
		DefaultSkin = worker.DefaultSkin;
		FadeTexture = worker.FadeTexture;
	}

}
