using System;
using UnityEngine;

namespace SaguFramework {

	/// This module provides an interface through which the framework is used.
	// Almost any intended action can be achieved with this module.
	public static class Framework {

		/// Adds a hint to the game state.
		public static void AddHint(string hint) {
			State.AddHint(hint);
		}

		/// Adds a character to the game state.
		/// If the character is located in the current room, it creates it.
		public static void AddCharacter(string characterId, CharacterState characterState) {
			// Gets the current room
			string roomId = State.GetCurrentRoom();

			if (characterState.GetLocation().GetRoom() == roomId) {
				// The character is located in the current room, so it creates it
				CharacterParameters characterParameters = Parameters.GetCharacterParameters(characterId);
				RoomParameters roomParameters = Parameters.GetRoomParameters(roomId);
				Factory.CreateCharacter(characterId, characterState, characterParameters, roomParameters);
			}

			// Adds the character to the game state
			State.AddCharacter(characterId, characterState);
		}

		/// Adds an inventory item to the game state and creates it.
		public static void AddInventoryItem(string inventoryItemId) {
			// Creates the inventory item
			InventoryItemParameters inventoryItemParameters = Parameters.GetInventoryItemParameters(inventoryItemId);
			InventoryParameters inventoryParameters = Parameters.GetInventoryParameters();
			Factory.CreateInventoryItem(inventoryItemId, inventoryItemParameters, inventoryParameters);

			// Adds the inventory item to the game state
			State.AddInventoryItem(inventoryItemId);

			if (Entities.GetInventory().IsActivated())
				// The inventory is being shown so it shows its last page
				InventoryManager.ShowLastPage();
		}

		/// Adds an item to the game state.
		/// If the item is located in the current room, it creates it.
		public static void AddItem(string itemId, ItemState itemState) {
			// Gets the current room
			string roomId = State.GetCurrentRoom();
			
			if (itemState.GetLocation().GetRoom() == roomId) {
				// The item is located in the current room, so it creates it
				ItemParameters itemParameters = Parameters.GetItemParameters(itemId);
				RoomParameters roomParameters = Parameters.GetRoomParameters(roomId);
				Factory.CreateItem(itemId, itemState, itemParameters, roomParameters);
			}
			
			// Adds the item to the game state
			State.AddItem(itemId, itemState);
		}

		/// Registers and begins a GUILayout area.
		/// The new area is defined relatively to the previous one.
		public static void BeginArea(float x, float y, float width, float height) {
			Drawer.BeginArea(x, y, width, height);
		}

		/// Changes the player character.
		/// The new player character must exist and be in the same room.
		public static void ChangePlayerCharacter(string characterId) {
			// Sets the player character in the game state
			State.SetPlayerCharacter(characterId);

			// Sets the camera's new target
			Character character = Entities.GetCharacters()[characterId];
			CameraHandler.SetCameraTarget(character);
		}

		/// Changes the room.
		/// Receives the new room's ID and the ID of the entry in which the player character will spawn.
		public static void ChangeRoom(string roomId, string entryId) {
			ChangeRoom(roomId, entryId, string.Empty);
		}

		/// Changes the room, but before, it shows a splash screen from a group (if the group's ID isn't empty).
		/// Receives the new room's ID and the ID of the entry in which the player character will spawn.
		public static void ChangeRoom(string roomId, string entryId, string groupId) {
			// Gets the player character
			string characterId = State.GetPlayerCharacter();

			RoomParameters roomParameters = Parameters.GetRoomParameters(roomId);
			EntryParameters entryParameters = roomParameters.Entries[entryId];

			Direction direction = entryParameters.Direction;
			Location location = new Location(entryParameters.Position, roomId);
			CharacterState characterState = new CharacterState(direction, location);

			// Updates the game state
			State.SetCharacterState(characterId, characterState);
			State.SetCurrentRoom(roomId);

			// Loads the splash screen or the room
			LoadSplashScreenOrRoom(groupId);
		}
		
		/// Closes the current menu.
		public static void CloseMenu() {
			MenuManager.CloseMenu();
		}
		
		/// Deletes a state file.
		public static void DeleteGame(string stateId) {
			State.Delete(stateId);
		}
		
		/// Unregisters and ends a GUILayout area.
		public static void EndArea() {
			Drawer.EndArea();
		}
		
		/// Schedules character actions.
		public static void ExecuteActions(string characterId, CharacterAction[] actions) {
			ExecuteActions(characterId, actions, null);
		}
		
		/// Schedules character actions and a task to be executed at the end.
		public static void ExecuteActions(string characterId, CharacterAction[] actions, Action furtherAction) {
			Character character = Entities.GetCharacters()[characterId];
			character.ExecuteActions(actions, furtherAction);
		}

		/// Exits the game.
		public static void Exit() {
			Application.Quit();
		}

		/// Returns a specific character.
		/// Receives its ID.
		public static Character GetCharacter(string characterId) {
			return Entities.GetCharacters()[characterId];
		}
		
		/// Returns the current language.
		public static string GetCurrentLanguage() {
			return Language.GetCurrentLanguage();
		}

		/// Returns the current room.
		public static string GetCurrentRoom() {
			return State.GetCurrentRoom();
		}

		/// Returns the effect volume.
		public static float GetEffectVolume() {
			return Options.GetFloat(Parameters.OptionIdEffectVolume);
		}
		
		/// Returns a specific inventory item.
		/// Receives its ID.
		public static InventoryItem GetInventoryItem(string inventoryItemId) {
			return Entities.GetInventoryItems()[inventoryItemId];
		}

		/// Returns a specific item.
		/// Receives its ID.
		public static Item GetItem(string itemId) {
			return Entities.GetItems()[itemId];
		}

		/// Returns the master volume.
		public static float GetMasterVolume() {
			return Options.GetFloat(Parameters.OptionIdMasterVolume);
		}

		/// Returns the player character.
		public static string GetPlayerCharacter() {
			return State.GetPlayerCharacter();
		}

		/// Returns the player character's state.
		public static CharacterState GetPlayerCharacterState() {
			string characterId = State.GetPlayerCharacter();
			Character character = Entities.GetCharacters()[characterId];

			Direction direction = character.GetDirection();
			Vector2 position = Geometry.WorldToGamePosition(character.GetPosition());
			string roomId = State.GetCurrentRoom();
			Location location = new Location(position, roomId);

			return new CharacterState(direction, location);
		}
		
		/// Returns the music volume.
		public static float GetSongVolume() {
			return Options.GetFloat(Parameters.OptionIdSongVolume);
		}
		
		/// Returns a specific speech.
		/// Receives its ID.
		public static Speech GetSpeech(string speechId) {
			return Language.GetSpeech(speechId);
		}
		
		/// Returns the existing state files.
		public static StateFile[] GetStateFiles() {
			return State.GetStateFiles();
		}

		/// Returns a skin style with relative font, margin and padding.
		public static GUIStyle GetStyle(string styleId) {
			return Drawer.GetStyle(styleId);
		}
		
		/// Returns a specific text.
		/// Receives its ID.
		public static string GetText(string textId) {
			return Language.GetText(textId);
		}
		
		/// Returns the voice volume.
		public static float GetVoiceVolume() {
			return Options.GetFloat(Parameters.OptionIdVoiceVolume);
		}
		
		/// Determines whether a certain hint exists.
		public static bool HintExists(string hint) {
			return State.HintExists(hint);
		}
		
		/// Determines whether the main menu is opened.
		public static bool IsMainMenuOpen() {
			return MenuManager.IsMainMenuOpen();
		}

		/// Loads a game.
		/// Receives the state's ID.
		public static void LoadGame(string stateId) {
			LoadGame(stateId, string.Empty);
		}

		/// Loads a game, but before, it shows a splash screen from a group (if the group's ID isn't empty).
		/// Receives the state's ID.
		public static void LoadGame(string stateId, string groupId) {
			// Loads a specific state
			State.Load(stateId);

			// Loads the splash screen or the room
			LoadSplashScreenOrRoom(groupId);
		}

		/// Locks the input manually.
		/// The caller is responsible of calling UnlockInput to unlock the input.
		public static void LockInput() {
			InputReader.LockInput();
		}

		/// Starts a new game.
		public static void NewGame() {
			NewGame(string.Empty);
		}
		
		/// Starts a new game, but before, it shows a splash screen from a group (if the group's ID isn't empty).
		public static void NewGame(string groupId) {
			// Loads the initial state
			State.LoadInitial();

			// Loads the splash screen or the room
			LoadSplashScreenOrRoom(groupId);
		}
		
		/// Opens the main menu.
		public static void OpenMainMenu() {
			Loader.ChangeScene(Parameters.SceneMainMenu);
		}

		/// Opens a specific menu.
		/// Receives its ID.
		public static void OpenMenu(string menuId) {
			MenuManager.OpenMenu(menuId);
		}

		/// Removes a character from the game state.
		/// If the character is located in the current room, it destroys it.
		public static void RemoveCharacter(string characterId) {
			Character character;
			if (Entities.GetCharacters().TryGetValue(characterId, out character))
				// The character is located in the current room, so it destroys it
				character.Destroy();

			// Removes the character from the game state
			State.RemoveCharacter(characterId);
		}

		/// Removes a hint from the game state.
		public static void RemoveHint(string hint) {
			State.RemoveHint(hint);
		}

		/// Removes an inventory item from the game state and destroys it.
		public static void RemoveInventoryItem(string inventoryItemId) {
			// Destroys the inventory item
			Entities.GetInventoryItems()[inventoryItemId].Destroy();

			// Removes the inventory item from the game state
			State.RemoveInventoryItem(inventoryItemId);

			if (Entities.GetInventory().IsActivated())
				// The inventory is being shown so it refreshes the current page
				InventoryManager.RefreshCurrentPage();
		}

		/// Removes an item from the game state.
		/// If the item is located in the current room, it destroys it.
		public static void RemoveItem(string itemId) {
			Item item;
			if (Entities.GetItems().TryGetValue(itemId, out item))
				// The item is located in the current room, so it destroys it
				item.Destroy();
			
			// Removes the item from the game state
			State.RemoveItem(itemId);
		}

		/// Saves the current game with a specific state's ID.
		/// Before saving the game, it updates the state of characters and items.
		public static void SaveGame(string stateId) {
			// Updates the character's state
			foreach (Character character in Entities.GetCharacters().Values) {
				string characterId = character.GetId();

				Direction direction = character.GetDirection();
				Vector2 position = Geometry.WorldToGamePosition(character.GetPosition());
				string roomId = State.GetCurrentRoom();
				Location location = new Location(position, roomId);
				CharacterState characterState = new CharacterState(direction, location);
				
				State.SetCharacterState(characterId, characterState);
			}

			// Updates the item's state
			foreach (Item item in Entities.GetItems().Values) {
				string itemId = item.GetId();

				Vector2 position = Geometry.WorldToGamePosition(item.GetPosition());
				string roomId = State.GetCurrentRoom();
				Location location = new Location(position, roomId);
				ItemState itemState = new ItemState(location);
				
				State.SetItemState(itemId, itemState);
			}

			// Saves the state
			State.Save(stateId);
		}

		/// Saves the current options.
		public static void SaveOptions() {
			Options.Save();
		}

		/// Sets the effect volume.
		/// The received volume must be a value between 0 and 1.
		public static void SetEffectVolume(float effectVolume) {
			Options.SetFloat(Parameters.OptionIdEffectVolume, effectVolume);
			SoundPlayer.SetEffectVolume(effectVolume);
		}

		/// Sets the current language and loads it.
		/// Receives the language's ID.
		public static void SetLanguage(string languageId) {
			Options.SetString(Parameters.OptionIdLanguage, languageId);
			Language.Load(languageId);
		}
				
		/// Sets the master volume.
		/// The received volume must be a value between 0 and 1.
		public static void SetMasterVolume(float masterVolume) {
			Options.SetFloat(Parameters.OptionIdMasterVolume, masterVolume);
			SoundPlayer.SetMasterVolume(masterVolume);
		}
		
		/// Sets the song volume.
		/// The received volume must be a value between 0 and 1.
		public static void SetSongVolume(float songVolume) {
			Options.SetFloat(Parameters.OptionIdSongVolume, songVolume);
			SoundPlayer.SetSongVolume(songVolume);
		}
		
		/// Sets the voice volume.
		/// The received volume must be a value between 0 and 1.
		public static void SetVoiceVolume(float voiceVolume) {
			Options.SetFloat(Parameters.OptionIdVoiceVolume, voiceVolume);
			SoundPlayer.SetVoiceVolume(voiceVolume);
		}
		
		/// Stops the actions of a character.
		public static void StopActions(string characterId) {
			Entities.GetCharacters()[characterId].StopActions();
		}

		/// Unlocks the input.
		/// This method must be called sometime after invoking LockInput.
		public static void UnlockInput() {
			InputReader.UnlockInput();
		}

		/// Unselects the currently selected inventory item.
		/// This method is usually called when a OnUseInventoryItem takes effect.
		public static void UnselectInventoryItem() {
			InputReader.UnselectInventoryItem();
		}

		/// Loads the splash screen scene or the room scene, based on the received group's ID.
		/// If the group's ID is empty, loads the room scene.
		/// Otherwise, loads the splash screen scene to show a splash screen from the group.
		private static void LoadSplashScreenOrRoom(string groupId) {
			if (groupId.Length == 0)
				Loader.ChangeScene(Parameters.SceneRoom);
			else {
				SplashScreenManager.SetCurrentGroup(groupId);
				Loader.ChangeScene(Parameters.SceneSplashScreen);
			}
		}
		
	}
	
}
