using UnityEngine;

namespace SaguFramework {

	public static class Geometry {
		
		public static float GameToWorldHeight(float heightInGame) {
			float gameHeightInUnits = GetGameHeightInUnits();

			return heightInGame * gameHeightInUnits;
		}
		
		public static Vector2 GameToWorldPosition(Vector2 positionInGame) {
			float xInWorld = GameToWorldX(positionInGame.x);
			float yInWorld = GameToWorldY(positionInGame.y);
			
			return new Vector2(xInWorld, yInWorld);
		}
		
		public static Rect GameToWorldRectangle(Rect rectangleInGame) {
			float xInWorld = GameToWorldX(rectangleInGame.x);
			float yInWorld = GameToWorldY(rectangleInGame.y);
			float widthInWorld = GameToWorldWidth(rectangleInGame.width);
			float heightInWorld = GameToWorldHeight(rectangleInGame.height);
			
			return new Rect(xInWorld, yInWorld, widthInWorld, heightInWorld);
		}

		public static Vector2 GameToWorldSize(Vector2 sizeInGame) {
			float widthInWorld = GameToWorldWidth(sizeInGame.x);
			float heightInWorld = GameToWorldHeight(sizeInGame.y);

			return new Vector2(widthInWorld, heightInWorld);
		}
		
		public static float GameToWorldWidth(float widthInGame) {
			float gameWidthInUnits = GetGameWidthInUnits();
			
			return widthInGame * gameWidthInUnits;
		}
		
		public static float GameToWorldX(float xInGame) {
			float gameWidthInUnits = GetGameWidthInUnits();

			return xInGame * gameWidthInUnits;
		}
		
		public static float GameToWorldY(float yInGame) {
			float gameHeightInUnits = GetGameHeightInUnits();
			
			return yInGame * gameHeightInUnits;
		}
		
		public static float GetGameAspectRatio() {
			return Parameters.GetGameAspectRatio();
		}
		
		public static float GetGameHeightInPixels() {
			float gameAspectRatio = GetGameAspectRatio();
			float screenAspectRatio = GetScreenAspectRatio();
			float screenWidthInPixels = GetScreenWidthInPixels();
			float screenHeightInPixels = GetScreenHeightInPixels();
			
			if (gameAspectRatio > screenAspectRatio)
				// Letterboxing
				return screenWidthInPixels / gameAspectRatio;
			else
				// Pillarboxing
				return screenHeightInPixels;
		}
		
		public static float GetGameHeightInUnits() {
			// Pixels --> Units
			float gameHeightInPixels = GetGameHeightInPixels();
			float gameHeightInUnits = PixelsToUnits(gameHeightInPixels);
			
			return gameHeightInUnits;
		}
		
		public static Rect GetGameRectangleInGui() {
			// Screen --> GUI
			Rect gameRectangleInScreen = GetGameRectangleInScreen();
			Rect gameRectangleInGui = ScreenToGuiRectangle(gameRectangleInScreen);
			
			return gameRectangleInGui;
		}
		
		public static Rect GetGameRectangleInScreen() {
			float gameWidthInPixels = GetGameWidthInPixels();
			float gameHeightInPixels = GetGameHeightInPixels();
			float screenWidthInPixels = GetScreenWidthInPixels();
			float screenHeightInPixels = GetScreenHeightInPixels();

			float xInScreen = 0.5f * (screenWidthInPixels - gameWidthInPixels);
			float yInScreen = 0.5f * (screenHeightInPixels + gameHeightInPixels);
			float widthInScreen = gameWidthInPixels;
			float heightInScreen = gameHeightInPixels;
			
			return new Rect(xInScreen, yInScreen, widthInScreen, heightInScreen);
		}

		public static Vector2 GetGameSizeInPixels() {
			float gameWidthInPixels = GetGameWidthInPixels();
			float gameHeightInPixels = GetGameHeightInPixels();

			return new Vector2(gameWidthInPixels, gameHeightInPixels);
		}
		
		public static Vector2 GetGameSizeInUnits() {
			float gameWidthInUnits = GetGameWidthInUnits();
			float gameHeightInUnits = GetGameHeightInUnits();

			return new Vector2(gameWidthInUnits, gameHeightInUnits);
		}
		
		public static float GetGameWidthInPixels() {
			float gameAspectRatio = GetGameAspectRatio();
			float screenAspectRatio = GetScreenAspectRatio();
			float screenWidthInPixels = GetScreenWidthInPixels();
			float screenHeightInPixels = GetScreenHeightInPixels();
			
			if (gameAspectRatio > screenAspectRatio)
				// Letterboxing
				return screenWidthInPixels;
			else
				// Pillarboxing
				return screenHeightInPixels * gameAspectRatio;
		}
		
		public static float GetGameWidthInUnits() {
			// Pixels --> Units
			float gameWidthInPixels = GetGameWidthInPixels();
			float gameWidthInUnits = PixelsToUnits(gameWidthInPixels);
			
			return gameWidthInUnits;
		}
		
		public static float GetPixelsPerUnit() {
			return Parameters.PixelsPerUnit;
		}
		
		public static float GetScreenAspectRatio() {
			float screenWidthInPixels = GetScreenWidthInPixels();
			float screenHeightInPixels = GetScreenHeightInPixels();
			
			return screenWidthInPixels / screenHeightInPixels;
		}
		
		public static float GetScreenHeightInPixels() {
			return Screen.height;
		}
		
		public static float GetScreenHeightInUnits() {
			// Pixels --> Units
			float screenHeightInPixels = GetScreenHeightInPixels();
			float screenHeightInUnits = PixelsToUnits(screenHeightInPixels);
			
			return screenHeightInUnits;
		}
		
		public static Rect GetScreenRectangleInGui() {
			// Screen --> GUI
			Rect screenRectangleInScreen = GetScreenRectangleInScreen();
			Rect screenRectangleInGui = ScreenToGuiRectangle(screenRectangleInScreen);
			
			return screenRectangleInGui;
		}
		
		public static Rect GetScreenRectangleInScreen() {
			float screenHeightInPixels = GetScreenHeightInPixels();
			
			float xInScreen = 0f;
			float yInScreen = screenHeightInPixels;
			float widthInScreen = GetScreenWidthInPixels();
			float heightInScreen = screenHeightInPixels;
			
			return new Rect(xInScreen, yInScreen, widthInScreen, heightInScreen);
		}

		public static Vector2 GetScreenSizeInPixels() {
			float screenWidthInPixels = GetScreenWidthInPixels();
			float screenHeightInPixels = GetScreenHeightInPixels();
			
			return new Vector2(screenWidthInPixels, screenHeightInPixels);
		}
		
		public static Vector2 GetScreenSizeInUnits() {
			float screenWidthInUnits = GetScreenWidthInUnits();
			float screenHeightInUnits = GetScreenHeightInUnits();
			
			return new Vector2(screenWidthInUnits, screenHeightInUnits);
		}
		
		public static float GetScreenWidthInPixels() {
			return Screen.width;
		}
		
		public static float GetScreenWidthInUnits() {
			// Pixels --> Units
			float screenWidthInPixels = GetScreenWidthInPixels();
			float screenWidthInUnits = PixelsToUnits(screenWidthInPixels);
			
			return screenWidthInUnits;
		}
		
		public static Rect[] GetWindowboxingRectanglesInGui() {
			// Screen --> GUI
			Rect[] windowboxingRectanglesInScreen = GetWindowboxingRectanglesInScreen();
			Rect[] windowboxingRectanglesInGui = new Rect[windowboxingRectanglesInScreen.Length];
			
			for (int i = 0; i < windowboxingRectanglesInScreen.Length; i++)
				windowboxingRectanglesInGui[i] = ScreenToGuiRectangle(windowboxingRectanglesInScreen[i]);
			
			return windowboxingRectanglesInGui;
		}
		
		public static Rect[] GetWindowboxingRectanglesInScreen() {
			Rect[] windowboxingRectanglesInScreen = new Rect[4];
			
			float gameAspectRatio = GetGameAspectRatio();
			float gameWidthInPixels = GetGameWidthInPixels();
			float gameHeightInPixels = GetGameHeightInPixels();
			float screenAspectRatio = GetScreenAspectRatio();
			float screenWidthInPixels = GetScreenWidthInPixels();
			float screenHeightInPixels = GetScreenHeightInPixels();

			float width = 0.5f * (screenWidthInPixels - gameWidthInPixels);
			float height = 0.5f * (screenHeightInPixels - gameHeightInPixels);

			// Left rectangle
			windowboxingRectanglesInScreen[0] = new Rect(0f, screenHeightInPixels, width, screenHeightInPixels);

			// Right rectangle
			windowboxingRectanglesInScreen[1] = new Rect(screenWidthInPixels - width, screenHeightInPixels, width, screenHeightInPixels);

			// Bottom rectangle
			windowboxingRectanglesInScreen[2] = new Rect(0f, height, screenWidthInPixels, height);

			// Top rectangle
			windowboxingRectanglesInScreen[3] = new Rect(0f, screenHeightInPixels, screenWidthInPixels, height);
			
			return windowboxingRectanglesInScreen;
		}
		
		public static float GuiToScreenHeight(float heightInGui) {
			return heightInGui;
		}
		
		public static Vector2 GuiToScreenPosition(Vector2 positionInGui) {
			float xInScreen = GuiToScreenX(positionInGui.x);
			float yInScreen = GuiToScreenY(positionInGui.y);
			
			return new Vector2(xInScreen, yInScreen);
		}
		
		public static Rect GuiToScreenRectangle(Rect rectangleInGui) {
			float xInScreen = GuiToScreenX(rectangleInGui.x);
			float yInScreen = GuiToScreenY(rectangleInGui.y);
			float widthInScreen = GuiToScreenWidth(rectangleInGui.width);
			float heightInScreen = GuiToScreenHeight(rectangleInGui.height);
			
			return new Rect(xInScreen, yInScreen, widthInScreen, heightInScreen);
		}

		public static Vector2 GuiToScreenSize(Vector2 sizeInGui) {
			float widthInScreen = GuiToScreenWidth(sizeInGui.x);
			float heightInScreen = GuiToScreenHeight(sizeInGui.y);
			
			return new Vector2(widthInScreen, heightInScreen);
		}
		
		public static float GuiToScreenWidth(float widthInGui) {
			return widthInGui;
		}
		
		public static float GuiToScreenX(float xInGui) {
			return xInGui;
		}
		
		public static float GuiToScreenY(float yInGui) {
			float screenHeightInPixels = GetScreenHeightInPixels();
			float yInScreen = screenHeightInPixels + yInGui;
			
			return yInScreen;
		}
		
		public static float PixelsToUnits(float pixels) {
			float pixelsPerUnit = GetPixelsPerUnit();
			
			return pixels / pixelsPerUnit;
		}
		
		public static float ScreenToGuiHeight(float heightInScreen) {
			return heightInScreen;
		}
		
		public static Vector2 ScreenToGuiPosition(Vector2 positionInScreen) {
			float xInGui = ScreenToGuiX(positionInScreen.x);
			float yInGui = ScreenToGuiY(positionInScreen.y);
			
			return new Vector2(xInGui, yInGui);
		}
		
		public static Rect ScreenToGuiRectangle(Rect rectangleInScreen) {
			float xInGui = ScreenToGuiX(rectangleInScreen.x);
			float yInGui = ScreenToGuiY(rectangleInScreen.y);
			float widthInGui = ScreenToGuiWidth(rectangleInScreen.width);
			float heightInGui = ScreenToGuiHeight(rectangleInScreen.height);
			
			return new Rect(xInGui, yInGui, widthInGui, heightInGui);
		}

		public static Vector2 ScreenToGuiSize(Vector2 sizeInScreen) {
			float widthInGui = ScreenToGuiWidth(sizeInScreen.x);
			float heightInGui = ScreenToGuiHeight(sizeInScreen.y);
			
			return new Vector2(widthInGui, heightInGui);
		}
		
		public static float ScreenToGuiWidth(float widthInScreen) {
			return widthInScreen;
		}
		
		public static float ScreenToGuiX(float xInScreen) {
			return xInScreen;
		}
		
		public static float ScreenToGuiY(float yInScreen) {
			float screenHeightInPixels = GetScreenHeightInPixels();
			float yInGui = screenHeightInPixels - yInScreen;
			
			return yInGui;
		}
		
		public static float UnitsToPixels(float units) {
			float pixelsPerUnit = GetPixelsPerUnit();
			
			return units * pixelsPerUnit;
		}
		
		public static float WorldToGameHeight(float heightInWorld) {
			float gameHeightInUnits = GetGameHeightInUnits();
			
			return heightInWorld / gameHeightInUnits;
		}
		
		public static Vector2 WorldToGamePosition(Vector2 positionInWorld) {
			float xInGame = WorldToGameX(positionInWorld.x);
			float yInGame = WorldToGameY(positionInWorld.y);
			
			return new Vector2(xInGame, yInGame);
		}
		
		public static Rect WorldToGameRectangle(Rect rectangleInWorld) {
			float xInGame = WorldToGameX(rectangleInWorld.x);
			float yInGame = WorldToGameY(rectangleInWorld.y);
			float widthInGame = WorldToGameWidth(rectangleInWorld.width);
			float heightInGame = WorldToGameHeight(rectangleInWorld.height);
			
			return new Rect(xInGame, yInGame, widthInGame, heightInGame);
		}

		public static Vector2 WorldToGameSize(Vector2 sizeInWorld) {
			float widthInGame = WorldToGameWidth(sizeInWorld.x);
			float heightInGame = WorldToGameHeight(sizeInWorld.y);
			
			return new Vector2(widthInGame, heightInGame);
		}
		
		public static float WorldToGameWidth(float widthInWorld) {
			float gameWidthInUnits = GetGameWidthInUnits();
			
			return widthInWorld / gameWidthInUnits;
		}
		
		public static float WorldToGameX(float xInWorld) {
			float gameWidthInUnits = GetGameWidthInUnits();
			
			return xInWorld / gameWidthInUnits;
		}
		
		public static float WorldToGameY(float yInWorld) {
			float gameHeightInUnits = GetGameHeightInUnits();
			
			return yInWorld / gameHeightInUnits;
		}

	}
	
}
