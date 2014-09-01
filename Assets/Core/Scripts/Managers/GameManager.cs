using System;
using UnityEngine;

namespace SaguFramework {

	public static class GameManager {
		
		// TODO: usar esta clase unicamente como interfaz para las clases del juego

		public static void ChangeRoom(string roomId, string entryPositionId, bool useSplashScreen) {
			// Gets the new room's parameters
			RoomParameters roomParameters = ParameterManager.GetRoomParameters(roomId);

			// Gets the player character's new location
			Vector2 positionInGame = roomParameters.EntryPositions[entryPositionId];
			Location location = new Location(positionInGame, roomId);

			// Gets the player character's ID
			string playerCharacterId = StateManager.GetPlayerCharacterId();

			// Sets the player character's new location
			StateManager.SetCharacterLocation(playerCharacterId, location);

			// Sets the current room's ID
			StateManager.SetCurrentRoomId(roomId);

			// Reloads the room scene
			ObjectManager.GetLoader().LoadScene(ParameterManager.SceneRoom);
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
			return StateManager.GetStateIds();
		}

		public static void LoadGame(string stateId, bool useSplashScreen) {
			// Loads the state
			StateManager.LoadState(stateId);

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
			// Loads the initial state
			StateManager.LoadInitialState();

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

			// Shows the menu
			ObjectManager.GetMenu().Show();
		}

		public static void SaveGame(string stateId) {
			// Saves the state
			StateManager.SaveState(stateId);
		}

		public static void ShowInventory() {
			// Shows the inventory
			ObjectManager.GetInventory().Show();

			// Shows the inventory items
			// TODO
		}

	}

}
