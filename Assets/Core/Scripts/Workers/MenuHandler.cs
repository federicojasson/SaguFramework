using System.Collections.Generic;

namespace SaguFramework {
	
	public class MenuHandler : Worker {

		private static bool isMainMenu;

		public static void CloseMenu() {
			Stack<Menu> menus = Objects.GetMenus();

			if (menus.Count == 1) {
				if (! isMainMenu)
					menus.Peek().Close();
			} else {
				menus.Peek().Close();
				menus.Peek().Show();
			}
		}

		public static void OpenMainMenu() {
			isMainMenu = true;
			MenuParameters parameters = Parameters.GetMainMenuParameters();
			OpenMenu(parameters);
		}
		
		public static void OpenMenu(string id) {
			MenuParameters parameters = Parameters.GetMenuParameters(id);
			OpenMenu(parameters);
		}
		
		public static void OpenPauseMenu() {
			isMainMenu = false;
			MenuParameters parameters = Parameters.GetPauseMenuParameters();
			OpenMenu(parameters);
		}

		private static void OpenMenu(MenuParameters parameters) {
			Stack<Menu> menus = Objects.GetMenus();

			if (menus.Count > 0)
				menus.Peek().Hide();
			
			Factory.CreateMenu(parameters);
		}

	}
	
}
