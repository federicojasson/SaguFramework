using System.Collections.Generic;
using UnityEngine;

public static class MenuManager {

	private static Stack<Menu> menus;

	static MenuManager() {
		menus = new Stack<Menu>();
	}

	public static void HideMenu() {
		if (menus.Count > 0) {
			// Hides the current menu and pops it out of the stack
			menus.Pop().enabled = false;

			if (menus.Count > 0)
				// Shows the previous menu
				menus.Peek().enabled = true;
		}
	}

	public static void ShowMenu(Menu menu) {
		if (menus.Count > 0)
			// Hides the current menu
			menus.Peek().enabled = false;

		// Shows the menu and pushes it to the stack
		menu.enabled = true;
		menus.Push(menu);
	}
	
}
