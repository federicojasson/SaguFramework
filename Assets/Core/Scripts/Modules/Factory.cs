using UnityEngine;

namespace SaguFramework {
	
	public static class Factory {

		public static void CreateCharacter(string characterId, CharacterState characterState, CharacterParameters characterParameters, RoomParameters roomParameters) {
			Character character = CreateEntity<Character>(characterParameters.Behaviour);
			Image image = CreateImage(characterParameters.Image, Parameters.SortingLayerCharacter);

			Vector2 size = Utilities.GetSize(image.GetSize(), characterParameters.Height * roomParameters.ScaleFactor);
			
			character.SetId(characterId);
			character.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, character);
			character.SetPosition(Geometry.GameToWorldPosition(characterState.GetLocation().GetPosition()));

			// TODO: direction
		}

		public static void CreateInventory(InventoryParameters inventoryParameters) {
			Inventory inventory = CreateEntity<Inventory, InventoryBehaviour>();
			Image image = CreateImage(inventoryParameters.Image, Parameters.SortingLayerInventory);

			Vector2 size = Utilities.GetSize(image.GetSize(), inventoryParameters.Height);

			inventory.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, inventory);
			inventory.Hide();

			// TODO: triggers
		}

		public static void CreateInventoryItem(string inventoryItemId, InventoryItemParameters inventoryItemParameters, InventoryParameters inventoryParameters) {
			InventoryItem inventoryItem = CreateEntity<InventoryItem>(inventoryItemParameters.Behaviour);
			Image image = CreateImage(inventoryItemParameters.Image, Parameters.SortingLayerInventoryItem);

			// TODO: size

			inventoryItem.SetId(inventoryItemId);
			Utilities.SetParent(image, inventoryItem);
			inventoryItem.Hide();
		}

		public static void CreateItem(string itemId, ItemState itemState, ItemParameters itemParameters, RoomParameters roomParameters) {
			Item item = CreateEntity<Item>(itemParameters.Behaviour);
			Image image = CreateImage(itemParameters.Image, Parameters.SortingLayerItem);
			
			Vector2 size = Utilities.GetSize(image.GetSize(), itemParameters.Height * roomParameters.ScaleFactor);

			item.SetId(itemId);
			item.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, item);
			item.SetPosition(Geometry.GameToWorldPosition(itemState.GetLocation().GetPosition()));
		}
		
		public static void CreateMenu(MenuParameters menuParameters) {
			Menu menu = CreateEntity<Menu>(menuParameters.Behaviour);
			Image image = CreateImage(menuParameters.Image, Parameters.SortingLayerMenu);

			Vector2 size = Utilities.GetSize(image.GetSize(), menuParameters.Height);
			
			menu.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, menu);
		}

		public static void CreateRoom(RoomParameters roomParameters) {
			Room room = CreateEntity<Room, RoomBehaviour>();
			Image backgroundImage = CreateImage(roomParameters.BackgroundImage, Parameters.SortingLayerRoomBackground);
			Image foregroundImage = CreateImage(roomParameters.ForegroundImage, Parameters.SortingLayerRoomForeground);

			Vector2 size = Utilities.GetSize(backgroundImage.GetSize(), roomParameters.Height);

			room.SetSize(size);
			backgroundImage.SetSize(size);
			foregroundImage.SetSize(size);
			Utilities.SetParent(backgroundImage, room);
			Utilities.SetParent(foregroundImage, room);

			// TODO: triggers
		}

		public static void CreateSplashScreen(SplashScreenParameters splashScreenParameters) {
			SplashScreen splashScreen = CreateEntity<SplashScreen, SplashScreenBehaviour>();
			Image image = CreateImage(splashScreenParameters.Image, Parameters.SortingLayerSplashScreen);

			Vector2 size = Utilities.GetSize(image.GetSize(), splashScreenParameters.Height);

			splashScreen.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, splashScreen);
		}

		private static E CreateEntity<E, B>() where E : Entity where B : EntityBehaviour {
			GameObject entityGameObject = new GameObject();
			E entity = entityGameObject.AddComponent<E>();
			
			GameObject entityBehaviourGameObject = new GameObject();
			B entityBehaviour = entityBehaviourGameObject.AddComponent<B>();
			
			entity.SetBehaviour(entityBehaviour);
			Utilities.SetParent(entityBehaviour, entity);
			
			return entity;
		}

		private static E CreateEntity<E>(EntityBehaviour entityBehaviourModel) where E : Entity {
			GameObject entityGameObject = new GameObject();
			E entity = entityGameObject.AddComponent<E>();

			GameObject entityBehaviourGameObject = new GameObject();
			EntityBehaviour entityBehaviour = (EntityBehaviour) entityBehaviourGameObject.AddComponent(entityBehaviourModel.GetType());

			entity.SetBehaviour(entityBehaviour);
			Utilities.SetParent(entityBehaviour, entity);

			return entity;
		}

		private static Image CreateImage(ImageParameters parameters, string defaultSortingLayer) {
			string sortingLayer = parameters.SortingLayer;
			if (sortingLayer.Length == 0)
				sortingLayer = defaultSortingLayer;

			GameObject imageGameObject = new GameObject();
			Image image = imageGameObject.AddComponent<Image>();
			
			image.SetOpacity(parameters.Opacity);
			image.SetSortingLayer(sortingLayer);
			image.SetSprite(parameters.Sprite);
			
			return image;
		}

	}
	
}
