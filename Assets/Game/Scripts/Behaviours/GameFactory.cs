using UnityEngine;

//
// GameFactory - Behaviour class
//
// This class implements the factory interface. It implements the mapping between an object ID and its model. All game
// object's models must be attached to this script.
//
// TODO: decide what to do in case of error
//
public class GameFactory : Factory {
	
	public GameObject erlenmeyer;
	public GameObject inventoryErlenmeyer;
	public GameObject scientist;

	protected override GameObject GetCharacterModel(string id) {
		switch (id) {
			case G.CHARACTER_ID_SCIENTIST : return scientist;
			default : return null; // TODO: terminate?
		}
	}

	protected override GameObject GetInventoryItemModel(string id) {
		switch (id) {
			case G.INVENTORY_ITEM_ID_ERLENMEYER : return inventoryErlenmeyer;
			default : return null; // TODO: terminate?
		}
	}

	protected override GameObject GetItemModel(string id) {
		switch (id) {
			case G.ITEM_ID_ERLENMEYER : return erlenmeyer;
			default : return null; // TODO: terminate?
		}
	}
	
}
