using UnityEngine;

public class GuiManagerWorker : MonoBehaviour {

	public DialogDictionary DialogModels;
	public Texture2D FadeTexture;
	public MenuDictionary MenuModels;

	public void Awake() {
		GuiManager.SetWorker(this);
	}
	
}
