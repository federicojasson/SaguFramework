using UnityEngine;

public class MenuManagerWorker : MonoBehaviour {

	public MenuDictionary MenuModels;
	
	public void Awake() {
		MenuManager.SetWorker(this);
	}
	
}
