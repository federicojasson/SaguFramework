using UnityEngine;

public class SkinManagerWorker : MonoBehaviour {

	public Texture2D FadeTexture;

	public void Awake() {
		SkinManager.SetWorker(this);
	}

}
