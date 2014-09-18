using System.Collections.Generic;

namespace SaguFramework {
	
	public static partial class State {

		private static Dictionary<string, CharacterState> characters;
		private static string currentRoom;
		private static List<string> hints;
		private static List<string> inventoryItems;
		private static Dictionary<string, ItemState> items;
		private static string playerCharacter;

		static State() {
			characters = new Dictionary<string, CharacterState>();
			hints = new List<string>();
			inventoryItems = new List<string>();
			items = new Dictionary<string, ItemState>();
		}
		
		public static CharacterState GetCharacterState(string characterId) {
			return characters[characterId];
		}
		
		public static string GetCurrentRoom() {
			return currentRoom;
		}
		
		public static List<string> GetInventoryItems() {
			return inventoryItems;
		}
		
		public static ItemState GetItemState(string itemId) {
			return items[itemId];
		}

		public static string GetPlayerCharacter() {
			return playerCharacter;
		}
		
		public static List<string> GetRoomCharacters(string roomId) {
			List<string> characterIds = new List<string>();
			
			foreach (KeyValuePair<string, CharacterState> entry in characters)
				if (roomId == entry.Value.GetLocation().GetRoom())
					characterIds.Add(entry.Key);
			
			return characterIds;
		}
		
		public static List<string> GetRoomItems(string roomId) {
			List<string> itemIds = new List<string>();
			
			foreach (KeyValuePair<string, ItemState> entry in items)
				if (roomId == entry.Value.GetLocation().GetRoom())
					itemIds.Add(entry.Key);
			
			return itemIds;
		}

		/*public static void AddCharacter(string characterId, CharacterState characterState) {
			characterStates.Add(characterId, characterState);
		}

		public static void AddHint(string hint) {
			hints.Add(hint);
		}

		public static void AddInventoryItem(string inventoryItemId) {
			inventoryItemIds.Add(inventoryItemId);
		}
		
		public static void AddItem(string itemId, ItemState itemState) {
			itemStates.Add(itemId, itemState);
		}

		public static CharacterState GetCharacterState(string characterId) {
			return characterStates[characterId];
		}

		public static string GetCurrentRoomId() {
			return currentRoomId;
		}

		public static List<string> GetInventoryItemIds() {
			return inventoryItemIds;
		}
		
		public static ItemState GetItemState(string itemId) {
			return itemStates[itemId];
		}

		public static string GetPlayerCharacterId() {
			return playerCharacterId;
		}

		public static List<string> GetRoomCharacterIds(string roomId) {
			List<string> characterIds = new List<string>();
			
			foreach (KeyValuePair<string, CharacterState> entry in characterStates)
				if (roomId == entry.Value.GetLocation().GetRoomId())
					characterIds.Add(entry.Key);
			
			return characterIds;
		}

		public static List<string> GetRoomItemIds(string roomId) {
			List<string> itemIds = new List<string>();
			
			foreach (KeyValuePair<string, ItemState> entry in itemStates)
				if (roomId == entry.Value.GetLocation().GetRoomId())
					itemIds.Add(entry.Key);
			
			return itemIds;
		}

		public static bool HintExists(string hint) {
			return hints.Contains(hint);
		}
		
		public static void RemoveCharacter(string characterId) {
			characterStates.Remove(characterId);
		}

		public static void RemoveHint(string hint) {
			hints.Remove(hint);
		}

		public static void RemoveInventoryItem(string inventoryItemId) {
			inventoryItemIds.Remove(inventoryItemId);
		}

		public static void RemoveItem(string itemId) {
			itemStates.Remove(itemId);
		}

		public static void SetCharacterState(string characterId, CharacterState characterState) {
			characterStates[characterId] = characterState;
		}

		public static void SetCurrentRoomId(string roomId) {
			currentRoomId = roomId;
		}
		
		public static void SetItemState(string itemId, ItemState itemState) {
			itemStates[itemId] = itemState;
		}

		public static void SetPlayerCharacterId(string characterId) {
			playerCharacterId = characterId;
		}*/
		
	}
	
}
