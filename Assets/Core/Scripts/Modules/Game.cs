using System;
using UnityEngine;

namespace SaguFramework {
	
	public static class Game {

		public static void ApplyOptions() {
			string languageId = Options.GetString(Parameters.OptionIdLanguage);
			Language.Load(languageId);
			float effectVolume = Options.GetFloat(Parameters.OptionIdEffectVolume);
			SoundPlayer.SetEffectVolume(effectVolume);
			float masterVolume = Options.GetFloat(Parameters.OptionIdMasterVolume);
			SoundPlayer.SetMasterVolume(masterVolume);
			float songVolume = Options.GetFloat(Parameters.OptionIdSongVolume);
			SoundPlayer.SetSongVolume(songVolume);
			float voiceVolume = Options.GetFloat(Parameters.OptionIdVoiceVolume);
			SoundPlayer.SetVoiceVolume(voiceVolume);
			Options.Save();
		}

		public static void ChangeRoom(string roomId, string entryId) {
			ChangeRoom(roomId, entryId, string.Empty);
		}

		public static void ChangeRoom(string roomId, string entryId, string groupId) {
			RoomParameters roomParameters = Parameters.GetRoomParameters(roomId);
			EntryParameters entryParameters = roomParameters.Entries[entryId];
			
			string characterId = State.GetPlayerCharacterId();
			Direction direction = entryParameters.Direction;
			Location location = new Location(entryParameters.Position, roomId);
			CharacterState characterState = new CharacterState(direction, location);
			
			State.SetCharacterState(characterId, characterState);
			LoadSplashScreenOrRoom(groupId);
		}

		public static void CloseMenu() {
			MenuHandler.CloseMenu();
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

		public static void LoadGame(string stateId) {
			LoadGame(stateId, string.Empty);
		}

		public static void LoadGame(string stateId, string groupId) {
			State.Load(stateId);
			LoadSplashScreenOrRoom(groupId);
		}

		public static void OpenMainMenu() {
			Loader.ChangeScene(Parameters.SceneMainMenu);
		}

		public static void NewGame() {
			NewGame(string.Empty);
		}

		public static void NewGame(string groupId) {
			State.LoadInitial();
			LoadSplashScreenOrRoom(groupId);
		}

		public static void OpenMenu(string menuId) {
			MenuHandler.OpenMenu(menuId);
		}

		public static void SaveGame(string stateId) {
			foreach (Character character in Objects.GetCharacters().Values) {
				Direction direction = character.GetDirection();
				Vector2 position = Geometry.WorldToGamePosition(character.GetPosition());
				string roomId = State.GetCurrentRoomId();
				Location location = new Location(position, roomId);
				CharacterState characterState = new CharacterState(direction, location);

				State.SetCharacterState(character.GetId(), characterState);
			}

			foreach (Item item in Objects.GetItems().Values) {
				Vector2 position = Geometry.WorldToGamePosition(item.GetPosition());
				string roomId = State.GetCurrentRoomId();
				Location location = new Location(position, roomId);
				ItemState itemState = new ItemState(location);

				State.SetItemState(item.GetId(), itemState);
			}

			State.Save(stateId);
		}

		public static void StopActions(string characterId) {
			Character character = Objects.GetCharacters()[characterId];
			character.StopActions();
		}

		private static void LoadSplashScreenOrRoom(string groupId) {
			if (groupId.Length == 0)
				Loader.ChangeScene(Parameters.SceneRoom);
			else {
				SplashScreenHandler.SetCurrentGroupId(groupId);
				Loader.ChangeScene(Parameters.SceneSplashScreen);
			}
		}
		
	}
	
}
