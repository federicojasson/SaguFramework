using System.Collections.Generic;

public static class MenuManager {

	private static Stack<Menu> menus;

	static MenuManager() {
		menus = new Stack<Menu>();
	}

	public static void CloseCurrentMenu() {
		Menu currentMenu = menus.Pop();
		GuiAssets.DestroyMenu(currentMenu);
		
		if (menus.Count > 0)
			menus.Peek().Show();
	}

	public static Menu OpenMenu(string id) {
		if (menus.Count > 0)
			menus.Peek().Hide();
		
		Menu menu = GuiAssets.CreateMenu(id);
		menus.Push(menu);
		menu.Show();

		return menu;
	}

}
