using UnityEngine;

public class InventoryManager : MonoBehaviour {

	private static InventoryManagerWorker worker;
	
	public static void SetWorker(InventoryManagerWorker worker) {
		InventoryManager.worker = worker;
	}

	private static InventoryItem CreateInventoryItem(string id) {
		InventoryItem inventoryItemModel = worker.InventoryItemModels[id];
		return (InventoryItem) Object.Instantiate(inventoryItemModel);
	}
	
}
