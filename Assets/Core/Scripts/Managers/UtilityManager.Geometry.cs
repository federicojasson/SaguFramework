using UnityEngine;

public static partial class UtilityManager {
	
	public static float GameToScreenHeight(float heightInGame) {
		float gameHeightPixels = GetGameHeightPixels();
		
		return heightInGame * gameHeightPixels;
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
	
	public static float ScreenToGameHeight(float heightInScreen) {
		float gameHeightPixels = GetGameHeightPixels();
		
		return heightInScreen / gameHeightPixels;
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
		float pixelsPerUnit = Parameters.PixelsPerUnit;
		
		return heightInScreen / pixelsPerUnit;
	}

	public static float ScreenToWorldWidth(float widthInScreen) {
		float pixelsPerUnit = Parameters.PixelsPerUnit;

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
	
	public static float WorldToGameHeight(float heightInWorld) {
		float heightInScreen = WorldToScreenHeight(heightInWorld);
		float heightInGame = ScreenToGameHeight(heightInScreen);
		
		return heightInGame;
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
		float pixelsPerUnit = Parameters.PixelsPerUnit;
		
		return heightInWorld * pixelsPerUnit;
	}

	public static float WorldToScreenWidth(float widthInWorld) {
		float pixelsPerUnit = Parameters.PixelsPerUnit;

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

	private static float GetGameHeightPixels() {
		float gameAspectRatio = Parameters.GetGameAspectRatio();
		float screenAspectRatio = Screen.width / (float) Screen.height;
		
		if (gameAspectRatio > screenAspectRatio)
			return Screen.width / gameAspectRatio;
		else
			return Screen.height;
	}

	private static float GetGameHeightUnits() {
		float gameHeightPixels = GetGameHeightPixels();
		float gameHeightUnits = PixelsToUnits(gameHeightPixels);

		return gameHeightUnits;
	}

	private static float GetGameWidthPixels() {
		float gameAspectRatio = Parameters.GetGameAspectRatio();
		float screenAspectRatio = Screen.width / (float) Screen.height;
		
		if (gameAspectRatio > screenAspectRatio)
			return Screen.width;
		else
			return Screen.height * gameAspectRatio;
	}

	private static float GetGameWidthUnits() {
		float gameWidthPixels = GetGameWidthPixels();
		float gameWidthUnits = PixelsToUnits(gameWidthPixels);

		return gameWidthUnits;
	}

	private static float GetScreenHeightPixels() {
		return Screen.height;
	}

	private static float GetScreenHeightUnits() {
		float screenHeightPixels = GetScreenHeightPixels();
		float screenHeightUnits = PixelsToUnits(screenHeightPixels);
		
		return screenHeightUnits;
	}

	private static float GetScreenWidthPixels() {
		return Screen.width;
	}

	private static float GetScreenWidthUnits() {
		float screenWidthPixels = GetScreenWidthPixels();
		float screenWidthUnits = PixelsToUnits(screenWidthPixels);

		return screenWidthUnits;
	}

	private static float PixelsToUnits(float pixels) {
		float pixelsPerUnit = Parameters.PixelsPerUnit;
		
		return pixels / pixelsPerUnit;
	}

	private static float UnitsToPixels(float units) {
		float pixelsPerUnit = Parameters.PixelsPerUnit;

		return units * pixelsPerUnit;
	}

}
