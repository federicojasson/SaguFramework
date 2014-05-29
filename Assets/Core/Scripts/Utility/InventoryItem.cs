using UnityEngine;

//
// InventoryItem - Utility class
//
// This class represents an inventory item. Objects of this class are managed by the InventoryManager. A link with its
// behaviour is created when the latter is instantiated.
//
public class InventoryItem {
	
	private InventoryItemBehaviour behaviour;
	private string id;

	public InventoryItem(string id) {
		this.id = id;
	}

	public InventoryItemBehaviour GetBehaviour() {
		return behaviour;
	}
	
	public string GetId() {
		return id;
	}
	
	public void SetBehaviour(InventoryItemBehaviour behaviour) {
		this.behaviour = behaviour;
	}

}
