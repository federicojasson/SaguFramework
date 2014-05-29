using UnityEngine;

//
// Factory - Behaviour class
//
// TODO: write class description
//
public abstract class Factory : MonoBehaviour {

	private static Factory instance; // Singleton

	public static InventoryItemBehaviour CreateInventoryItem(InventoryItem inventoryItem) {
		// Instantiates the behaviour
		string id = inventoryItem.GetId();
		InventoryItemBehaviour model = Factory.instance.GetInventoryItemModel(id);
		InventoryItemBehaviour behaviour = (InventoryItemBehaviour) Instantiate(model);

		return behaviour;
	}

	public static ItemBehaviour CreateItem(Item item) {
		// Instantiates the behaviour
		string id = item.GetId();
		ItemBehaviour model = Factory.instance.GetItemModel(id);
		ItemBehaviour behaviour = (ItemBehaviour) Instantiate(model);

		// Sets the behaviour's properties
		behaviour.transform.position = new Vector2(item.GetX(), item.GetY());

		return behaviour;
	}
	
	public static NonPlayerCharacterBehaviour CreateNonPlayerCharacter(NonPlayerCharacter nonPlayerCharacter) {
		// Instantiates the behaviour
		string id = nonPlayerCharacter.GetId();
		NonPlayerCharacterBehaviour model = Factory.instance.GetNonPlayerCharacterModel(id);
		NonPlayerCharacterBehaviour behaviour = (NonPlayerCharacterBehaviour) Instantiate(model);
		
		// Sets the behaviour's properties
		behaviour.transform.position = new Vector2(nonPlayerCharacter.GetX(), nonPlayerCharacter.GetY());
		
		return behaviour;
	}
	
	public static PlayerCharacterBehaviour CreatePlayerCharacter(PlayerCharacter playerCharacter) {
		// Instantiates the behaviour
		string id = playerCharacter.GetId();
		PlayerCharacterBehaviour model = Factory.instance.GetPlayerCharacterModel(id);
		PlayerCharacterBehaviour behaviour = (PlayerCharacterBehaviour) Instantiate(model);
		
		// Sets the behaviour's properties
		behaviour.transform.position = new Vector2(playerCharacter.GetX(), playerCharacter.GetY());
		
		return behaviour;
	}

	public static Texture2D GetCursorImageDisabledStatic() {
		return Factory.instance.GetCursorImageDisabled();
	}

	public static Texture2D GetCursorImageOrderLookStatic() {
		return Factory.instance.GetCursorImageOrderLook();
	}
	
	public static Texture2D GetCursorImageOrderTeleportStatic() {
		return Factory.instance.GetCursorImageOrderTeleport();
	}
	
	public static Texture2D GetCursorImageOrderWalkStatic() {
		return Factory.instance.GetCursorImageOrderWalk();
	}

	public static Texture2D GetCursorImagePauseStatic() {
		return Factory.instance.GetCursorImagePause();
	}

	public void Awake() {
		// Allows static references to this class
		Factory.instance = this;

		// Prevents the factory object from being destroyed when the scene changes
		DontDestroyOnLoad(this);
	}

	protected abstract InventoryItemBehaviour GetInventoryItemModel(string id);

	protected abstract ItemBehaviour GetItemModel(string id);

	protected abstract NonPlayerCharacterBehaviour GetNonPlayerCharacterModel(string id);

	protected abstract PlayerCharacterBehaviour GetPlayerCharacterModel(string id);

	protected abstract Texture2D GetCursorImageDisabled();
	
	protected abstract Texture2D GetCursorImageOrderLook();

	protected abstract Texture2D GetCursorImageOrderTeleport();

	protected abstract Texture2D GetCursorImageOrderWalk();

	protected abstract Texture2D GetCursorImagePause();
	
}
