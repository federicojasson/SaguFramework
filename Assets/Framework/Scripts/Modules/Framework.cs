using System;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {

	// TODO: comentar

	/// This module provides an interface through which the framework is used.
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

		/// Adds an inventory item to the game state.
		/// Also, it creates it.
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

		public static void CloseMenu() {
			MenuManager.CloseMenu();
		}
		
		public static void DeleteGame(string stateId) {
			State.Delete(stateId);
		}

		public static void EndArea() {
			Drawer.EndArea();
		}

		public static void ExecuteActions(string characterId, CharacterAction[] actions) {
			ExecuteActions(characterId, actions, null);
		}
		
		public static void ExecuteActions(string characterId, CharacterAction[] actions, Action furtherAction) {
			Character character = Entities.GetCharacters()[characterId];
			character.ExecuteActions(actions, furtherAction);
		}
		
		public static void Exit() {
			Application.Quit();
		}

		public static Character GetCharacter(string characterId) {
			return Entities.GetCharacters()[characterId];
		}
		
		public static string GetCurrentLanguage() {
			return Language.GetCurrentLanguage();
		}

		public static string GetCurrentRoom() {
			return State.GetCurrentRoom();
		}

		public static float GetEffectVolume() {
			return Options.GetFloat(Parameters.OptionIdEffectVolume);
		}

		public static InventoryItem GetInventoryItem(string inventoryItemId) {
			return Entities.GetInventoryItems()[inventoryItemId];
		}

		public static Item GetItem(string itemId) {
			return Entities.GetItems()[itemId];
		}
		
		public static float GetMasterVolume() {
			return Options.GetFloat(Parameters.OptionIdMasterVolume);
		}

		public static string GetPlayerCharacter() {
			return State.GetPlayerCharacter();
		}

		public static CharacterState GetPlayerCharacterState() {
			string characterId = State.GetPlayerCharacter();
			Character character = Entities.GetCharacters()[characterId];

			Direction direction = character.GetDirection();
			Vector2 position = Geometry.WorldToGamePosition(character.GetPosition());
			string roomId = State.GetCurrentRoom();
			Location location = new Location(position, roomId);

			return new CharacterState(direction, location);
		}
		
		public static float GetSongVolume() {
			return Options.GetFloat(Parameters.OptionIdSongVolume);
		}

		public static Speech GetSpeech(string speechId) {
			return Language.GetSpeech(speechId);
		}

		public static StateFile[] GetStateFiles() {
			return State.GetStateFiles();
		}

		public static GUIStyle GetStyle(string styleId) {
			return Drawer.GetStyle(styleId);
		}
		
		public static string GetText(string textId) {
			return Language.GetText(textId);
		}
		
		public static float GetVoiceVolume() {
			return Options.GetFloat(Parameters.OptionIdVoiceVolume);
		}

		public static bool HintExists(string hint) {
			return State.HintExists(hint);
		}
		
		public static bool IsMainMenuOpen() {
			return MenuManager.IsMainMenuOpen();
		}

		public static void LoadGame(string stateId) {
			LoadGame(stateId, string.Empty);
		}
		
		public static void LoadGame(string stateId, string groupId) {
			// Loads a specific state
			State.Load(stateId);

			// Loads the splash screen or the room
			LoadSplashScreenOrRoom(groupId);
		}

		public static void LockInput() {
			InputReader.LockInput();
		}

		public static void NewGame() {
			NewGame(string.Empty);
		}
		
		public static void NewGame(string groupId) {
			// Loads the initial state
			State.LoadInitial();

			// Loads the splash screen or the room
			LoadSplashScreenOrRoom(groupId);
		}

		public static void OpenMainMenu() {
			Loader.ChangeScene(Parameters.SceneMainMenu);
		}
		
		public static void OpenMenu(string menuId) {
			MenuManager.OpenMenu(menuId);
		}

		public static void RemoveCharacter(string characterId) {
			Character character;
			if (Entities.GetCharacters().TryGetValue(characterId, out character))
				character.Destroy();
			
			State.RemoveCharacter(characterId);
		}

		public static void RemoveHint(string hint) {
			State.RemoveHint(hint);
		}

		public static void RemoveInventoryItem(string inventoryItemId) {
			Entities.GetInventoryItems()[inventoryItemId].Destroy();
			State.RemoveInventoryItem(inventoryItemId);

			if (Entities.GetInventory().IsActivated())
				InventoryManager.RefreshCurrentPage();
		}
		
		public static void RemoveItem(string itemId) {
			Item item;
			if (Entities.GetItems().TryGetValue(itemId, out item))
				item.Destroy();

			State.RemoveItem(itemId);
		}

		public static void SaveGame(string stateId) {
			foreach (Character character in Entities.GetCharacters().Values) {
				string characterId = character.GetId();

				Direction direction = character.GetDirection();
				Vector2 position = Geometry.WorldToGamePosition(character.GetPosition());
				string roomId = State.GetCurrentRoom();
				Location location = new Location(position, roomId);
				CharacterState characterState = new CharacterState(direction, location);
				
				State.SetCharacterState(characterId, characterState);
			}
			
			foreach (Item item in Entities.GetItems().Values) {
				string itemId = item.GetId();

				Vector2 position = Geometry.WorldToGamePosition(item.GetPosition());
				string roomId = State.GetCurrentRoom();
				Location location = new Location(position, roomId);
				ItemState itemState = new ItemState(location);
				
				State.SetItemState(itemId, itemState);
			}
			
			State.Save(stateId);
		}

		public static void SaveOptions() {
			Options.Save();
		}

		public static void SetEffectVolume(float effectVolume) {
			Options.SetFloat(Parameters.OptionIdEffectVolume, effectVolume);
			SoundPlayer.SetEffectVolume(effectVolume);
		}
		
		public static void SetLanguage(string languageId) {
			Options.SetString(Parameters.OptionIdLanguage, languageId);
			Language.Load(languageId);
		}
		
		public static void SetMasterVolume(float masterVolume) {
			Options.SetFloat(Parameters.OptionIdMasterVolume, masterVolume);
			SoundPlayer.SetMasterVolume(masterVolume);
		}
		
		public static void SetSongVolume(float songVolume) {
			Options.SetFloat(Parameters.OptionIdSongVolume, songVolume);
			SoundPlayer.SetSongVolume(songVolume);
		}
		
		public static void SetVoiceVolume(float voiceVolume) {
			Options.SetFloat(Parameters.OptionIdVoiceVolume, voiceVolume);
			SoundPlayer.SetVoiceVolume(voiceVolume);
		}
		
		public static void StopActions(string characterId) {
			Entities.GetCharacters()[characterId].StopActions();
		}

		public static void UnlockInput() {
			InputReader.UnlockInput();
		}

		public static void UnselectInventoryItem() {
			InputReader.UnselectInventoryItem();
		}
		
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
