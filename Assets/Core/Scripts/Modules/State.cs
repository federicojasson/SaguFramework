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

		public static void AddCharacter(string characterId, CharacterState characterState) {
			characters.Add(characterId, characterState);
		}
		
		public static void AddHint(string hint) {
			hints.Add(hint);
		}
		
		public static void AddInventoryItem(string inventoryItemId) {
			inventoryItems.Add(inventoryItemId);
		}

		public static void AddItem(string itemId, ItemState itemState) {
			items.Add(itemId, itemState);
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
		
		public static bool HintExists(string hint) {
			return hints.Contains(hint);
		}
		
		public static void RemoveCharacter(string characterId) {
			characters.Remove(characterId);
		}
		
		public static void RemoveHint(string hint) {
			hints.Remove(hint);
		}
		
		public static void RemoveInventoryItem(string inventoryItemId) {
			inventoryItems.Remove(inventoryItemId);
		}
		
		public static void RemoveItem(string itemId) {
			items.Remove(itemId);
		}
		
		public static void SetCurrentRoom(string roomId) {
			currentRoom = roomId;
		}
		
		public static void SetPlayerCharacter(string characterId) {
			playerCharacter = characterId;
		}

	}
	
}
