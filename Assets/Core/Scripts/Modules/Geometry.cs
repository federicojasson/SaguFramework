using UnityEngine;

namespace SaguFramework {

	public static class Geometry {
		
		public static float GameToGuiHeight(float heightInGame) {
			// Game --> Screen --> GUI
			float heightInScreen = GameToScreenHeight(heightInGame);
			float heightInGui = ScreenToGuiHeight(heightInScreen);
			
			return heightInGui;
		}
		
		public static Vector2 GameToGuiPosition(Vector2 positionInGame) {
			// Game --> Screen --> GUI
			Vector2 positionInScreen = GameToScreenPosition(positionInGame);
			Vector2 positionInGui = ScreenToGuiPosition(positionInScreen);
			
			return positionInGui;
		}
		
		public static Rect GameToGuiRectangle(Rect rectangleInGame) {
			// Game --> Screen --> GUI
			Rect rectangleInScreen = GameToScreenRectangle(rectangleInGame);
			Rect rectangleInGui = ScreenToGuiRectangle(rectangleInScreen);
			
			return rectangleInGui;
		}
		
		public static float GameToGuiWidth(float widthInGame) {
			// Game --> Screen --> GUI
			float widthInScreen = GameToScreenWidth(widthInGame);
			float widthInGui = ScreenToGuiWidth(widthInScreen);
			
			return widthInGui;
		}
		
		public static float GameToGuiX(float xInGame) {
			// Game --> Screen --> GUI
			float xInScreen = GameToScreenX(xInGame);
			float xInGui = ScreenToGuiX(xInScreen);
			
			return xInGui;
		}
		
		public static float GameToGuiY(float yInGame) {
			// Game --> Screen --> GUI
			float yInScreen = GameToScreenY(yInGame);
			float yInGui = ScreenToGuiY(yInScreen);
			
			return yInGui;
		}
		
		public static float GameToScreenHeight(float heightInGame) {
			float gameHeightPixels = GetGameHeightPixels();
			
			return heightInGame * gameHeightPixels;
		}
		
		public static Vector2 GameToScreenPosition(Vector2 positionInGame) {
			// Game --> Screen
			float xInScreen = GameToScreenX(positionInGame.x);
			float yInScreen = GameToScreenY(positionInGame.y);
			
			return new Vector2(xInScreen, yInScreen);
		}
		
		public static Rect GameToScreenRectangle(Rect rectangleInGame) {
			// Game --> Screen
			float xInScreen = GameToScreenX(rectangleInGame.x);
			float yInScreen = GameToScreenY(rectangleInGame.y);
			float widthInScreen = GameToScreenWidth(rectangleInGame.width);
			float heightInScreen = GameToScreenHeight(rectangleInGame.height);
			
			return new Rect(xInScreen, yInScreen, widthInScreen, heightInScreen);
		}
		
		public static float GameToScreenWidth(float widthInGame) {
			float gameWidthPixels = GetGameWidthPixels();
			
			return widthInGame * gameWidthPixels;
		}
		
		public static float GameToScreenX(float xInGame) {
			float gameWidthPixels = GetGameWidthPixels();
			float screenWidthPixels = GetScreenWidthPixels();
			
			return (xInGame - 0.5f) * gameWidthPixels + 0.5f * screenWidthPixels;
		}
		
		public static float GameToScreenY(float yInGame) {
			float gameHeightPixels = GetGameHeightPixels();
			float screenHeightPixels = GetScreenHeightPixels();
			
			return (yInGame - 0.5f) * gameHeightPixels + 0.5f * screenHeightPixels;
		}
		
		public static float GameToWorldHeight(float heightInGame) {
			// Game --> Screen --> World
			float heightInScreen = GameToScreenHeight(heightInGame);
			float heightInWorld = ScreenToWorldHeight(heightInScreen);
			
			return heightInWorld;
		}
		
		public static Vector2 GameToWorldPosition(Vector2 positionInGame) {
			// Game --> Screen --> World
			Vector2 positionInScreen = GameToScreenPosition(positionInGame);
			Vector2 positionInWorld = ScreenToWorldPosition(positionInScreen);
			
			return positionInWorld;
		}
		
		public static Rect GameToWorldRectangle(Rect rectangleInGame) {
			// Game --> Screen --> World
			Rect rectangleInScreen = GameToScreenRectangle(rectangleInGame);
			Rect rectangleInWorld = ScreenToWorldRectangle(rectangleInScreen);
			
			return rectangleInWorld;
		}
		
		public static float GameToWorldWidth(float widthInGame) {
			// Game --> Screen --> World
			float widthInScreen = GameToScreenWidth(widthInGame);
			float widthInWorld = ScreenToWorldWidth(widthInScreen);
			
			return widthInWorld;
		}
		
		public static float GameToWorldX(float xInGame) {
			// Game --> Screen --> World
			float xInScreen = GameToScreenX(xInGame);
			float xInWorld = ScreenToWorldX(xInScreen);
			
			return xInWorld;
		}
		
		public static float GameToWorldY(float yInGame) {
			// Game --> Screen --> World
			float yInScreen = GameToScreenY(yInGame);
			float yInWorld = ScreenToWorldY(yInScreen);
			
			return yInWorld;
		}
		
		public static float GetGameAspectRatio() {
			return Parameters.GetGameAspectRatio();
		}
		
		public static float GetGameHeightPixels() {
			float gameAspectRatio = GetGameAspectRatio();
			float screenAspectRatio = GetScreenAspectRatio();
			float screenWidthPixels = GetScreenWidthPixels();
			float screenHeightPixels = GetScreenHeightPixels();
			
			if (gameAspectRatio > screenAspectRatio)
				// Letterboxing
				return screenWidthPixels / gameAspectRatio;
			else
				// Pillarboxing
				return screenHeightPixels;
		}
		
		public static float GetGameHeightUnits() {
			// Pixels --> Units
			float gameHeightPixels = GetGameHeightPixels();
			float gameHeightUnits = PixelsToUnits(gameHeightPixels);
			
			return gameHeightUnits;
		}
		
		public static Rect GetGameRectangleInGame() {
			// Screen --> Game
			Rect gameRectangleInScreen = GetGameRectangleInScreen();
			Rect gameRectangleInGame = ScreenToGameRectangle(gameRectangleInScreen);
			
			return gameRectangleInGame;
		}
		
		public static Rect GetGameRectangleInGui() {
			// Screen --> GUI
			Rect gameRectangleInScreen = GetGameRectangleInScreen();
			Rect gameRectangleInGui = ScreenToGuiRectangle(gameRectangleInScreen);
			
			return gameRectangleInGui;
		}
		
		public static Rect GetGameRectangleInScreen() {
			float xInScreen = GameToScreenX(0f);
			float yInScreen = GameToScreenY(1f);
			float widthInScreen = GetGameWidthPixels();
			float heightInScreen = GetGameHeightPixels();
			
			return new Rect(xInScreen, yInScreen, widthInScreen, heightInScreen);
		}
		
		public static Rect GetGameRectangleInWorld() {
			// Screen --> World
			Rect gameRectangleInScreen = GetGameRectangleInScreen();
			Rect gameRectangleInWorld = ScreenToWorldRectangle(gameRectangleInScreen);
			
			return gameRectangleInWorld;
		}
		
		public static float GetGameWidthPixels() {
			float gameAspectRatio = GetGameAspectRatio();
			float screenAspectRatio = GetScreenAspectRatio();
			float screenWidthPixels = GetScreenWidthPixels();
			float screenHeightPixels = GetScreenHeightPixels();
			
			if (gameAspectRatio > screenAspectRatio)
				// Letterboxing
				return screenWidthPixels;
			else
				// Pillarboxing
				return screenHeightPixels * gameAspectRatio;
		}
		
		public static float GetGameWidthUnits() {
			// Pixels --> Units
			float gameWidthPixels = GetGameWidthPixels();
			float gameWidthUnits = PixelsToUnits(gameWidthPixels);
			
			return gameWidthUnits;
		}
		
		public static float GetPixelsPerUnit() {
			return Parameters.PixelsPerUnit;
		}
		
		public static float GetScreenAspectRatio() {
			float screenWidthPixels = GetScreenWidthPixels();
			float screenHeightPixels = GetScreenHeightPixels();
			
			return screenWidthPixels / screenHeightPixels;
		}
		
		public static float GetScreenHeightPixels() {
			return Screen.height;
		}
		
		public static float GetScreenHeightUnits() {
			// Pixels --> Units
			float screenHeightPixels = GetScreenHeightPixels();
			float screenHeightUnits = PixelsToUnits(screenHeightPixels);
			
			return screenHeightUnits;
		}
		
		public static Rect GetScreenRectangleInGame() {
			// Screen --> Game
			Rect screenRectangleInScreen = GetScreenRectangleInScreen();
			Rect screenRectangleInGame = ScreenToGameRectangle(screenRectangleInScreen);
			
			return screenRectangleInGame;
		}
		
		public static Rect GetScreenRectangleInGui() {
			// Screen --> GUI
			Rect screenRectangleInScreen = GetScreenRectangleInScreen();
			Rect screenRectangleInGui = ScreenToGuiRectangle(screenRectangleInScreen);
			
			return screenRectangleInGui;
		}
		
		public static Rect GetScreenRectangleInScreen() {
			float screenHeightPixels = GetScreenHeightPixels();
			
			float xInScreen = 0f;
			float yInScreen = screenHeightPixels;
			float widthInScreen = GetScreenWidthPixels();
			float heightInScreen = screenHeightPixels;
			
			return new Rect(xInScreen, yInScreen, widthInScreen, heightInScreen);
		}
		
		public static Rect GetScreenRectangleInWorld() {
			// Screen --> World
			Rect screenRectangleInScreen = GetScreenRectangleInScreen();
			Rect screenRectangleInWorld = ScreenToWorldRectangle(screenRectangleInScreen);
			
			return screenRectangleInWorld;
		}
		
		public static float GetScreenWidthPixels() {
			return Screen.width;
		}
		
		public static float GetScreenWidthUnits() {
			// Pixels --> Units
			float screenWidthPixels = GetScreenWidthPixels();
			float screenWidthUnits = PixelsToUnits(screenWidthPixels);
			
			return screenWidthUnits;
		}
		
		public static Rect[] GetWindowboxingRectanglesInGame() {
			// Screen --> Game
			Rect[] windowboxingRectanglesInScreen = GetWindowboxingRectanglesInScreen();
			Rect[] windowboxingRectanglesInGame = new Rect[windowboxingRectanglesInScreen.Length];
			
			for (int i = 0; i < windowboxingRectanglesInScreen.Length; i++)
				windowboxingRectanglesInGame[i] = ScreenToGameRectangle(windowboxingRectanglesInScreen[i]);
			
			return windowboxingRectanglesInGame;
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
			Rect[] windowboxingRectanglesInScreen = new Rect[2];
			
			float gameAspectRatio = GetGameAspectRatio();
			float screenAspectRatio = GetScreenAspectRatio();
			float gameWidthPixels = GetGameWidthPixels();
			float gameHeightPixels = GetGameHeightPixels();
			
			if (gameAspectRatio > screenAspectRatio) {
				// Letterboxing
				
				float screenHeightPixels = GetScreenHeightPixels();
				
				float width = gameWidthPixels;
				float height = (screenHeightPixels - gameHeightPixels) / 2f;
				float x = GameToScreenX(0f);
				
				float bottomRectangleY = GameToScreenY(0f);
				float topRectangleY = screenHeightPixels;
				
				// Bottom rectangle
				windowboxingRectanglesInScreen[0] = new Rect(x, bottomRectangleY, width, height);
				
				// Top rectangle
				windowboxingRectanglesInScreen[1] = new Rect(x, topRectangleY, width, height);
			} else {
				// Pillarboxing
				
				float screenWidthPixels = GetScreenWidthPixels();
				
				float width = (screenWidthPixels - gameWidthPixels) / 2f;
				float height = gameHeightPixels;
				float y = GameToScreenY(1f);
				
				float leftRectangleX = 0f;
				float rightRectangleX = GameToScreenX(1f);
				
				// Left rectangle
				windowboxingRectanglesInScreen[0] = new Rect(leftRectangleX, y, width, height);
				
				// Right rectangle
				windowboxingRectanglesInScreen[1] = new Rect(rightRectangleX, y, width, height);
			}
			
			return windowboxingRectanglesInScreen;
		}
		
		public static Rect[] GetWindowboxingRectanglesInWorld() {
			// Screen --> World
			Rect[] windowboxingRectanglesInScreen = GetWindowboxingRectanglesInScreen();
			Rect[] windowboxingRectanglesInWorld = new Rect[windowboxingRectanglesInScreen.Length];
			
			for (int i = 0; i < windowboxingRectanglesInScreen.Length; i++)
				windowboxingRectanglesInWorld[i] = ScreenToWorldRectangle(windowboxingRectanglesInScreen[i]);
			
			return windowboxingRectanglesInWorld;
		}
		
		public static float GuiToGameHeight(float heightInGui) {
			// GUI --> Screen --> Game
			float heightInScreen = GuiToScreenHeight(heightInGui);
			float heightInGame = ScreenToGameHeight(heightInScreen);
			
			return heightInGame;
		}
		
		public static Vector2 GuiToGamePosition(Vector2 positionInGui) {
			// GUI --> Screen --> Game
			Vector2 positionInScreen = GuiToScreenPosition(positionInGui);
			Vector2 positionInGame = ScreenToGamePosition(positionInScreen);
			
			return positionInGame;
		}
		
		public static Rect GuiToGameRectangle(Rect rectangleInGui) {
			// GUI --> Screen --> Game
			Rect rectangleInScreen = GuiToScreenRectangle(rectangleInGui);
			Rect rectangleInGame = ScreenToGameRectangle(rectangleInScreen);
			
			return rectangleInGame;
		}
		
		public static float GuiToGameWidth(float widthInGui) {
			// GUI --> Screen --> Game
			float widthInScreen = GuiToScreenWidth(widthInGui);
			float widthInGame = ScreenToGameWidth(widthInScreen);
			
			return widthInGame;
		}
		
		public static float GuiToGameX(float xInGui) {
			// GUI --> Screen --> Game
			float xInScreen = GuiToScreenX(xInGui);
			float xInGame = ScreenToGameX(xInScreen);
			
			return xInGame;
		}
		
		public static float GuiToGameY(float yInGui) {
			// GUI --> Screen --> Game
			float yInScreen = GuiToScreenY(yInGui);
			float yInGame = ScreenToGameY(yInScreen);
			
			return yInGame;
		}
		
		public static float GuiToScreenHeight(float heightInGui) {
			float heightInScreen = heightInGui;
			
			return heightInScreen;
		}
		
		public static Vector2 GuiToScreenPosition(Vector2 positionInGui) {
			// GUI --> Screen
			float xInScreen = GuiToScreenX(positionInGui.x);
			float yInScreen = GuiToScreenY(positionInGui.y);
			
			return new Vector2(xInScreen, yInScreen);
		}
		
		public static Rect GuiToScreenRectangle(Rect rectangleInGui) {
			// GUI --> Screen
			float xInScreen = GuiToScreenX(rectangleInGui.x);
			float yInScreen = GuiToScreenY(rectangleInGui.y);
			float widthInScreen = GuiToScreenWidth(rectangleInGui.width);
			float heightInScreen = GuiToScreenHeight(rectangleInGui.height);
			
			return new Rect(xInScreen, yInScreen, widthInScreen, heightInScreen);
		}
		
		public static float GuiToScreenWidth(float widthInGui) {
			float widthInScreen = widthInGui;
			
			return widthInScreen;
		}
		
		public static float GuiToScreenX(float xInGui) {
			float xInScreen = xInGui;
			
			return xInScreen;
		}
		
		public static float GuiToScreenY(float yInGui) {
			float screenHeightPixels = GetScreenHeightPixels();
			float yInScreen = screenHeightPixels + yInGui;
			
			return yInScreen;
		}
		
		public static float GuiToWorldHeight(float heightInGui) {
			// GUI --> Screen --> World
			float heightInScreen = GuiToScreenHeight(heightInGui);
			float heightInWorld = ScreenToWorldHeight(heightInScreen);
			
			return heightInWorld;
		}
		
		public static Vector2 GuiToWorldPosition(Vector2 positionInGui) {
			// GUI --> Screen --> World
			Vector2 positionInScreen = GuiToScreenPosition(positionInGui);
			Vector2 positionInWorld = ScreenToWorldPosition(positionInScreen);
			
			return positionInWorld;
		}
		
		public static Rect GuiToWorldRectangle(Rect rectangleInGui) {
			// GUI --> Screen --> World
			Rect rectangleInScreen = GuiToScreenRectangle(rectangleInGui);
			Rect rectangleInWorld = ScreenToWorldRectangle(rectangleInScreen);
			
			return rectangleInWorld;
		}
		
		public static float GuiToWorldWidth(float widthInGui) {
			// GUI --> Screen --> World
			float widthInScreen = GuiToScreenWidth(widthInGui);
			float widthInWorld = ScreenToWorldWidth(widthInScreen);
			
			return widthInWorld;
		}
		
		public static float GuiToWorldX(float xInGui) {
			// GUI --> Screen --> World
			float xInScreen = GuiToScreenX(xInGui);
			float xInWorld = ScreenToWorldX(xInScreen);
			
			return xInWorld;
		}
		
		public static float GuiToWorldY(float yInGui) {
			// GUI --> Screen --> World
			float yInScreen = GuiToScreenY(yInGui);
			float yInWorld = ScreenToWorldY(yInScreen);
			
			return yInWorld;
		}
		
		public static float PixelsToUnits(float pixels) {
			float pixelsPerUnit = GetPixelsPerUnit();
			
			return pixels / pixelsPerUnit;
		}
		
		public static float ScreenToGameHeight(float heightInScreen) {
			float gameHeightPixels = GetGameHeightPixels();
			
			return heightInScreen / gameHeightPixels;
		}
		
		public static Vector2 ScreenToGamePosition(Vector2 positionInScreen) {
			// Screen --> Game
			float xInGame = ScreenToGameX(positionInScreen.x);
			float yInGame = ScreenToGameY(positionInScreen.y);
			
			return new Vector2(xInGame, yInGame);
		}
		
		public static Rect ScreenToGameRectangle(Rect rectangleInScreen) {
			// Screen --> Game
			float xInGame = ScreenToGameX(rectangleInScreen.x);
			float yInGame = ScreenToGameY(rectangleInScreen.y);
			float widthInGame = ScreenToGameWidth(rectangleInScreen.width);
			float heightInGame = ScreenToGameHeight(rectangleInScreen.height);
			
			return new Rect(xInGame, yInGame, widthInGame, heightInGame);
		}
		
		public static float ScreenToGameWidth(float widthInScreen) {
			float gameWidthPixels = GetGameWidthPixels();
			
			return widthInScreen / gameWidthPixels;
		}
		
		public static float ScreenToGameX(float xInScreen) {
			float gameWidthPixels = GetGameWidthPixels();
			float screenWidthPixels = GetScreenWidthPixels();
			
			return (xInScreen - 0.5f * screenWidthPixels) / gameWidthPixels + 0.5f;
		}
		
		public static float ScreenToGameY(float yInScreen) {
			float gameHeightPixels = GetGameHeightPixels();
			float screenHeightPixels = GetScreenHeightPixels();
			
			return (yInScreen - 0.5f * screenHeightPixels) / gameHeightPixels + 0.5f;
		}
		
		public static float ScreenToGuiHeight(float heightInScreen) {
			float heightInGui = heightInScreen;
			
			return heightInGui;
		}
		
		public static Vector2 ScreenToGuiPosition(Vector2 positionInScreen) {
			// Screen --> GUI
			float xInGui = ScreenToGuiX(positionInScreen.x);
			float yInGui = ScreenToGuiY(positionInScreen.y);
			
			return new Vector2(xInGui, yInGui);
		}
		
		public static Rect ScreenToGuiRectangle(Rect rectangleInScreen) {
			// Screen --> Game
			float xInGui = ScreenToGuiX(rectangleInScreen.x);
			float yInGui = ScreenToGuiY(rectangleInScreen.y);
			float widthInGui = ScreenToGuiWidth(rectangleInScreen.width);
			float heightInGui = ScreenToGuiHeight(rectangleInScreen.height);
			
			return new Rect(xInGui, yInGui, widthInGui, heightInGui);
		}
		
		public static float ScreenToGuiWidth(float widthInScreen) {
			float widthInGui = widthInScreen;
			
			return widthInGui;
		}
		
		public static float ScreenToGuiX(float xInScreen) {
			float xInGui = xInScreen;
			
			return xInGui;
		}
		
		public static float ScreenToGuiY(float yInScreen) {
			float screenHeightPixels = GetScreenHeightPixels();
			float yInGui = screenHeightPixels - yInScreen;
			
			return yInGui;
		}
		
		public static float ScreenToWorldHeight(float heightInScreen) {
			float pixelsPerUnit = GetPixelsPerUnit();
			
			return heightInScreen / pixelsPerUnit;
		}
		
		public static Vector2 ScreenToWorldPosition(Vector2 positionInScreen) {
			// Screen --> World
			float xInWorld = ScreenToWorldX(positionInScreen.x);
			float yInWorld = ScreenToWorldY(positionInScreen.y);
			
			return new Vector2(xInWorld, yInWorld);
		}
		
		public static Rect ScreenToWorldRectangle(Rect rectangleInScreen) {
			// Screen --> Game
			float xInWorld = ScreenToWorldX(rectangleInScreen.x);
			float yInWorld = ScreenToWorldY(rectangleInScreen.y);
			float widthInWorld = ScreenToWorldWidth(rectangleInScreen.width);
			float heightInWorld = ScreenToWorldHeight(rectangleInScreen.height);
			
			return new Rect(xInWorld, yInWorld, widthInWorld, heightInWorld);
		}
		
		public static float ScreenToWorldWidth(float widthInScreen) {
			float pixelsPerUnit = GetPixelsPerUnit();
			
			return widthInScreen / pixelsPerUnit;
		}
		
		public static float ScreenToWorldX(float xInScreen) {
			float xInWorld = PixelsToUnits(xInScreen);
			
			return xInWorld;
		}
		
		public static float ScreenToWorldY(float yInScreen) {
			float yInWorld = PixelsToUnits(yInScreen);
			
			return yInWorld;
		}
		
		public static float UnitsToPixels(float units) {
			float pixelsPerUnit = GetPixelsPerUnit();
			
			return units * pixelsPerUnit;
		}
		
		public static float WorldToGameHeight(float heightInWorld) {
			// World --> Screen --> Game
			float heightInScreen = WorldToScreenHeight(heightInWorld);
			float heightInGame = ScreenToGameHeight(heightInScreen);
			
			return heightInGame;
		}
		
		public static Vector2 WorldToGamePosition(Vector2 positionInWorld) {
			// World --> Screen --> Game
			Vector2 positionInScreen = WorldToScreenPosition(positionInWorld);
			Vector2 positionInGame = ScreenToGamePosition(positionInScreen);
			
			return positionInGame;
		}
		
		public static Rect WorldToGameRectangle(Rect rectangleInWorld) {
			// World --> Screen --> Game
			Rect rectangleInScreen = WorldToScreenRectangle(rectangleInWorld);
			Rect rectangleInGame = ScreenToGameRectangle(rectangleInScreen);
			
			return rectangleInGame;
		}
		
		public static float WorldToGameWidth(float widthInWorld) {
			// World --> Screen --> Game
			float widthInScreen = WorldToScreenWidth(widthInWorld);
			float widthInGame = ScreenToGameWidth(widthInScreen);
			
			return widthInGame;
		}
		
		public static float WorldToGameX(float xInWorld) {
			// World --> Screen --> Game
			float xInScreen = WorldToScreenX(xInWorld);
			float xInGame = ScreenToGameX(xInScreen);
			
			return xInGame;
		}
		
		public static float WorldToGameY(float yInWorld) {
			// World --> Screen --> Game
			float yInScreen = WorldToScreenY(yInWorld);
			float yInGame = ScreenToGameY(yInScreen);
			
			return yInGame;
		}
		
		public static float WorldToGuiHeight(float heightInWorld) {
			// World --> Screen --> GUI
			float heightInScreen = WorldToScreenHeight(heightInWorld);
			float heightInGui = ScreenToGuiHeight(heightInScreen);
			
			return heightInGui;
		}
		
		public static Vector2 WorldToGuiPosition(Vector2 positionInWorld) {
			// World --> Screen --> GUI
			Vector2 positionInScreen = WorldToScreenPosition(positionInWorld);
			Vector2 positionInGui = ScreenToGuiPosition(positionInScreen);
			
			return positionInGui;
		}
		
		public static Rect WorldToGuiRectangle(Rect rectangleInWorld) {
			// World --> Screen --> GUI
			Rect rectangleInScreen = WorldToScreenRectangle(rectangleInWorld);
			Rect rectangleInGui = ScreenToGuiRectangle(rectangleInScreen);
			
			return rectangleInGui;
		}
		
		public static float WorldToGuiWidth(float widthInWorld) {
			// World --> Screen --> GUI
			float widthInScreen = WorldToScreenWidth(widthInWorld);
			float widthInGui = ScreenToGuiWidth(widthInScreen);
			
			return widthInGui;
		}
		
		public static float WorldToGuiX(float xInWorld) {
			// World --> Screen --> GUI
			float xInScreen = WorldToScreenX(xInWorld);
			float xInGui = ScreenToGuiX(xInScreen);
			
			return xInGui;
		}
		
		public static float WorldToGuiY(float yInWorld) {
			// World --> Screen --> GUI
			float yInScreen = WorldToScreenY(yInWorld);
			float yInGui = ScreenToGuiY(yInScreen);
			
			return yInGui;
		}
		
		public static float WorldToScreenHeight(float heightInWorld) {
			float pixelsPerUnit = GetPixelsPerUnit();
			
			return heightInWorld * pixelsPerUnit;
		}
		
		public static Vector2 WorldToScreenPosition(Vector2 positionInWorld) {
			// World --> Screen
			float xInScreen = WorldToScreenX(positionInWorld.x);
			float yInScreen = WorldToScreenY(positionInWorld.y);
			
			return new Vector2(xInScreen, yInScreen);
		}
		
		public static Rect WorldToScreenRectangle(Rect rectangleInWorld) {
			// World --> Screen
			float xInScreen = WorldToScreenX(rectangleInWorld.x);
			float yInScreen = WorldToScreenY(rectangleInWorld.y);
			float widthInScreen = WorldToScreenWidth(rectangleInWorld.width);
			float heightInScreen = WorldToScreenHeight(rectangleInWorld.height);
			
			return new Rect(xInScreen, yInScreen, widthInScreen, heightInScreen);
		}
		
		public static float WorldToScreenWidth(float widthInWorld) {
			float pixelsPerUnit = GetPixelsPerUnit();
			
			return widthInWorld * pixelsPerUnit;
		}
		
		public static float WorldToScreenX(float xInWorld) {
			float xInScreen = UnitsToPixels(xInWorld);
			
			return xInScreen;
		}
		
		public static float WorldToScreenY(float yInWorld) {
			float yInScreen = UnitsToPixels(yInWorld);
			
			return yInScreen;
		}

	}
	
}
