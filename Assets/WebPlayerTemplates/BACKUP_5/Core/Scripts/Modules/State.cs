using System.Collections.Generic;

namespace SaguFramework {
	
	public static partial class State {

		private static Dictionary<string, CharacterState> characterStates;
		private static string currentRoomId;
		private static List<string> hints;
		private static List<string> inventoryItemIds;
		private static Dictionary<string, ItemState> itemStates;
		private static string playerCharacterId;

		static State() {
			characterStates = new Dictionary<string, CharacterState>();
			hints = new List<string>();
			inventoryItemIds = new List<string>();
			itemStates = new Dictionary<string, ItemState>();
		}

		public static CharacterState GetCharacterState(string id) {
			return characterStates[id];
		}

		public static string GetCurrentRoomId() {
			return currentRoomId;
		}

		public static List<string> GetInventoryItemIds() {
			return inventoryItemIds;
		}

		public static ItemState GetItemState(string id) {
			return itemStates[id];
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

		public static bool HintExists(string searchedHint) {
			return hints.Contains(searchedHint);
		}

	}
	
}
