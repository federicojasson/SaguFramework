using UnityEngine;

public class ItemManagerWorker : MonoBehaviour {

	public ItemDictionary ItemModels;

	public void Awake() {
		ItemManager.SetWorker(this);
	}
	
}
