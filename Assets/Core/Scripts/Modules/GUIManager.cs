using System.Collections.Generic;
using UnityEngine;

//
// GUIManager - Module class
//
// TODO: write class description
//
public static class GUIManager {
	
	private static Dialog dialog;
	private static Stack<Menu> menus;
	
	static GUIManager() {
		menus = new Stack<Menu>();
	}
	
	public static bool DrawButton(string text, float x, float y, float width, float height) {
		// x and y are screen coordinates and indicate where the center of the button should be
		Rect rectangle = GetCenteredRectangle(x, y, width, height);
		return GUI.Button(rectangle, text);
	}

	public static void DrawLabel(string text, float x, float y, float maxWidth) {
		// x and y are screen coordinates and indicate where the left of the label should be
		Rect rectangle = GUILayoutUtility.GetRect(new GUIContent(text), GUI.skin.label, GUILayout.MaxWidth(maxWidth));
		rectangle.x += x;
		rectangle.y += y;
		GUI.Label(rectangle, text);
	}

	public static void DrawModalWindow(string title, float x, float y, float width, float height, GUI.WindowFunction function) {
		// x and y are screen coordinates and indicate where the center of the modal window should be
		Rect rectangle = GetCenteredRectangle(x, y, width, height);
		GUI.ModalWindow(0, rectangle, function, title);
	}

	public static void HideAll() {
		if (dialog != null)
			// Hides the dialog
			HideDialog();

		// Hides all menus
		while (menus.Count > 0)
			HideMenu();
	}
	
	public static void HideDialog() {
		// Hides the dialog
		dialog.Hide();
		dialog = null;
	}
	
	public static void HideMenu() {
		// Hides the current menu and pops it out of the stack
		menus.Pop().Hide();
		
		if (menus.Count > 0)
			// Shows the previous menu
			menus.Peek().Show();
	}

	public static void SetCursorImage(Texture2D image) {
		// Calculates an offset to match the click position with the center of the image
		Vector2 offset = new Vector2(image.width / 2, image.height / 2);

		// Sets the cursor image
		Cursor.SetCursor(image, offset, CursorMode.ForceSoftware);
	}
	
	public static void ShowDialog(Dialog dialog) {
		if (GUIManager.dialog != null)
			// Hides the dialog
			GUIManager.dialog.Hide();

		// Shows the dialog
		dialog.Show();
		GUIManager.dialog = dialog;
	}
	
	public static void ShowMenu(Menu menu) {
		if (menus.Count > 0)
			// Hides the current menu
			menus.Peek().Hide();
		
		// Shows the menu and pushes it to the stack
		menu.Show();
		menus.Push(menu);
	}

	private static Rect GetCenteredRectangle(float x, float y, float width, float height) {
		// Applies an offset to the coordinates to center the rectangle
		x -= width / 2;
		y -= height / 2;
		
		return new Rect(x, y, width, height);
	}

}
