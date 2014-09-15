using System.Collections.Generic;

namespace SaguFramework {
	
	public class MenuHandler : Worker {

		private static bool isMainMenu;
		private static Menu menu;

		public static void CloseMenu() {
			Stack<Menu> menus = Objects.GetMenus();

			if (menus.Count == 1) {
				if (! isMainMenu) {
					menus.Peek().Destroy();
					GameHandler.UpdateGameMode();
				}
			} else {
				menus.Peek().Destroy();
				menus.Peek().Activate();
			}
		}

		public static void OpenMainMenu() {
			isMainMenu = true;
			MenuParameters parameters = Parameters.GetMainMenuParameters();
			OpenMenu(parameters);
			GameHandler.UpdateGameMode();
		}
		
		public static void OpenMenu(string menuId) {
			MenuParameters menuParameters = Parameters.GetMenuParameters(menuId);
			OpenMenu(menuParameters);
		}
		
		public static void OpenPauseMenu() {
			isMainMenu = false;
			MenuParameters parameters = Parameters.GetPauseMenuParameters();
			OpenMenu(parameters);
			GameHandler.UpdateGameMode();
		}

		private static void OpenMenu(MenuParameters menuParameters) {
			Stack<Menu> menus = Objects.GetMenus();

			if (menus.Count > 0)
				menus.Peek().Deactivate();
			
			Factory.CreateMenu(menuParameters);
		}

	}
	
}
