using SaguFramework.Structures.Auxiliar;
using System.Collections.Generic;

namespace SaguFramework.Managers {
	
	public static class StateManager {
		
		// TODO: usar esta clase para registrar el estado actual del mundo

		private static Dictionary<string, Location> characterLocations;
		private static string currentRoomId;
		private static List<string> inventoryItemIds;
		private static Dictionary<string, Location> itemLocations;

		static StateManager() {
			// Initializes the data structures
			characterLocations = new Dictionary<string, Location>();
			inventoryItemIds = new List<string>();
			itemLocations = new Dictionary<string, Location>();
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

	}
	
}
