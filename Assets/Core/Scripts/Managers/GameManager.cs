using System;
using System.IO;
using UnityEngine;

namespace SaguFramework {

	public static class GameManager {
		
		// TODO: usar esta clase unicamente como interfaz para las clases del juego

		public static void ChangeRoom(string roomId, string entryPositionId, bool useSplashScreen) {
			// Gets the player character ID
			string playerCharacterId = StateManager.GetPlayerCharacterId();

			// Gets the new room's parameters
			RoomParameters roomParameters = ParameterManager.GetRoomParameters(roomId);

			// Gets the player character's new location
			Vector2 positionInGame = roomParameters.EntryPositions[entryPositionId];
			Location location = new Location(positionInGame, roomId);

			// Sets the player character's new location
			StateManager.SetCharacterLocation(playerCharacterId, location);
		}

		public static void CloseMenu() {
			// Closes the last opened menu
			ObjectManager.GetMenu().Close();

			// Checks if there is another opened menu and shows it
			if (ObjectManager.GetMenuCount() > 0)
				ObjectManager.GetMenu().Show();
		}

		public static void Exit() {
			Application.Quit();
		}

		public static string[] GetStateIds() {
			// TODO: errors, exceptions?

			// Gets the state files
			FileInfo[] stateFiles = UtilityManager.GetDirectoryFiles(ParameterManager.GetStateFilesDirectoryPath(), ParameterManager.StateFileExtension);

			// Orders the state files by last write time (in descending order)
			FileInfo[] orderedStateFiles = UtilityManager.OrderFilesByLastWriteTimeDescending(stateFiles);
			
			// Gets the state IDs (that is, the file's name without its extension)
			string[] stateIds = new string[orderedStateFiles.Length];
			for (int i = 0; i < orderedStateFiles.Length; i++)
				stateIds[i] = UtilityManager.GetFileNameWithoutExtension(orderedStateFiles[i]);
			
			return stateIds;
		}

		public static void LoadGame(string stateId, bool useSplashScreen) {
			// Reads the state file
			StateManager.ReadStateFile(stateId);

			// Gets the loader
			Loader loader = ObjectManager.GetLoader();

			if (useSplashScreen)
				// Loads the splash screen scene
				loader.LoadScene(ParameterManager.SceneSplashScreen);
			else
				// Loads the room scene
				loader.LoadScene(ParameterManager.SceneRoom);
		}

		public static void NewGame(bool useSplashScreen) {
			// Reads the initial state file
			StateManager.ReadInitialStateFile();

			// Gets the loader
			Loader loader = ObjectManager.GetLoader();

			if (useSplashScreen)
				// Loads the splash screen scene
				loader.LoadScene(ParameterManager.SceneSplashScreen);
			else
				// Loads the room scene
				loader.LoadScene(ParameterManager.SceneRoom);
		}

		public static void OpenMainMenu() {
			// Loads the main menu scene
			ObjectManager.GetLoader().LoadScene(ParameterManager.SceneMainMenu);
		}

		public static void OpenMenu(string menuId) {
			// Checks if there is any opened menu and hides it
			if (ObjectManager.GetMenuCount() > 0)
				ObjectManager.GetMenu().Hide();

			// Gets the menu's parameters
			MenuParameters menuParameters = ParameterManager.GetMenuParameters(menuId);
			
			// Creates the menu
			CreationManager.CreateMenu(menuParameters);
		}

		public static void SaveGame(string stateId) {
			// Writes the state file
			StateManager.WriteStateFile(stateId);
		}

	}

}
