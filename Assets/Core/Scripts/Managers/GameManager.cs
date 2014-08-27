using System;
using UnityEngine;

namespace SaguFramework {

	public static class GameManager {
		
		// TODO: usar esta clase unicamente como interfaz para las clases del juego

		public static void ChangeRoom(string roomId, string entryPositionId, bool useSplashScreen) {
			// TODO
		}

		public static void CloseMenu() {
			// Closes the last opened menu
			ObjectManager.GetMenu().Close();

			// Checks if there is another opened menu and shows it
			if (ObjectManager.GetMenuCount() > 0)
				ObjectManager.GetMenu().Show();
		}

		public static void CloseMenus() {
			// Closes all the opened menus
			while (ObjectManager.GetMenuCount() > 0)
				ObjectManager.GetMenu().Close();
		}

		public static void Exit() {
			Application.Quit();
		}

		public static string[] GetStateIds() {
			// TODO
			return new string[0];
		}

		public static void LoadGame(string stateId, bool useSplashScreen) {
			// Reads the state file
			StateManager.ReadStateFile(stateId);

			// TODO: change scene
		}

		public static void NewGame(bool useSplashScreen) {
			// Reads the initial state file
			StateManager.ReadInitialStateFile();
			
			// TODO: change scene
		}

		public static void OpenMainMenu() {
			// Loads the main menu scene
			LoadScene(ParameterManager.SceneMainMenu);
		}

		public static void OpenMenu(string menuId) {
			// Checks if there is any opened menu and hides it
			if (ObjectManager.GetMenuCount() > 0)
				ObjectManager.GetMenu().Hide();

			// TODO: create menu
		}

		public static void SaveGame(string stateId) {
			// Writes the state file
			StateManager.WriteStateFile(stateId);

			// TODO
		}

		private static void LoadScene(string sceneId) {
			// Defines an action to execute after the scene is unloaded
			Action onUnloadSceneAction = () => {
				Application.LoadLevel(sceneId);
			};

			// Unloads the scene
			ObjectManager.GetLoader().UnloadScene(onUnloadSceneAction);
		}

	}

}
