using SaguFramework.Structures.Auxiliar;
using System.Collections.Generic;

namespace SaguFramework.Managers {
	
	public static partial class StateManager {
		
		// TODO: usar esta clase para registrar el estado actual del mundo

		private static Dictionary<string, Location> characterLocations;
		private static string currentRoomId;
		private static List<string> inventoryItemIds;
		private static Dictionary<string, Location> itemLocations;
		private static string playerCharacterId;

		static StateManager() {
			// Initializes the data structures
			characterLocations = new Dictionary<string, Location>();
			inventoryItemIds = new List<string>();
			itemLocations = new Dictionary<string, Location>();
		}
		
		public static void AddInventoryItem(string inventoryItemId) {
			inventoryItemIds.Add(inventoryItemId);
		}

		public static Location GetCharacterLocation(string characterId) {
			return characterLocations[characterId];
		}

		public static string GetCurrentRoomId() {
			return currentRoomId;
		}

		public static Location GetItemLocation(string itemId) {
			return itemLocations[itemId];
		}

		public static string GetPlayerCharacterId() {
			return playerCharacterId;
		}

		public static List<string> GetRoomCharacterIds(string roomId) {
			// Initializes a data structure to store the character's IDs
			List<string> characterIds = new List<string>();

			// Fills the data structure with the IDs of the characters in the room
			foreach (KeyValuePair<string, Location> entry in characterLocations)
				if (roomId == entry.Value.GetRoomId())
					// The character is located in the room
					characterIds.Add(entry.Key);

			return characterIds;
		}

		public static List<string> GetRoomItemIds(string roomId) {
			// Initializes a data structure to store the item's IDs
			List<string> itemIds = new List<string>();
			
			// Fills the data structure with the IDs of the items in the room
			foreach (KeyValuePair<string, Location> entry in itemLocations)
				if (roomId == entry.Value.GetRoomId())
					// The item is located in the room
					itemIds.Add(entry.Key);
			
			return itemIds;
		}

		public static void RemoveCharacter(string characterId) {
			characterLocations.Remove(characterId);
		}

		public static void RemoveInventoryItem(string inventoryItemId) {
			inventoryItemIds.Remove(inventoryItemId);
		}

		public static void RemoveItem(string itemId) {
			itemLocations.Remove(itemId);
		}
		
		public static void SetCharacterLocation(string characterId, Location characterLocation) {
			characterLocations[characterId] = characterLocation;
		}

		public static void SetCurrentRoomId(string roomId) {
			currentRoomId = roomId;
		}
		
		public static void SetItemLocation(string itemId, Location itemLocation) {
			itemLocations[itemId] = itemLocation;
		}

		public static void SetPlayerCharacterId(string characterId) {
			playerCharacterId = characterId;
		}

	}
	
}
