using System.Collections.Generic;
using UnityEngine;

public static class MenuManager {

	private static Stack<Menu> menus;
	private static MenuManagerWorker worker;

	static MenuManager() {
		menus = new Stack<Menu>();
	}

	public static void CloseCurrentMenu() {
		Menu currentMenu = menus.Pop();
		//currentMenu.Hide(); TODO: necessary?
		Object.Destroy(currentMenu.gameObject);

		if (menus.Count > 0)
			menus.Peek().Show();
	}

	public static void OpenMenu(string id) {
		if (menus.Count > 0)
			menus.Peek().Hide();

		Menu menu = CreateMenu(id);
		menus.Push(menu);
		menu.Show();
	}

	public static void SetWorker(MenuManagerWorker worker) {
		MenuManager.worker = worker;
	}
	
	private static Menu CreateMenu(string id) {
		Menu menuModel = worker.MenuModels[id];
		return (Menu) Object.Instantiate(menuModel);
	}
	
}
