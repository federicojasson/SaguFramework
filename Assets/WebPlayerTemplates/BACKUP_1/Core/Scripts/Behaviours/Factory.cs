using UnityEngine;

//
// Factory - Behaviour class
//
// TODO: write class description
//
public abstract class Factory : MonoBehaviour {

	public Texture2D cursorImageDisabled;
	public Texture2D cursorImageOrderLook;
	public Texture2D cursorImageOrderTeleport;
	public Texture2D cursorImageOrderWalk;
	public Texture2D cursorImagePause;
	public CursorLabel cursorLabel;
	public GUISkin skin;
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
		behaviour.transform.position = CoordinatesManager.GameToWorldPoint(new Vector2(item.GetX(), item.GetY()));

		return behaviour;
	}
	
	public static NonPlayerCharacterBehaviour CreateNonPlayerCharacter(NonPlayerCharacter nonPlayerCharacter) {
		// Instantiates the behaviour
		string id = nonPlayerCharacter.GetId();
		NonPlayerCharacterBehaviour model = Factory.instance.GetNonPlayerCharacterModel(id);
		NonPlayerCharacterBehaviour behaviour = (NonPlayerCharacterBehaviour) Instantiate(model);
		
		// Sets the behaviour's properties
		behaviour.transform.position = CoordinatesManager.GameToWorldPoint(new Vector2(nonPlayerCharacter.GetX(), nonPlayerCharacter.GetY()));
		
		return behaviour;
	}
	
	public static PlayerCharacterBehaviour CreatePlayerCharacter(PlayerCharacter playerCharacter) {
		// Instantiates the behaviour
		string id = playerCharacter.GetId();
		PlayerCharacterBehaviour model = Factory.instance.GetPlayerCharacterModel(id);
		PlayerCharacterBehaviour behaviour = (PlayerCharacterBehaviour) Instantiate(model);
		
		// Sets the behaviour's properties
		behaviour.transform.position = CoordinatesManager.GameToWorldPoint(new Vector2(playerCharacter.GetX(), playerCharacter.GetY()));
		
		return behaviour;
	}

	public static Texture2D GetCursorImageDisabled() {
		return Factory.instance.cursorImageDisabled;
	}

	public static Texture2D GetCursorImageOrderLook() {
		return Factory.instance.cursorImageOrderLook;
	}
	
	public static Texture2D GetCursorImageOrderTeleport() {
		return Factory.instance.cursorImageOrderTeleport;
	}
	
	public static Texture2D GetCursorImageOrderWalk() {
		return Factory.instance.cursorImageOrderWalk;
	}

	public static Texture2D GetCursorImagePause() {
		return Factory.instance.cursorImagePause;
	}

	public static CursorLabel GetCursorLabel() {
		return Factory.instance.cursorLabel;
	}

	public static GUISkin GetSkin() {
		return Factory.instance.skin;
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
	
}
