using UnityEngine;

namespace SaguFramework {

	public static class CreationManager {

		public static void CreateCharacter(CharacterParameters characterParameters, Vector2 positionInGame, float scaleFactor) {
			// Gets the image's parameters
			ImageParameters imageParameters = characterParameters.Image;
			
			// Creates an object for the character
			GameObject characterObject = new GameObject();
			Character character = characterObject.AddComponent<Character>();
			
			// Instantiates the behaviour prefab
			CharacterBehaviour characterBehaviour = (CharacterBehaviour) Object.Instantiate(characterParameters.Behaviour);
			
			// Sets the character's behaviour
			character.SetBehaviour(characterBehaviour);
			
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
			
			// Connects the objects
			imageObject.transform.parent = characterObject.transform;
			imageObject.transform.localPosition = Vector3.zero;
			characterBehaviour.transform.parent = characterObject.transform;
			characterBehaviour.transform.localPosition = Vector3.zero;
		}

		public static void CreateInventory(InventoryParameters inventoryParameters) {
			// Gets the background image's parameters
			ImageParameters backgroundImageParameters = inventoryParameters.BackgroundImage;
			
			// Creates an object for the inventory
			GameObject inventoryObject = new GameObject();
			Inventory inventory = inventoryObject.AddComponent<Inventory>();
			
			// Creates an object for the background image
			GameObject backgroundImageObject = new GameObject();
			Image backgroundImage = backgroundImageObject.AddComponent<Image>();
			
			// Sets the background image's parameters
			backgroundImage.SetParameters(backgroundImageParameters);
			
			if (backgroundImageParameters.SortingLayer.Length == 0)
				// Sets the default sorting layer for the inventory background images
				backgroundImage.SetSortingLayer(ParameterManager.SortingLayerInventoryBackgroundImage);
			
			// Connects the objects
			backgroundImageObject.transform.parent = inventoryObject.transform;
			backgroundImageObject.transform.localPosition = Vector3.zero;
		}

		public static void CreateInventoryItem(InventoryItemParameters inventoryItemParameters, float size) {
			// Gets the image's parameters
			ImageParameters imageParameters = inventoryItemParameters.Image;
			
			// Creates an object for the inventory item
			GameObject inventoryItemObject = new GameObject();
			InventoryItem inventoryItem = inventoryItemObject.AddComponent<InventoryItem>();
			
			// Instantiates the behaviour prefab
			InventoryItemBehaviour inventoryItemBehaviour = (InventoryItemBehaviour) Object.Instantiate(inventoryItemParameters.Behaviour);
			
			// Sets the inventory item's behaviour
			inventoryItem.SetBehaviour(inventoryItemBehaviour);
			
			// Creates an object for the image
			GameObject imageObject = new GameObject();
			Image image = imageObject.AddComponent<Image>();
			
			// Sets the image's parameters
			image.SetParameters(imageParameters);

			// Overrides the image's relative height
			image.SetRelativeHeight(size);
			
			if (imageParameters.SortingLayer.Length == 0)
				// Sets the default sorting layer for the inventory item images
				image.SetSortingLayer(ParameterManager.SortingLayerInventoryItemImage);
			
			// Connects the objects
			imageObject.transform.parent = inventoryItemObject.transform;
			imageObject.transform.localPosition = Vector3.zero;
			inventoryItemBehaviour.transform.parent = inventoryItemObject.transform;
			inventoryItemBehaviour.transform.localPosition = Vector3.zero;
		}

		public static void CreateItem(ItemParameters itemParameters, Vector2 positionInGame, float scaleFactor) {
			// Gets the image's parameters
			ImageParameters imageParameters = itemParameters.Image;
			
			// Creates an object for the item
			GameObject itemObject = new GameObject();
			Item item = itemObject.AddComponent<Item>();
			
			// Instantiates the behaviour prefab
			ItemBehaviour itemBehaviour = (ItemBehaviour) Object.Instantiate(itemParameters.Behaviour);
			
			// Sets the item's behaviour
			item.SetBehaviour(itemBehaviour);
			
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

			// Connects the objects
			imageObject.transform.parent = itemObject.transform;
			imageObject.transform.localPosition = Vector3.zero;
			itemBehaviour.transform.parent = itemObject.transform;
			itemBehaviour.transform.localPosition = Vector3.zero;
		}

		public static void CreateMenu(MenuParameters menuParameters) {
			// Gets the background image's parameters
			ImageParameters backgroundImageParameters = menuParameters.BackgroundImage;
			
			// Creates an object for the menu
			GameObject menuObject = new GameObject();
			Menu menu = menuObject.AddComponent<Menu>();

			// Instantiates the behaviour prefab
			MenuBehaviour menuBehaviour = (MenuBehaviour) Object.Instantiate(menuParameters.Behaviour);

			// Sets the menu's behaviour
			menu.SetBehaviour(menuBehaviour);
			
			// Creates an object for the background image
			GameObject backgroundImageObject = new GameObject();
			Image backgroundImage = backgroundImageObject.AddComponent<Image>();
			
			// Sets the background image's parameters
			backgroundImage.SetParameters(backgroundImageParameters);
			
			if (backgroundImageParameters.SortingLayer.Length == 0)
				// Sets the default sorting layer for the menu background images
				backgroundImage.SetSortingLayer(ParameterManager.SortingLayerMenuBackgroundImage);
			
			// Connects the objects
			backgroundImageObject.transform.parent = menuObject.transform;
			backgroundImageObject.transform.localPosition = Vector3.zero;
			menuBehaviour.transform.parent = menuObject.transform;
			menuBehaviour.transform.localPosition = Vector3.zero;

			// Gets the game camera
			GameCamera gameCamera = GameCamera.GetInstance();
			
			// Sets the game rectangle as the game camera's boundaries
			Rect gameRectangle = UtilityManager.GetGameRectangleInWorld();
			gameCamera.SetBoundaries(gameRectangle);
			
			// Sets the main menu as the game camera's target
			gameCamera.SetTarget(menuObject.transform);
		}

		public static void CreatePlayerCharacter(CharacterParameters characterParameters, Vector2 positionInGame, float scaleFactor) {
			// Gets the image's parameters
			ImageParameters imageParameters = characterParameters.Image;
			
			// Creates an object for the player character
			GameObject playerCharacterObject = new GameObject();
			PlayerCharacter playerCharacter = playerCharacterObject.AddComponent<PlayerCharacter>();
			
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
			
			// Sets the player character's position
			playerCharacterObject.transform.position = UtilityManager.GameToWorldPosition(positionInGame);
			
			// Connects the objects
			imageObject.transform.parent = playerCharacterObject.transform;
			imageObject.transform.localPosition = Vector3.zero;
			
			// Sets the player character as the game camera's target
			GameCamera.GetInstance().SetTarget(playerCharacterObject.transform);
		}
		
		public static void CreateRoom(RoomParameters roomParameters) {
			// Gets the background and foreground images' parameters
			ImageParameters backgroundImageParameters = roomParameters.BackgroundImage;
			ImageParameters foregroundImageParameters = roomParameters.ForegroundImage;
			
			// Creates an object for the room
			GameObject roomObject = new GameObject();
			roomObject.AddComponent<Room>();
			
			// Creates an object for the background and foreground images
			GameObject backgroundImageObject = new GameObject();
			Image backgroundImage = backgroundImageObject.AddComponent<Image>();
			GameObject foregroundImageObject = new GameObject();
			Image foregroundImage = foregroundImageObject.AddComponent<Image>();
			
			// Sets the background and foreground images' parameters
			backgroundImage.SetParameters(backgroundImageParameters);
			foregroundImage.SetParameters(foregroundImageParameters);
			
			if (backgroundImageParameters.SortingLayer.Length == 0)
				// Sets the default sorting layer for the room background images
				backgroundImage.SetSortingLayer(ParameterManager.SortingLayerRoomBackgroundImage);

			if (foregroundImageParameters.SortingLayer.Length == 0)
				// Sets the default sorting layer for the room foreground images
				foregroundImage.SetSortingLayer(ParameterManager.SortingLayerRoomForegroundImage);
			
			// Connects the objects
			backgroundImageObject.transform.parent = roomObject.transform;
			backgroundImageObject.transform.localPosition = Vector3.zero;
			foregroundImageObject.transform.parent = roomObject.transform;
			foregroundImageObject.transform.localPosition = Vector3.zero;

			// Sets the room object's position so that its bottom-left corner matches the game's (0, 0)
			float roomHeightUnits = backgroundImage.GetHeightUnits();
			float roomWidthUnits = backgroundImage.GetWidthUnits();
			float gameHeightUnits = UtilityManager.GetGameHeightUnits();
			float gameWidthUnits = UtilityManager.GetGameWidthUnits();
			float xInGame = 0.5f * roomWidthUnits / gameWidthUnits;
			float yInGame = 0.5f * roomHeightUnits / gameHeightUnits;
			Vector2 positionInGame = new Vector2(xInGame, yInGame);
			roomObject.transform.position = UtilityManager.GameToWorldPosition(positionInGame);

			// Calculates the room's boundaries
			float height = roomHeightUnits;
			float left = UtilityManager.GameToWorldX(0f);
			float top = UtilityManager.GameToWorldY(0f) + roomHeightUnits;
			float width = roomWidthUnits;
			Rect roomBoundaries = new Rect(left, top, width, height);

			// Sets the room's boundaries as the game camera's boundaries
			GameCamera.GetInstance().SetBoundaries(roomBoundaries);
		}
		
		public static void CreateSplashScreen(SplashScreenParameters splashScreenParameters) {
			// Gets the image's parameters
			ImageParameters imageParameters = splashScreenParameters.Image;

			// Creates an object for the splash screen
			GameObject splashScreenObject = new GameObject();
			splashScreenObject.AddComponent<SplashScreen>();

			// Creates an object for the image
			GameObject imageObject = new GameObject();
			Image image = imageObject.AddComponent<Image>();

			// Sets the image's parameters
			image.SetParameters(imageParameters);

			if (imageParameters.SortingLayer.Length == 0)
				// Sets the default sorting layer for the splash screen images
				image.SetSortingLayer(ParameterManager.SortingLayerSplashScreenImage);

			// Connects the objects
			imageObject.transform.parent = splashScreenObject.transform;
			imageObject.transform.localPosition = Vector3.zero;

			// Gets the game camera
			GameCamera gameCamera = GameCamera.GetInstance();

			// Moves the splash screen in front of the camera
			gameCamera.MoveInFront(splashScreenObject.transform);
			
			// Sets the game rectangle as the game camera's boundaries
			Rect gameRectangle = UtilityManager.GetGameRectangleInWorld();
			gameCamera.SetBoundaries(gameRectangle);
			
			// Sets the splash screen as the game camera's target
			gameCamera.SetTarget(splashScreenObject.transform);
		}

	}

}
