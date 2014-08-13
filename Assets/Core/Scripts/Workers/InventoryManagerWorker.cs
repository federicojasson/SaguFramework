using UnityEngine;

public class InventoryManagerWorker : MonoBehaviour {
	
	public InventoryItemDictionary InventoryItemModels;

	public void Awake() {
		InventoryManager.SetWorker(this);
	}
	
}
