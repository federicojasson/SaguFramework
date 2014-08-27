using UnityEngine;

namespace SaguFramework.Managers {

	public static class UtilityManager {

		// TODO: comentar

		public static float GameToScreenHeight(float heightInGame) {
			float gameHeightPixels = GetGameHeightPixels();
			
			return heightInGame * gameHeightPixels;
		}
		
		public static Vector2 GameToScreenPosition(Vector2 positionInGame) {
			// Converts each coordinate to screen space
			float xInScreen = GameToScreenX(positionInGame.x);
			float yInScreen = GameToScreenY(positionInGame.y);
			
			return new Vector2(xInScreen, yInScreen);
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
			float heightInScreen = GameToScreenHeight(heightInGame);
			float heightInWorld = ScreenToWorldHeight(heightInScreen);
			
			return heightInWorld;
		}
		
		public static Vector2 GameToWorldPosition(Vector2 positionInGame) {
			// Converts the position to screen space and then to world space
			Vector2 positionInScreen = GameToScreenPosition(positionInGame);
			Vector2 positionInWorld = ScreenToWorldPosition(positionInScreen);
			
			return positionInWorld;
		}
		
		public static float GameToWorldWidth(float widthInGame) {
			float widthInScreen = GameToScreenWidth(widthInGame);
			float widthInWorld = ScreenToWorldWidth(widthInScreen);
			
			return widthInWorld;
		}
		
		public static float GameToWorldX(float xInGame) {
			float xInScreen = GameToScreenX(xInGame);
			float xInWorld = ScreenToWorldX(xInScreen);
			
			return xInWorld;
		}
		
		public static float GameToWorldY(float yInGame) {
			float yInScreen = GameToScreenY(yInGame);
			float yInWorld = ScreenToWorldY(yInScreen);
			
			return yInWorld;
		}
		
		public static float GetCameraOrthographicSizeUnits() {
			float screenHeightUnits = GetScreenHeightUnits();
			
			return screenHeightUnits / 2f;
		}
		
		public static float GetGameAspectRatio() {
			return AssetManager.GetGameAspectRatio();
		}
		
		public static float GetGameHeightPixels() {
			float gameAspectRatio = GetGameAspectRatio();
			float screenAspectRatio = GetScreenAspectRatio();
			float screenHeightPixels = GetScreenHeightPixels();
			float screenWidthPixels = GetScreenWidthPixels();
			
			if (gameAspectRatio > screenAspectRatio)
				return screenWidthPixels / gameAspectRatio;
			else
				return screenHeightPixels;
		}
		
		public static float GetGameHeightUnits() {
			float gameHeightPixels = GetGameHeightPixels();
			float gameHeightUnits = PixelsToUnits(gameHeightPixels);
			
			return gameHeightUnits;
		}
		
		public static Rect GetGameRectangle() {
			float height = GetGameHeightPixels();
			float left = UtilityManager.GameToScreenX(0f);
			float top = UtilityManager.GameToScreenY(1f);
			float width = GetGameWidthPixels();
			
			return new Rect(left, top, width, height);
		}
		
		public static float GetGameWidthPixels() {
			float gameAspectRatio = GetGameAspectRatio();
			float screenAspectRatio = GetScreenAspectRatio();
			float screenHeightPixels = GetScreenHeightPixels();
			float screenWidthPixels = GetScreenWidthPixels();
			
			if (gameAspectRatio > screenAspectRatio)
				return screenWidthPixels;
			else
				return screenHeightPixels * gameAspectRatio;
		}
		
		public static float GetGameWidthUnits() {
			float gameWidthPixels = GetGameWidthPixels();
			float gameWidthUnits = PixelsToUnits(gameWidthPixels);
			
			return gameWidthUnits;
		}
		
		public static float GetPixelsPerUnit() {
			return Parameters.PixelsPerUnit;
		}
		
		public static float GetScreenAspectRatio() {
			float screenHeightPixels = GetScreenHeightPixels();
			float screenWidthPixels = GetScreenWidthPixels();
			
			return screenWidthPixels / screenHeightPixels;
		}
		
		public static float GetScreenHeightPixels() {
			return Screen.height;
		}
		
		public static float GetScreenHeightUnits() {
			float screenHeightPixels = GetScreenHeightPixels();
			float screenHeightUnits = PixelsToUnits(screenHeightPixels);
			
			return screenHeightUnits;
		}
		
		public static float GetScreenWidthPixels() {
			return Screen.width;
		}
		
		public static float GetScreenWidthUnits() {
			float screenWidthPixels = GetScreenWidthPixels();
			float screenWidthUnits = PixelsToUnits(screenWidthPixels);
			
			return screenWidthUnits;
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
			// Converts each coordinate to game space
			float xInGame = ScreenToGameX(positionInScreen.x);
			float yInGame = ScreenToGameY(positionInScreen.y);
			
			return new Vector2(xInGame, yInGame);
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
		
		public static float ScreenToWorldHeight(float heightInScreen) {
			float pixelsPerUnit = GetPixelsPerUnit();
			
			return heightInScreen / pixelsPerUnit;
		}
		
		public static Vector2 ScreenToWorldPosition(Vector2 positionInScreen) {
			// Converts each coordinate to world space
			float xInWorld = ScreenToWorldX(positionInScreen.x);
			float yInWorld = ScreenToWorldY(positionInScreen.y);
			
			return new Vector2(xInWorld, yInWorld);
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
			float heightInScreen = WorldToScreenHeight(heightInWorld);
			float heightInGame = ScreenToGameHeight(heightInScreen);
			
			return heightInGame;
		}
		
		public static Vector2 WorldToGamePosition(Vector2 positionInWorld) {
			// Converts the position to screen space and then to game space
			Vector2 positionInScreen = WorldToScreenPosition(positionInWorld);
			Vector2 positionInGame = ScreenToGamePosition(positionInScreen);
			
			return positionInGame;
		}
		
		public static float WorldToGameWidth(float widthInWorld) {
			float widthInScreen = WorldToScreenWidth(widthInWorld);
			float widthInGame = ScreenToGameWidth(widthInScreen);
			
			return widthInGame;
		}
		
		public static float WorldToGameX(float xInWorld) {
			float xInScreen = WorldToScreenX(xInWorld);
			float xInGame = ScreenToGameX(xInScreen);
			
			return xInGame;
		}
		
		public static float WorldToGameY(float yInWorld) {
			float yInScreen = WorldToScreenY(yInWorld);
			float yInGame = ScreenToGameY(yInScreen);
			
			return yInGame;
		}
		
		public static float WorldToScreenHeight(float heightInWorld) {
			float pixelsPerUnit = GetPixelsPerUnit();
			
			return heightInWorld * pixelsPerUnit;
		}
		
		public static Vector2 WorldToScreenPosition(Vector2 positionInWorld) {
			// Converts each coordinate to screen space
			float xInScreen = WorldToScreenX(positionInWorld.x);
			float yInScreen = WorldToScreenY(positionInWorld.y);
			
			return new Vector2(xInScreen, yInScreen);
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
