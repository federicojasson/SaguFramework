﻿using System.Collections.Generic;

namespace SaguFramework {
	
	public class MenuHandler : Worker {

		private static bool isMainMenu;
		private static object[] parameters;

		public static void CloseMenu() {
			Stack<Menu> menus = Objects.GetMenus();

			if (menus.Count == 1) {
				if (! isMainMenu) {
					menus.Peek().Destroy();
					GameHandler.UpdateGameMode();
				}
			} else {
				menus.Peek().Destroy();
				menus.Peek().Show();
			}
		}

		public static object[] GetParameters() {
			return parameters;
		}

		public static void OpenMainMenu() {
			isMainMenu = true;
			MenuParameters parameters = Parameters.GetMainMenuParameters();
			OpenMenu(parameters);
			GameHandler.UpdateGameMode();
		}
		
		public static void OpenMenu(string menuId) {
			MenuParameters parameters = Parameters.GetMenuParameters(menuId);
			OpenMenu(parameters);
		}
		
		public static void OpenPauseMenu() {
			isMainMenu = false;
			MenuParameters parameters = Parameters.GetPauseMenuParameters();
			OpenMenu(parameters);
			GameHandler.UpdateGameMode();
		}

		public static void SetParameters(object[] parameters) {
			MenuHandler.parameters = parameters;
		}

		private static void OpenMenu(MenuParameters parameters) {
			Stack<Menu> menus = Objects.GetMenus();

			if (menus.Count > 0)
				menus.Peek().Hide();
			
			Factory.CreateMenu(parameters);
		}

	}
	
}
