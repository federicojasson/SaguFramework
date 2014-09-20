using System;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {

	public static class Framework {

		public static void AddHint(string hint) {
			State.AddHint(hint);
		}

		public static void AddCharacter(string characterId, CharacterState characterState) {
			string roomId = State.GetCurrentRoom();

			if (characterState.GetLocation().GetRoom() == roomId) {
				CharacterParameters characterParameters = Parameters.GetCharacterParameters(characterId);
				RoomParameters roomParameters = Parameters.GetRoomParameters(roomId);
				Factory.CreateCharacter(characterId, characterState, characterParameters, roomParameters);
			}

			State.AddCharacter(characterId, characterState);
		}

		public static void AddInventoryItem(string inventoryItemId) {
			InventoryItemParameters inventoryItemParameters = Parameters.GetInventoryItemParameters(inventoryItemId);
			InventoryParameters inventoryParameters = Parameters.GetInventoryParameters();
			Factory.CreateInventoryItem(inventoryItemId, inventoryItemParameters, inventoryParameters);
			
			State.AddInventoryItem(inventoryItemId);

			if (Objects.GetInventory().IsActivated())
				InventoryManager.ShowLastPage();
		}
		
		public static void AddItem(string itemId, ItemState itemState) {
			string roomId = State.GetCurrentRoom();
			
			if (itemState.GetLocation().GetRoom() == roomId) {
				ItemParameters itemParameters = Parameters.GetItemParameters(itemId);
				RoomParameters roomParameters = Parameters.GetRoomParameters(roomId);
				Factory.CreateItem(itemId, itemState, itemParameters, roomParameters);
			}
			
			State.AddItem(itemId, itemState);
		}

		public static void BeginArea(float x, float y, float width, float height) {
			Drawer.BeginArea(x, y, width, height);
		}

		public static void ChangePlayerCharacter(string characterId) {
			State.SetPlayerCharacter(characterId);

			Character character = Objects.GetCharacters()[characterId];
			CameraHandler.SetCameraTarget(character);
		}

		// TODO: uncomment
		/*public static void ChangeRoom(string roomId, string entryId) {
			ChangeRoom(roomId, entryId, string.Empty);
		}*/

		public static void ChangeRoom(string roomId, string entryId, string groupId) {
			string characterId = State.GetPlayerCharacter();

			RoomParameters roomParameters = Parameters.GetRoomParameters(roomId);
			EntryParameters entryParameters = roomParameters.Entries[entryId];

			Direction direction = entryParameters.Direction;
			Location location = new Location(entryParameters.Position, roomId);
			CharacterState characterState = new CharacterState(direction, location);

			State.SetCharacterState(characterId, characterState);
			State.SetCurrentRoom(roomId);

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
			Character character = Objects.GetCharacters()[characterId];
			character.ExecuteActions(actions, furtherAction);
		}
		
		public static void Exit() {
			Application.Quit();
		}

		public static Character GetCharacter(string characterId) {
			return Objects.GetCharacters()[characterId];
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
			return Objects.GetInventoryItems()[inventoryItemId];
		}

		public static Item GetItem(string itemId) {
			return Objects.GetItems()[itemId];
		}
		
		public static float GetMasterVolume() {
			return Options.GetFloat(Parameters.OptionIdMasterVolume);
		}

		public static string GetPlayerCharacter() {
			return State.GetPlayerCharacter();
		}

		public static CharacterState GetPlayerCharacterState() {
			string characterId = State.GetPlayerCharacter();
			Character character = Objects.GetCharacters()[characterId];

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

		public static string[] GetStateIds() {
			return State.GetStateIds();
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
			State.Load(stateId);
			LoadSplashScreenOrRoom(groupId);
		}

		public static void LockInput() {
			InputReader.LockInput();
		}

		public static void NewGame() {
			NewGame(string.Empty);
		}
		
		public static void NewGame(string groupId) {
			State.LoadInitial();
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
			if (Objects.GetCharacters().TryGetValue(characterId, out character))
				character.Destroy();
			
			State.RemoveCharacter(characterId);
		}

		public static void RemoveHint(string hint) {
			State.RemoveHint(hint);
		}

		public static void RemoveInventoryItem(string inventoryItemId) {
			Objects.GetInventoryItems()[inventoryItemId].Destroy();
			State.RemoveInventoryItem(inventoryItemId);
		}
		
		public static void RemoveItem(string itemId) {
			Item item;
			if (Objects.GetItems().TryGetValue(itemId, out item))
				item.Destroy();

			State.RemoveItem(itemId);
		}

		public static void SaveGame(string stateId) {
			foreach (Character character in Objects.GetCharacters().Values) {
				string characterId = character.GetId();

				Direction direction = character.GetDirection();
				Vector2 position = Geometry.WorldToGamePosition(character.GetPosition());
				string roomId = State.GetCurrentRoom();
				Location location = new Location(position, roomId);
				CharacterState characterState = new CharacterState(direction, location);
				
				State.SetCharacterState(characterId, characterState);
			}
			
			foreach (Item item in Objects.GetItems().Values) {
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
			Objects.GetCharacters()[characterId].StopActions();
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
