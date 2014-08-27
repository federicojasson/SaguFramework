using System.Collections.Generic;
using UnityEngine;

namespace FrameworkNamespace {

	public static partial class GuiManager {
		
		private static MainMenu currentMainMenu;
		private static string currentMainMenuId;
		private static Stack<Menu> menus;

		public static void ClearMenus() {
			menus.Clear();
		}

		public static void CloseCurrentMenu() {
			menus.Pop().Close();
			
			if (menus.Count > 0)
				menus.Peek().Show();
		}

		public static MainMenu GetCurrentMainMenu() {
			return currentMainMenu;
		}

		public static void OpenCurrentMainMenu() {
			currentMainMenu = GuiAssets.CreateMainMenu(currentMainMenuId);
			menus.Push(currentMainMenu);
			currentMainMenu.Show();
		}

		public static void OpenMenu(string id) {
			if (menus.Count > 0)
				menus.Peek().Hide();
			
			Menu menu = GuiAssets.CreateMenu(id);
			menus.Push(menu);
			menu.Show();
		}

		public static void SetCurrentMainMenuId(string mainMenuId) {
			currentMainMenuId = mainMenuId;
		}

	}

}
