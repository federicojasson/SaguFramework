using System.Collections.Generic;

namespace SaguFramework {
	
	public static class MenuManager {

		private static bool isMainMenuOpen;

		public static void CloseMenu() {
			Stack<Menu> menus = Objects.GetMenus();
			
			if (menus.Count == 1 && isMainMenuOpen)
				return;
			
			SoundPlayer.PlayMenuEffect();
			menus.Peek().Destroy();
			
			if (menus.Count > 0)
				menus.Peek().Activate();
			else
				InputReader.RefreshInputMode();
		}

		public static bool IsMainMenuOpen() {
			return isMainMenuOpen;
		}

		public static void OpenMainMenu() {
			isMainMenuOpen = true;

			MenuParameters parameters = Parameters.GetMainMenuParameters();
			OpenMenu(parameters);
			InputReader.RefreshInputMode();
		}
		
		public static void OpenMenu(string menuId) {
			SoundPlayer.PlayMenuEffect();
			MenuParameters menuParameters = Parameters.GetMenuParameters(menuId);
			OpenMenu(menuParameters);
		}

		public static void OpenPauseMenu() {
			isMainMenuOpen = false;
			
			SoundPlayer.PlayMenuEffect();
			MenuParameters parameters = Parameters.GetPauseMenuParameters();
			OpenMenu(parameters);
			InputReader.RefreshInputMode();
		}
		
		private static void OpenMenu(MenuParameters menuParameters) {
			Stack<Menu> menus = Objects.GetMenus();
			
			if (menus.Count > 0)
				menus.Peek().Deactivate();

			Factory.CreateMenu(menuParameters);
		}

	}
	
}
