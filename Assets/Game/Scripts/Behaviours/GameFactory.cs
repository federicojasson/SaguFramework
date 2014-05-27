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

	public Texture2D cursorImageDisabled;
	public Texture2D cursorImageOrderLook;
	public Texture2D cursorImageOrderTeleport;
	public Texture2D cursorImageOrderWalk;
	public Texture2D cursorImagePause;
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

	protected override Texture2D GetCursorImageDisabled() {
		return cursorImageDisabled;
	}
	
	protected override Texture2D GetCursorImageOrderLook() {
		return cursorImageOrderLook;
	}
	
	protected override Texture2D GetCursorImageOrderTeleport() {
		return cursorImageOrderTeleport;
	}
	
	protected override Texture2D GetCursorImageOrderWalk() {
		return cursorImageOrderWalk;
	}
	
	protected override Texture2D GetCursorImagePause() {
		return cursorImagePause;
	}
	
}
