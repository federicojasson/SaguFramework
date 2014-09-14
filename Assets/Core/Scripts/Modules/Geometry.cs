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
			float widthInWorld = GameToWorldWidth(rectangleInGame.width);
			float heightInWorld = GameToWorldHeight(rectangleInGame.height);
			float xInWorld = GameToWorldX(rectangleInGame.x);
			float yInWorld = GameToWorldY(rectangleInGame.y);
			
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
			float gamePreferredWidthInPixels = GetGamePreferredWidthInPixels();
			float gamePreferredHeightInPixels = GetGamePreferredHeightInPixels();
			
			return gamePreferredWidthInPixels / gamePreferredHeightInPixels;
		}
		
		public static float GetGameHeightInPixels() {
			float gameAspectRatio = GetGameAspectRatio();
			float screenAspectRatio = GetScreenAspectRatio();
			float screenWidthInPixels = GetScreenWidthInPixels();
			float screenHeightInPixels = GetScreenHeightInPixels();
			
			if (gameAspectRatio > screenAspectRatio)
				return screenWidthInPixels / gameAspectRatio;
			else
				return screenHeightInPixels;
		}
		
		public static float GetGameHeightInUnits() {
			float gameHeightInPixels = GetGameHeightInPixels();
			float gameHeightInUnits = PixelsToUnits(gameHeightInPixels);
			
			return gameHeightInUnits;
		}

		public static float GetGamePreferredHeightInPixels() {
			return Parameters.GetGamePreferredHeight();
		}
		
		public static float GetGamePreferredHeightInUnits() {
			float gamePreferredHeightInPixels = GetGamePreferredHeightInPixels();
			float gamePreferredHeightInUnits = PixelsToUnits(gamePreferredHeightInPixels);
			
			return gamePreferredHeightInUnits;
		}
		
		public static float GetGamePreferredWidthInPixels() {
			return Parameters.GetGamePreferredWidth();
		}

		public static float GetGamePreferredWidthInUnits() {
			float gamePreferredWidthInPixels = GetGamePreferredWidthInPixels();
			float gamePreferredWidthInUnits = PixelsToUnits(gamePreferredWidthInPixels);

			return gamePreferredWidthInUnits;
		}

		public static Rect GetGameRectangleInGui() {
			Rect gameRectangleInScreen = GetGameRectangleInScreen();
			Rect gameRectangleInGui = ScreenToGuiRectangle(gameRectangleInScreen);
			
			return gameRectangleInGui;
		}
		
		public static Rect GetGameRectangleInScreen() {
			float gameWidthInPixels = GetGameWidthInPixels();
			float gameHeightInPixels = GetGameHeightInPixels();
			float screenWidthInPixels = GetScreenWidthInPixels();
			float screenHeightInPixels = GetScreenHeightInPixels();
			
			float widthInScreen = gameWidthInPixels;
			float heightInScreen = gameHeightInPixels;
			float xInScreen = 0.5f * (screenWidthInPixels - gameWidthInPixels);
			float yInScreen = 0.5f * (screenHeightInPixels - gameHeightInPixels);
			
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
				return screenWidthInPixels;
			else
				return screenHeightInPixels * gameAspectRatio;
		}
		
		public static float GetGameWidthInUnits() {
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
			float screenHeightInPixels = GetScreenHeightInPixels();
			float screenHeightInUnits = PixelsToUnits(screenHeightInPixels);
			
			return screenHeightInUnits;
		}
		
		public static Rect GetScreenRectangleInGui() {
			Rect screenRectangleInScreen = GetScreenRectangleInScreen();
			Rect screenRectangleInGui = ScreenToGuiRectangle(screenRectangleInScreen);
			
			return screenRectangleInGui;
		}
		
		public static Rect GetScreenRectangleInScreen() {
			float widthInScreen = GetScreenWidthInPixels();
			float heightInScreen = GetScreenHeightInPixels();
			float xInScreen = 0f;
			float yInScreen = 0f;
			
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
			float screenWidthInPixels = GetScreenWidthInPixels();
			float screenWidthInUnits = PixelsToUnits(screenWidthInPixels);
			
			return screenWidthInUnits;
		}
		
		public static Rect[] GetWindowboxRectanglesInGui() {
			Rect[] windowboxRectanglesInScreen = GetWindowboxRectanglesInScreen();
			Rect[] windowboxRectanglesInGui = new Rect[windowboxRectanglesInScreen.Length];
			
			for (int i = 0; i < windowboxRectanglesInScreen.Length; i++)
				windowboxRectanglesInGui[i] = ScreenToGuiRectangle(windowboxRectanglesInScreen[i]);
			
			return windowboxRectanglesInGui;
		}
		
		public static Rect[] GetWindowboxRectanglesInScreen() {
			Rect[] windowboxRectanglesInScreen = new Rect[4];

			float gameWidthInPixels = GetGameWidthInPixels();
			float gameHeightInPixels = GetGameHeightInPixels();
			float screenWidthInPixels = GetScreenWidthInPixels();
			float screenHeightInPixels = GetScreenHeightInPixels();
			
			float width = 0.5f * (screenWidthInPixels - gameWidthInPixels);
			float height = 0.5f * (screenHeightInPixels - gameHeightInPixels);

			windowboxRectanglesInScreen[0] = new Rect(0f, 0f, width, screenHeightInPixels);
			windowboxRectanglesInScreen[1] = new Rect(screenWidthInPixels - width, 0f, width, screenHeightInPixels);
			windowboxRectanglesInScreen[2] = new Rect(0f, 0f, screenWidthInPixels, height);
			windowboxRectanglesInScreen[3] = new Rect(0f, screenHeightInPixels - height, screenWidthInPixels, height);
			
			return windowboxRectanglesInScreen;
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
			float widthInScreen = GuiToScreenWidth(rectangleInGui.width);
			float heightInScreen = GuiToScreenHeight(rectangleInGui.height);
			float xInScreen = GuiToScreenX(rectangleInGui.x);
			float yInScreen = GuiToScreenY(rectangleInGui.y) - heightInScreen;
			
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
			float yInScreen = screenHeightInPixels - yInGui;
			
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
			float widthInGui = ScreenToGuiWidth(rectangleInScreen.width);
			float heightInGui = ScreenToGuiHeight(rectangleInScreen.height);
			float xInGui = ScreenToGuiX(rectangleInScreen.x);
			float yInGui = ScreenToGuiY(rectangleInScreen.y) - heightInGui;
			
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
			float widthInGame = WorldToGameWidth(rectangleInWorld.width);
			float heightInGame = WorldToGameHeight(rectangleInWorld.height);
			float xInGame = WorldToGameX(rectangleInWorld.x);
			float yInGame = WorldToGameY(rectangleInWorld.y);
			
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
