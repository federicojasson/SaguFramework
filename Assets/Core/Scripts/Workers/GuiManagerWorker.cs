using UnityEngine;

public class GuiManagerWorker : MonoBehaviour {

	public Texture2D FadeTexture;

	public void Awake() {
		GuiManager.SetWorker(this);
	}
	
}
