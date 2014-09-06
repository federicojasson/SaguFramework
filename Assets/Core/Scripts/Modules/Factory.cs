using UnityEngine;

namespace SaguFramework {
	
	public static class Factory {

		// TODO: fix position handling

		public static Character CreateCharacter(CharacterParameters parameters, Vector2 position, float roomScaleFactor) {
			Character character = Instantiate<Character>(Parameters.GetCharacter());
			CharacterBehaviour behaviour = (CharacterBehaviour) Object.Instantiate(parameters.Behaviour);
			Image image = CreateImage(parameters.Image, Parameters.SortingLayerCharacter);
			Interactive interactive = CreateInteractive(parameters.Interactive);

			// TODO: temporal
			Vector2 currentSize = image.GetSize();
			float aspectRatio = currentSize.x / currentSize.y;
			float sizeY = Geometry.GameToWorldHeight(roomScaleFactor * parameters.Height);
			float sizeX = sizeY * aspectRatio;
			Vector2 size = new Vector2(sizeX, sizeY);
			
			image.SetSize(size);
			interactive.SetSize(size);
			SetParent(behaviour, character);
			SetParent(image, character);
			SetParent(interactive, character);
			character.SetPosition(Geometry.GameToWorldPosition(position));

			return character;
		}

		public static Image CreateImage(ImageParameters parameters, string defaultSortingLayer) {
			string sortingLayer = parameters.SortingLayer;
			if (sortingLayer.Length == 0)
				sortingLayer = defaultSortingLayer;

			Image image = Instantiate<Image>(Parameters.GetImage());

			image.SetOpacity(parameters.Opacity);
			image.SetSortingLayer(sortingLayer);
			image.SetSprite(parameters.Sprite);

			return image;
		}
		
		public static Interactive CreateInteractive(InteractiveParameters parameters) {
			Interactive interactive = Instantiate<Interactive>(Parameters.GetInteractive());
			InteractiveBehaviour behaviour = (InteractiveBehaviour) Object.Instantiate(parameters.Behaviour);
			
			SetParent(behaviour, interactive);
			
			return interactive;
		}

		public static Inventory CreateInventory(InventoryParameters parameters) {
			Inventory inventory = Instantiate<Inventory>(Parameters.GetInventory());
			Image image = CreateImage(parameters.Image, Parameters.SortingLayerInventory);

			Vector2 currentSize = image.GetSize();
			float aspectRatio = currentSize.x / currentSize.y;
			float sizeY = Geometry.GameToWorldHeight(1f);
			float sizeX = sizeY * aspectRatio;
			Vector2 size = new Vector2(sizeX, sizeY);
			
			image.SetSize(size);
			SetParent(image, inventory);

			return inventory;
		}

		public static InventoryItem CreateInventoryItem(InventoryItemParameters parameters, Vector2 inventoryItemsSize) {
			InventoryItem inventoryItem = Instantiate<InventoryItem>(Parameters.GetInventoryItem());
			InventoryItemBehaviour behaviour = (InventoryItemBehaviour) Object.Instantiate(parameters.Behaviour);
			Image image = CreateImage(parameters.Image, Parameters.SortingLayerInventoryItem);
			Interactive interactive = CreateInteractive(parameters.Interactive);

			Vector2 size = Geometry.GameToWorldSize(inventoryItemsSize);
			float inventoryItemsAspectRatio = size.x / size.y;

			Vector2 imageCurrentSize = image.GetSize();
			float imageAspectRatio = imageCurrentSize.x / imageCurrentSize.y;
			float imageSizeX;
			float imageSizeY;
			if (imageAspectRatio > inventoryItemsAspectRatio) {
				imageSizeX = size.x;
				imageSizeY = imageSizeX / imageAspectRatio;
			} else {
				imageSizeY = size.y;
				imageSizeX = imageSizeY * imageAspectRatio;
			}
			Vector2 imageSize = new Vector2(imageSizeX, imageSizeY);

			image.SetSize(imageSize);
			interactive.SetSize(size);
			SetParent(behaviour, inventoryItem);
			SetParent(image, inventoryItem);
			SetParent(interactive, inventoryItem);

			return inventoryItem;
		}
		
		public static Item CreateItem(ItemParameters parameters, Vector2 position, float roomScaleFactor) {
			Item item = Instantiate<Item>(Parameters.GetItem());
			ItemBehaviour behaviour = (ItemBehaviour) Object.Instantiate(parameters.Behaviour);
			Image image = CreateImage(parameters.Image, Parameters.SortingLayerItem);
			Interactive interactive = CreateInteractive(parameters.Interactive);
			
			Vector2 currentSize = image.GetSize();
			float aspectRatio = currentSize.x / currentSize.y;
			float sizeY = Geometry.GameToWorldHeight(roomScaleFactor * parameters.Height);
			float sizeX = sizeY * aspectRatio;
			Vector2 size = new Vector2(sizeX, sizeY);
			
			image.SetSize(size);
			interactive.SetSize(size);
			SetParent(behaviour, item);
			SetParent(image, item);
			SetParent(interactive, item);
			item.SetPosition(Geometry.GameToWorldPosition(position));
			
			return item;
		}

		public static Menu CreateMenu(MenuParameters parameters) {
			Menu menu = Instantiate<Menu>(Parameters.GetMenu());
			MenuBehaviour behaviour = (MenuBehaviour) Object.Instantiate(parameters.Behaviour);
			Image image = CreateImage(parameters.Image, Parameters.SortingLayerMenu);
			
			Vector2 currentSize = image.GetSize();
			float aspectRatio = currentSize.x / currentSize.y;
			float sizeY = Geometry.GameToWorldHeight(1f);
			float sizeX = sizeY * aspectRatio;
			Vector2 size = new Vector2(sizeX, sizeY);

			image.SetSize(size);
			SetParent(behaviour, menu);
			SetParent(image, menu);
			
			return menu;
		}
		
		public static Room CreateRoom(RoomParameters parameters) {
			Room room = Instantiate<Room>(Parameters.GetRoom());
			Image backgroundImage = CreateImage(parameters.BackgroundImage, Parameters.SortingLayerRoomBackground);
			Image foregroundImage = CreateImage(parameters.ForegroundImage, Parameters.SortingLayerRoomForeground);
			
			Vector2 currentSize = backgroundImage.GetSize();
			float aspectRatio = currentSize.x / currentSize.y;
			float sizeY = Geometry.GameToWorldHeight(1f);
			float sizeX = sizeY * aspectRatio;
			Vector2 size = new Vector2(sizeX, sizeY);
			
			Vector2 gameSizeInUnits = Geometry.GetGameSizeInUnits();
			float x = 0.5f * size.x / gameSizeInUnits.x;
			float y = 0.5f * size.y / gameSizeInUnits.y;
			Vector2 position = new Vector2(x, y);

			backgroundImage.SetSize(size);
			foregroundImage.SetSize(size);
			SetParent(backgroundImage, room);
			SetParent(foregroundImage, room);
			
			room.SetPosition(Geometry.GameToWorldPosition(position));
			
			foreach (TriggerParameters triggerParameters in parameters.Triggers) {
				Trigger trigger = CreateTrigger(triggerParameters);
				SetParent(trigger, room);
			}

			return room;
		}

		public static SplashScreen CreateSplashScreen(SplashScreenParameters parameters) {
			SplashScreen splashScreen = Instantiate<SplashScreen>(Parameters.GetSplashScreen());
			Image image = CreateImage(parameters.Image, Parameters.SortingLayerSplashScreen);

			Vector2 currentSize = image.GetSize();
			float aspectRatio = currentSize.x / currentSize.y;
			float sizeY = Geometry.GameToWorldHeight(1f);
			float sizeX = sizeY * aspectRatio;
			Vector2 size = new Vector2(sizeX, sizeY);
			
			image.SetSize(size);
			SetParent(image, splashScreen);

			return splashScreen;
		}

		public static Trigger CreateTrigger(TriggerParameters parameters) {
			Trigger trigger = Instantiate<Trigger>(Parameters.GetTrigger());
			TriggerBehaviour behaviour = (TriggerBehaviour) Object.Instantiate(parameters.Behaviour);

			trigger.SetSize(Geometry.GameToWorldSize(parameters.Size));
			SetParent(behaviour, trigger);
			trigger.SetPosition(Geometry.GameToWorldPosition(parameters.Position));

			return trigger;
		}

		private static T Instantiate<T>(T model) where T : Object {
			return (T) Object.Instantiate(model);
		}

		private static void SetParent(Component child, Component parent) {
			child.transform.parent = parent.transform;
		}

	}
	
}
