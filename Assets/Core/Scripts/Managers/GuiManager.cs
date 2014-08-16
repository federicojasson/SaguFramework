using System.Collections.Generic;
using UnityEngine;

public static class GuiManager {

	public const int Bottom = 0;
	public const int Center = 1;
	public const int Left = 2;
	public const int Middle = 3;
	public const int Right = 4;
	public const int Top = 5;

	private static Stack<Rect> areas;
	private static Vector2 scrollPosition;

	static GuiManager() {
		areas = new Stack<Rect>();
		scrollPosition = new Vector2(- 1, 0);

		areas.Push(new Rect(0, 0, Screen.width, Screen.height));
	}

	public static void BeginArea(float leftProportion, float topProportion, float widthProportion, float heightProportion) {
		Rect area = ComputeRectangle(leftProportion, topProportion, widthProportion, heightProportion);
		BeginArea(area);
	}

	public static void BeginArea(int horizontalAlignment, int verticalAlignment, float widthProportion, float heightProportion) {
		Rect area = ComputeRectangle(horizontalAlignment, verticalAlignment, widthProportion, heightProportion);
		BeginArea(area);
	}

	public static void BeginScrollView(Vector2 initialScrollPosition) {
		if (scrollPosition.x < 0)
			scrollPosition = initialScrollPosition;

		scrollPosition = GUILayout.BeginScrollView(scrollPosition);
	}

	public static bool Button(string text) {
		return GUILayout.Button(text, GUILayout.ExpandHeight(true));
	}

	public static void EndArea() {
		GUILayout.EndArea();
		areas.Pop();
	}

	public static void EndScrollView() {
		GUILayout.EndScrollView();
	}

	// TODO: this somewhere else?
	public static void SetDefaultSkin() {
		GUI.skin = SkinManager.DefaultSkin;
	}

	private static void BeginArea(Rect area) {
		areas.Push(area);
		GUILayout.BeginArea(area);
	}
	
	private static Rect ComputeRectangle(float leftProportion, float topProportion, float widthProportion, float heightProportion) {
		Rect currentArea = areas.Peek();
		
		float width = widthProportion * currentArea.width;
		float height = heightProportion * currentArea.height;
		
		float left = leftProportion * currentArea.width - width / 2f;
		float top = topProportion * currentArea.height - height / 2f;
		
		return new Rect(left, top, width, height);
	}
	
	private static Rect ComputeRectangle(int horizontalAlignment, int verticalAlignment, float widthProportion, float heightProportion) {
		Rect currentArea = areas.Peek();
		
		float width = widthProportion * currentArea.width;
		float height = heightProportion * currentArea.height;
		
		float widthDifference = currentArea.width - width;
		float left;
		if (horizontalAlignment == Left)
			left = 0;
		else
			if (horizontalAlignment == Right)
				left = widthDifference;
		else
			left = widthDifference / 2f;
		
		float heightDifference = currentArea.height - height;
		float top;
		if (verticalAlignment == Top)
			top = 0;
		else
			if (verticalAlignment == Bottom)
				top = heightDifference;
		else
			top = heightDifference / 2f;
		
		return new Rect(left, top, width, height);
	}

}
