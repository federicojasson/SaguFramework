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
	
	public ItemBehaviour erlenmeyer;
	public InventoryItemBehaviour inventoryErlenmeyer;
	public PlayerCharacterBehaviour scientist;

	protected override InventoryItemBehaviour GetInventoryItemModel(string id) {
		switch (id) {
			case G.INVENTORY_ITEM_ID_ERLENMEYER : return inventoryErlenmeyer;
			default : return null; // TODO: terminate?
		}
	}

	protected override ItemBehaviour GetItemModel(string id) {
		switch (id) {
			case G.ITEM_ID_ERLENMEYER : return erlenmeyer;
			default : return null; // TODO: terminate?
		}
	}
	
	protected override NonPlayerCharacterBehaviour GetNonPlayerCharacterModel(string id) {
		switch (id) {
			default : return null; // TODO: terminate?
		}
	}
	
	protected override PlayerCharacterBehaviour GetPlayerCharacterModel(string id) {
		switch (id) {
			case G.CHARACTER_ID_SCIENTIST : return scientist;
			default : return null; // TODO: terminate?
		}
	}
	
}
