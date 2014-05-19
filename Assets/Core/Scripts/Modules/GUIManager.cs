using System.Collections.Generic;
using UnityEngine;

public static class GUIManager {
	
	private static Stack<Menu> menus;
	private static Dialog dialog;
	
	static GUIManager() {
		menus = new Stack<Menu>();
	}
	
	public static bool DrawButton(string text, float x, float y, float width, float height) {
		// x and y are screen coordinates and indicate where the center of the button should be
		Rect rectangle = GetCenteredRectangle(x, y, width, height);
		return GUI.Button(rectangle, text);
	}

	public static void DrawModalWindow(string title, float x, float y, float width, float height, GUI.WindowFunction function) {
		// x and y are screen coordinates and indicate where the center of the modal window should be
		Rect rectangle = GetCenteredRectangle(x, y, width, height);
		GUI.ModalWindow(0, rectangle, function, title);
	}
	
	public static void HideDialog() {
		// Hides the current dialog
		dialog.enabled = false;

		GUIManager.dialog = null;
	}
	
	public static void HideMenu() {
		// Hides the current menu and pops it out of the stack
		menus.Pop().enabled = false;
		
		if (menus.Count > 0)
			// Shows the previous menu
			menus.Peek().enabled = true;
	}
	
	public static void ShowDialog(Dialog dialog) {
		if (GUIManager.dialog != null)
			// There is an opened dialog
			HideDialog();

		// Shows the dialog
		dialog.enabled = true;

		GUIManager.dialog = dialog;
	}
	
	public static void ShowMenu(Menu menu) {
		if (menus.Count > 0)
			// Hides the current menu
			menus.Peek().enabled = false;
		
		// Shows the menu and pushes it to the stack
		menu.enabled = true;
		menus.Push(menu);
	}

	private static Rect GetCenteredRectangle(float x, float y, float width, float height) {
		// Applies an offset to the coordinates to center the rectangle
		x -= width / 2;
		y -= height / 2;
		
		return new Rect(x, y, width, height);
	}

}
