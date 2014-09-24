using UnityEngine;

namespace SaguFramework {

	/// Game factory.
	/// Handles the creation of entities and other assets.
	public static class Factory {

		/// Creates a character.
		/// Receives its ID, state and parameters, and also the room's parameters.
		public static void CreateCharacter(string characterId, CharacterState characterState, CharacterParameters characterParameters, RoomParameters roomParameters) {
			ImageParameters imageParameters = characterParameters.Image;

			Character character = CreateEntity<Character>(characterParameters.Behaviour);
			Image image = CreateImage(Parameters.SortingLayerCharacter, imageParameters);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(characterParameters.Height * roomParameters.ScaleFactor));
			float speed = Geometry.GameToWorldWidth(characterParameters.Speed);
			Vector2 position = Geometry.GameToWorldPosition(characterState.GetLocation().GetPosition());

			character.SetId(characterId);
			character.SetImage(image);
			character.SetSize(size);
			character.SetSpeed(speed);
			image.SetSize(size);
			Utilities.SetParent(image, character);
			character.SetPosition(position);
			character.SetDepth(- (Parameters.DepthCharacter + imageParameters.SortingOrder));
			character.Register();
			character.Activate();

			character.SetDirection(characterState.GetDirection());
		}

		/// Creates the inventory.
		/// Receives its parameters.
		public static void CreateInventory(InventoryParameters inventoryParameters) {
			ImageParameters imageParameters = inventoryParameters.Image;

			Inventory inventory = CreateEntity<Inventory, InventoryBehaviour>();
			Image image = CreateImage(Parameters.SortingLayerInventory, imageParameters);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(inventoryParameters.Height));

			inventory.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, inventory);
			inventory.SetDepth(- (Parameters.DepthInventory + imageParameters.SortingOrder));
			inventory.Register();

			// Creates the inventory triggers
			CreateInventoryTrigger<InventoryHideBehaviour>(inventoryParameters.HideTrigger);
			CreateInventoryTrigger<InventoryPreviousPageBehaviour>(inventoryParameters.PreviousPageTrigger);
			CreateInventoryTrigger<InventoryNextPageBehaviour>(inventoryParameters.NextPageTrigger);
		}

		/// Creates an inventory item.
		/// Receives its ID and parameters, and also the inventory's parameters.
		public static void CreateInventoryItem(string inventoryItemId, InventoryItemParameters inventoryItemParameters, InventoryParameters inventoryParameters) {
			ImageParameters imageParameters = inventoryItemParameters.Image;

			InventoryItem inventoryItem = CreateEntity<InventoryItem>(inventoryItemParameters.Behaviour);
			Image image = CreateImage(Parameters.SortingLayerInventoryItem, imageParameters);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldSize(inventoryParameters.CellSize));

			inventoryItem.SetId(inventoryItemId);
			inventoryItem.SetImage(image);
			inventoryItem.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, inventoryItem);
			inventoryItem.SetDepth(- (Parameters.DepthInventoryItem + imageParameters.SortingOrder));
			inventoryItem.Register();
		}

		/// Creates an item.
		/// Receives its ID, state and parameters, and also the room's parameters.
		public static void CreateItem(string itemId, ItemState itemState, ItemParameters itemParameters, RoomParameters roomParameters) {
			ImageParameters imageParameters = itemParameters.Image;

			Item item = CreateEntity<Item>(itemParameters.Behaviour);
			Image image = CreateImage(Parameters.SortingLayerItem, imageParameters);
			
			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(itemParameters.Height * roomParameters.ScaleFactor));
			Vector2 position = Geometry.GameToWorldPosition(itemState.GetLocation().GetPosition());

			item.SetId(itemId);
			item.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, item);
			item.SetPosition(position);
			item.SetDepth(- (Parameters.DepthItem + imageParameters.SortingOrder));
			item.Register();
			item.Activate();
		}

		/// Creates a menu.
		/// Receives its parameters.
		public static void CreateMenu(MenuParameters menuParameters) {
			ImageParameters imageParameters = menuParameters.Image;

			Menu menu = CreateEntity<Menu>(menuParameters.Behaviour);
			Image image = CreateImage(Parameters.SortingLayerMenu, imageParameters);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(menuParameters.Height));

			menu.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, menu);
			menu.SetDepth(- (Parameters.DepthMenu + imageParameters.SortingOrder));
			menu.Register();
			menu.Activate();
		}

		/// Creates a room.
		/// Receives its parameters.
		public static void CreateRoom(RoomParameters roomParameters) {
			ImageParameters backgroundImageParameters = roomParameters.BackgroundImage;

			Room room = CreateEntity<Room, RoomBehaviour>();
			Image backgroundImage = CreateImage(Parameters.SortingLayerRoomBackground, backgroundImageParameters);

			Vector2 size = Utilities.GetSize(backgroundImage.GetSize(), Geometry.GameToWorldHeight(roomParameters.Height));
			Vector2 position = 0.5f * size;

			room.SetSize(size);
			backgroundImage.SetSize(size);
			Utilities.SetParent(backgroundImage, room);

			ImageParameters foregroundImageParameters = roomParameters.ForegroundImage;
			if (foregroundImageParameters.Sprite != null) {
				Image foregroundImage = CreateImage(Parameters.SortingLayerRoomForeground, roomParameters.ForegroundImage);
				foregroundImage.SetSize(size);
				Utilities.SetParent(foregroundImage, room);
			}

			room.SetPosition(position);
			room.SetDepth(- (Parameters.DepthRoom + backgroundImageParameters.SortingOrder));
			room.Register();
			room.Activate();

			// Creates the room triggers
			foreach (RoomTriggerParameters roomTriggerParameters in roomParameters.Triggers)
				CreateRoomTrigger(roomTriggerParameters);
		}

		/// Creates a splash screen.
		/// Receives its parameters.
		public static void CreateSplashScreen(SplashScreenParameters splashScreenParameters) {
			ImageParameters imageParameters = splashScreenParameters.Image;

			SplashScreen splashScreen = CreateEntity<SplashScreen, SplashScreenBehaviour>();
			Image image = CreateImage(Parameters.SortingLayerSplashScreen, imageParameters);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(splashScreenParameters.Height));

			splashScreen.SetMinimumDelayTime(splashScreenParameters.MinimumDelayTime);
			splashScreen.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, splashScreen);
			splashScreen.SetDepth(- (Parameters.DepthSplashScreen + imageParameters.SortingOrder));
			splashScreen.Register();
			splashScreen.Activate();
		}

		/// Creates an entity with a known behaviour.
		private static E CreateEntity<E, B>() where E : Entity where B : EntityBehaviour {
			GameObject entityGameObject = new GameObject();
			E entity = entityGameObject.AddComponent<E>();
			
			GameObject entityBehaviourGameObject = new GameObject();
			B entityBehaviour = entityBehaviourGameObject.AddComponent<B>();
			
			entity.SetBehaviour(entityBehaviour);
			entityBehaviour.SetEntity(entity);
			Utilities.SetParent(entityBehaviour, entity);
			
			return entity;
		}

		/// Creates an entity.
		/// Receives its behaviour.
		private static E CreateEntity<E>(EntityBehaviour entityBehaviourModel) where E : Entity {
			GameObject entityGameObject = new GameObject();
			E entity = entityGameObject.AddComponent<E>();

			GameObject entityBehaviourGameObject = new GameObject();
			EntityBehaviour entityBehaviour = (EntityBehaviour) entityBehaviourGameObject.AddComponent(entityBehaviourModel.GetType());

			entity.SetBehaviour(entityBehaviour);
			entityBehaviour.SetEntity(entity);
			Utilities.SetParent(entityBehaviour, entity);

			return entity;
		}

		/// Creates an image.
		/// Receives its sorting layer and parameters.
		private static Image CreateImage(string sortingLayer, ImageParameters imageParameters) {
			GameObject imageGameObject = new GameObject();
			Image image = imageGameObject.AddComponent<Image>();

			image.SetAnimatorController(imageParameters.AnimatorController);
			image.SetOpacity(imageParameters.Opacity);
			image.SetSortingLayer(sortingLayer);
			image.SetSortingOrder(imageParameters.SortingOrder);
			image.SetSprite(imageParameters.Sprite);
			
			return image;
		}

		/// Creates an inventory trigger.
		/// Receives its parameters.
		private static void CreateInventoryTrigger<B>(InventoryTriggerParameters inventoryTriggerParameters) where B : InventoryTriggerBehaviour {
			InventoryTrigger inventoryTrigger = CreateEntity<InventoryTrigger, B>();
			
			Rect area = inventoryTriggerParameters.Area;
			Vector2 size = Geometry.GameToWorldSize(new Vector2(area.width, area.height));
			Vector2 offset = Geometry.GameToWorldPosition(new Vector2(area.x - 0.5f, area.y - 0.5f));
			
			inventoryTrigger.SetSize(size);
			inventoryTrigger.SetOffset(offset);
			inventoryTrigger.SetDepth(- Parameters.DepthInventoryTrigger);
			inventoryTrigger.Register();
		}

		/// Creates a room trigger.
		/// Receives its parameters.
		private static void CreateRoomTrigger(RoomTriggerParameters roomTriggerParameters) {
			RoomTrigger roomTrigger = CreateEntity<RoomTrigger>(roomTriggerParameters.Behaviour);
			
			Rect area = roomTriggerParameters.Area;
			Vector2 size = Geometry.GameToWorldSize(new Vector2(area.width, area.height));
			Vector2 position = Geometry.GameToWorldPosition(new Vector2(area.x, area.y));

			roomTrigger.SetSize(size);
			roomTrigger.SetPosition(position);
			roomTrigger.SetDepth(- Parameters.DepthRoomTrigger);
			roomTrigger.Register();
			roomTrigger.Activate();
		}

	}
	
}
