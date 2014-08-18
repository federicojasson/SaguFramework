﻿using System.Collections.Generic;
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

	public static void ClearCursorLabel() {
		Factory.GetCursorLabel().enabled = false;
	}
	
	public static bool DrawButton(string text, float x, float y, float width, float height) {
		// x and y are game coordinates and indicate where the center of the button should be
		Rect rectangle = GetCenteredRectangle(x, y, width, height);
		return GUI.Button(rectangle, text);
	}

	public static void DrawCursorLabel(string text, float x, float y) {
		// x and y are game coordinates and indicate where the labeled object is

		Vector2 screenPoint = CoordinatesManager.GameToScreenPoint(new Vector2(x, y) + C.OFFSET_CURSOR_LABEL);

		GUIStyle cursorLabelStyle = Factory.GetSkin().GetStyle(C.SKIN_STYLE_CURSOR_LABEL);
		Rect rectangle = GUILayoutUtility.GetRect(new GUIContent(text), cursorLabelStyle);
		rectangle.x = screenPoint.x - rectangle.width / 2;
		rectangle.y = Screen.height - screenPoint.y - rectangle.height / 2; // Label's positions start at the top-left corner

		GUI.Label(rectangle, text, cursorLabelStyle);
	}

	public static void DrawLabel(string text, float x, float y, float maxWidth) {
		// x and y are game coordinates and indicate where the left of the label should be

		Vector2 screenPoint = CoordinatesManager.GameToScreenPoint(new Vector2(x, y));
		Vector2 screenDimensions = CoordinatesManager.GameToScreenDimensions(new Vector2(maxWidth, 0));

		Rect rectangle = GUILayoutUtility.GetRect(new GUIContent(text), GUI.skin.label, GUILayout.MaxWidth(screenDimensions.x));
		rectangle.x = screenPoint.x;
		rectangle.y = Screen.height - screenPoint.y; // Label's positions start at the top-left corner
		GUI.Label(rectangle, text);
	}

	public static void DrawModalWindow(string title, float x, float y, float width, float height, GUI.WindowFunction function) {
		// x and y are game coordinates and indicate where the center of the modal window should be
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
		// Calculates an offset in pixels to match the click point with the center of the image
		Vector2 offset = new Vector2(image.width / 2, image.height / 2); // TODO: should be converted with CoordinatesManager?

		// Sets the cursor image
		Cursor.SetCursor(image, offset, CursorMode.Auto);
	}

	public static void SetCursorLabel(string text) {
		CursorLabel cursorLabel = Factory.GetCursorLabel();

		// Enables the cursor label and sets its text
		cursorLabel.enabled = true;
		cursorLabel.SetText(text);
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

		Vector2 screenPoint = CoordinatesManager.GameToScreenPoint(new Vector2(x, y));
		Vector2 screenDimensions = CoordinatesManager.GameToScreenDimensions(new Vector2(width, height));;
		return new Rect(screenPoint.x, screenPoint.y, screenDimensions.x, screenDimensions.y);
	}

}