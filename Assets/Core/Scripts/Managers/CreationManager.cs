using UnityEngine;

namespace SaguFramework {

	public static class CreationManager {

		// TODO: comments

		public static void CreateCharacter(CharacterParameters characterParameters, Vector2 positionInGame, float scaleFactor) {
			// Gets the image's parameters
			ImageParameters imageParameters = characterParameters.Image;
			
			// Creates an object for the character
			GameObject characterObject = new GameObject();
			Character character = characterObject.AddComponent<Character>();
			
			// Sets the character's behaviour
			character.SetBehaviour(characterParameters.Behaviour);
			
			// Creates an object for the image
			GameObject imageObject = new GameObject();
			Image image = imageObject.AddComponent<Image>();
			
			// Sets the image's parameters
			image.SetParameters(imageParameters);
			
			// Corrects the image's relative height according to the scale factor
			image.SetRelativeHeight(scaleFactor * image.GetRelativeHeight());
			
			if (imageParameters.SortingLayer.Length == 0)
				// Sets the default sorting layer for the character images
				image.SetSortingLayer(ParameterManager.SortingLayerCharacterImage);
			
			// Sets the character's position
			characterObject.transform.position = UtilityManager.GameToWorldPosition(positionInGame);
			
			// Sets the image object's parent and local position
			imageObject.transform.parent = characterObject.transform;
			imageObject.transform.localPosition = Vector3.zero;
		}

		public static void CreateItem(ItemParameters itemParameters, Vector2 positionInGame, float scaleFactor) {
			// Gets the image's parameters
			ImageParameters imageParameters = itemParameters.Image;
			
			// Creates an object for the item
			GameObject itemObject = new GameObject();
			Item item = itemObject.AddComponent<Item>();
			
			// Sets the item's behaviour
			item.SetBehaviour(itemParameters.Behaviour);
			
			// Creates an object for the image
			GameObject imageObject = new GameObject();
			Image image = imageObject.AddComponent<Image>();
			
			// Sets the image's parameters
			image.SetParameters(imageParameters);

			// Corrects the image's relative height according to the scale factor
			image.SetRelativeHeight(scaleFactor * image.GetRelativeHeight());

			if (imageParameters.SortingLayer.Length == 0)
				// Sets the default sorting layer for the item images
				image.SetSortingLayer(ParameterManager.SortingLayerItemImage);

			// Sets the item's position
			itemObject.transform.position = UtilityManager.GameToWorldPosition(positionInGame);

			// Sets the image object's parent and local position
			imageObject.transform.parent = itemObject.transform;
			imageObject.transform.localPosition = Vector3.zero;
		}
		
		public static void CreateMainMenu(MainMenuParameters mainMenuParameters) {
			// The creation process is the same for the menus than for the main menus
			CreateMenu(mainMenuParameters);
		}

		public static void CreateMenu(MenuParameters menuParameters) {
			// Gets the background image's parameters
			ImageParameters backgroundImageParameters = menuParameters.BackgroundImage;
			
			// Creates an object for the menu
			GameObject menuObject = new GameObject();
			Menu menu = menuObject.AddComponent<Menu>();

			// Sets the menu's behaviour
			menu.SetBehaviour(menuParameters.Behaviour);
			
			// Creates an object for the background image
			GameObject backgroundImageObject = new GameObject();
			Image backgroundImage = backgroundImageObject.AddComponent<Image>();
			
			// Sets the background image's parameters
			backgroundImage.SetParameters(backgroundImageParameters);
			
			if (backgroundImageParameters.SortingLayer.Length == 0)
				// Sets the default sorting layer for the menu background images
				backgroundImage.SetSortingLayer(ParameterManager.SortingLayerMenuBackgroundImage);
			
			// Sets the background image object's parent and local position
			backgroundImageObject.transform.parent = menuObject.transform;
			backgroundImageObject.transform.localPosition = Vector3.zero;
		}
		
		public static void CreateRoom(RoomParameters roomParameters) {
			// TODO
			/*// Gets the room prefab
			Room roomPrefab = instance.RoomPrefabs[id];
			
			// Instantiates the room prefab
			Room room = UtilityManager.Instantiate<Room>(roomPrefab);
			
			// Creates a game image to show the room's background
			GameImage roomBackgroundImage = UtilityManager.CreateGameImage();
			roomBackgroundImage.transform.parent = room.transform;
			roomBackgroundImage.SetParameters(room.BackgroundImageParameters);
			
			// Creates a game image to show the room's foreground
			GameImage roomForegroundImage = UtilityManager.CreateGameImage();
			roomForegroundImage.transform.parent = room.transform;
			roomForegroundImage.SetParameters(room.ForegroundImageParameters);
			
			// Sets the position in the world
			float roomHeightUnits = roomBackgroundImage.GetHeightUnits();
			float roomWidthUnits = roomBackgroundImage.GetWidthUnits();
			float gameHeightUnits = UtilityManager.GetGameHeightUnits();
			float gameWidthUnits = UtilityManager.GetGameWidthUnits();
			float xInGame = 0.5f * roomWidthUnits / gameWidthUnits;
			float yInGame = 0.5f * roomHeightUnits / gameHeightUnits;
			Vector2 positionInGame = new Vector2(xInGame, yInGame);
			room.transform.position = UtilityManager.GameToWorldPosition(positionInGame);
			
			return room;*/
		}
		
		public static void CreateSplashScreen(SplashScreenParameters splashScreenParameters) {
			// Gets the image's parameters
			ImageParameters imageParameters = splashScreenParameters.Image;

			// Creates an object for the splash screen
			GameObject splashScreenObject = new GameObject();
			SplashScreen splashScreen = splashScreenObject.AddComponent<SplashScreen>();

			// Creates an object for the image
			GameObject imageObject = new GameObject();
			Image image = imageObject.AddComponent<Image>();

			// Sets the image's parameters
			image.SetParameters(imageParameters);

			if (imageParameters.SortingLayer.Length == 0)
				// Sets the default sorting layer for the splash screen images
				image.SetSortingLayer(ParameterManager.SortingLayerSplashScreenImage);

			// Sets the image object's parent and local position
			imageObject.transform.parent = splashScreenObject.transform;
			imageObject.transform.localPosition = Vector3.zero;
		}

	}

}
