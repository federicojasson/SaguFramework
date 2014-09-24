using System.Collections.Generic;

namespace SaguFramework {
	
	/// Keeps track of the state of the game.
	/// This module offers convenient methods to read and modify the state of the game.
	/// Also, methods are provided to handle the state files (save, load and others).
	/// It records the following things:
	/// - Which is the current room.
	/// - Who is the player character.
	/// - Characters in the game and its states.
	/// - Items in the game and its states.
	/// - Items in the inventory.
	/// - Hints: they register relevant events that happened in the game.
	public static partial class State {

		private static Dictionary<string, CharacterState> characters; // The state of the characters
		private static string currentRoom; // The current room
		private static List<string> hints; // The hints
		private static List<string> inventoryItems; // The inventory items
		private static Dictionary<string, ItemState> items; // The state of the items
		private static string playerCharacter; // The player character
		
		/// Performs class initialization tasks.
		static State() {
			characters = new Dictionary<string, CharacterState>();
			hints = new List<string>();
			inventoryItems = new List<string>();
			items = new Dictionary<string, ItemState>();
		}

		/// Adds a character.
		/// Receives its ID and state.
		public static void AddCharacter(string characterId, CharacterState characterState) {
			characters.Add(characterId, characterState);
		}

		/// Adds a hint.
		public static void AddHint(string hint) {
			hints.Add(hint);
		}

		/// Adds an inventory item.
		/// Receives its ID.
		public static void AddInventoryItem(string inventoryItemId) {
			inventoryItems.Add(inventoryItemId);
		}

		/// Adds an item.
		/// Receives its ID and state.
		public static void AddItem(string itemId, ItemState itemState) {
			items.Add(itemId, itemState);
		}

		/// Returns the state of a character.
		public static CharacterState GetCharacterState(string characterId) {
			return characters[characterId];
		}

		/// Returns the current room.
		public static string GetCurrentRoom() {
			return currentRoom;
		}

		/// Returns the inventory items.
		public static List<string> GetInventoryItems() {
			return inventoryItems;
		}

		/// Returns the state of an item.
		public static ItemState GetItemState(string itemId) {
			return items[itemId];
		}

		/// Returns the player character.
		public static string GetPlayerCharacter() {
			return playerCharacter;
		}

		/// Returns the characters that are located in a certain room.
		public static List<string> GetRoomCharacters(string roomId) {
			List<string> characterIds = new List<string>();
			
			foreach (KeyValuePair<string, CharacterState> entry in characters)
				if (roomId == entry.Value.GetLocation().GetRoom())
					// The character is located in the indicated room
					characterIds.Add(entry.Key);
			
			return characterIds;
		}

		/// Returns the items that are located in a certain room.
		public static List<string> GetRoomItems(string roomId) {
			List<string> itemIds = new List<string>();
			
			foreach (KeyValuePair<string, ItemState> entry in items)
				if (roomId == entry.Value.GetLocation().GetRoom())
					// The item is located in the indicated room
					itemIds.Add(entry.Key);
			
			return itemIds;
		}
		
		/// Determines whether a certain hint exists.
		public static bool HintExists(string hint) {
			return hints.Contains(hint);
		}

		/// Removes a character.
		/// Receives its ID.
		public static void RemoveCharacter(string characterId) {
			characters.Remove(characterId);
		}

		/// Removes a hint.
		public static void RemoveHint(string hint) {
			hints.Remove(hint);
		}

		/// Removes an inventory item.
		/// Receives its ID.
		public static void RemoveInventoryItem(string inventoryItemId) {
			inventoryItems.Remove(inventoryItemId);
		}

		/// Removes an item.
		/// Receives its ID.
		public static void RemoveItem(string itemId) {
			items.Remove(itemId);
		}

		/// Sets the state of a character.
		/// The character must have been already added.
		/// Receives its ID and new state.
		public static void SetCharacterState(string characterId, CharacterState characterState) {
			characters[characterId] = characterState;
		}

		/// Sets the current room.
		public static void SetCurrentRoom(string roomId) {
			currentRoom = roomId;
		}

		/// Sets the state of an item.
		/// The item must have been already added.
		/// Receives its ID and new state.
		public static void SetItemState(string itemId, ItemState itemState) {
			items[itemId] = itemState;
		}

		/// Sets the player character.
		public static void SetPlayerCharacter(string characterId) {
			playerCharacter = characterId;
		}

	}
	
}
