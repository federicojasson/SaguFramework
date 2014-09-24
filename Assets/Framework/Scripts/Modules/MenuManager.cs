using System.Collections.Generic;

namespace SaguFramework {

	/// Manages the menus.
	public static class MenuManager {

		private static bool isMainMenuOpen; // Indicates whether the main menu is opened

		/// Closes the current menu.
		public static void CloseMenu() {
			// Gets the menus
			Stack<Menu> menus = Entities.GetMenus();
			
			if (menus.Count == 1 && isMainMenuOpen)
				// The only opened menu is the main one
				return;

			// The current menu is destroyed and an effect is played
			menus.Peek().Destroy();
			SoundPlayer.PlayMenuEffect();
			
			if (menus.Count > 0)
				// There is a deactivated menu
				menus.Peek().Activate();
			else
				// The closed menu was the last one
				InputReader.RefreshInputMode();
		}

		/// Determines whether the main menu is opened.
		public static bool IsMainMenuOpen() {
			return isMainMenuOpen;
		}

		/// Opens the main menu.
		public static void OpenMainMenu() {
			// Indicates that the main menu is opened
			isMainMenuOpen = true;

			// Opens the menu
			MenuParameters parameters = Parameters.GetMainMenuParameters();
			OpenMenu(parameters);
			
			// Refreshes the input mode
			InputReader.RefreshInputMode();
		}

		/// Opens a specific menu.
		/// Receives its ID.
		public static void OpenMenu(string menuId) {
			// Plays an effect
			SoundPlayer.PlayMenuEffect();
			
			// Opens the menu
			MenuParameters menuParameters = Parameters.GetMenuParameters(menuId);
			OpenMenu(menuParameters);
		}

		/// Opens the pause menu.
		public static void OpenPauseMenu() {
			// Indicates that the main menu is not opened
			isMainMenuOpen = false;

			// Plays an effect
			SoundPlayer.PlayMenuEffect();

			// Opens the menu
			MenuParameters parameters = Parameters.GetPauseMenuParameters();
			OpenMenu(parameters);
			
			// Refreshes the input mode
			InputReader.RefreshInputMode();
		}

		/// Opens a menu.
		private static void OpenMenu(MenuParameters menuParameters) {
			// Gets the menus
			Stack<Menu> menus = Entities.GetMenus();
			
			if (menus.Count > 0)
				// There is at least one opened menu
				menus.Peek().Deactivate();

			// Creates the menu
			Factory.CreateMenu(menuParameters);
		}

	}
	
}
