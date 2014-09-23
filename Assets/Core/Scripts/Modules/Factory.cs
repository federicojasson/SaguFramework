using UnityEngine;

namespace SaguFramework {

	// TODO: comentar

	public static class Factory {

		public static void CreateCharacter(string characterId, CharacterState characterState, CharacterParameters characterParameters, RoomParameters roomParameters) {
			Character character = CreateEntity<Character>(characterParameters.Behaviour);
			Image image = CreateImage(Parameters.SortingLayerCharacter, characterParameters.Image);

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
			character.SetDepth(Parameters.DepthCharacter);
			character.Register();
			character.Activate();

			character.SetDirection(characterState.GetDirection());
		}

		public static void CreateInventory(InventoryParameters inventoryParameters) {
			Inventory inventory = CreateEntity<Inventory, InventoryBehaviour>();
			Image image = CreateImage(Parameters.SortingLayerInventory, inventoryParameters.Image);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(inventoryParameters.Height));

			inventory.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, inventory);
			inventory.SetDepth(Parameters.DepthInventory);
			inventory.Register();

			CreateInventoryTrigger<InventoryHideBehaviour>(inventoryParameters.HideTrigger);
			CreateInventoryTrigger<InventoryPreviousPageBehaviour>(inventoryParameters.PreviousPageTrigger);
			CreateInventoryTrigger<InventoryNextPageBehaviour>(inventoryParameters.NextPageTrigger);
		}

		public static void CreateInventoryItem(string inventoryItemId, InventoryItemParameters inventoryItemParameters, InventoryParameters inventoryParameters) {
			InventoryItem inventoryItem = CreateEntity<InventoryItem>(inventoryItemParameters.Behaviour);
			Image image = CreateImage(Parameters.SortingLayerInventoryItem, inventoryItemParameters.Image);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldSize(inventoryParameters.CellSize));

			inventoryItem.SetId(inventoryItemId);
			inventoryItem.SetImage(image);
			inventoryItem.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, inventoryItem);
			inventoryItem.SetDepth(Parameters.DepthInventoryItem);
			inventoryItem.Register();
		}

		public static void CreateItem(string itemId, ItemState itemState, ItemParameters itemParameters, RoomParameters roomParameters) {
			Item item = CreateEntity<Item>(itemParameters.Behaviour);
			Image image = CreateImage(Parameters.SortingLayerItem, itemParameters.Image);
			
			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(itemParameters.Height * roomParameters.ScaleFactor));
			Vector2 position = Geometry.GameToWorldPosition(itemState.GetLocation().GetPosition());

			item.SetId(itemId);
			item.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, item);
			item.SetPosition(position);
			item.SetDepth(Parameters.DepthItem);
			item.Register();
			item.Activate();
		}
		
		public static void CreateMenu(MenuParameters menuParameters) {
			Menu menu = CreateEntity<Menu>(menuParameters.Behaviour);
			Image image = CreateImage(Parameters.SortingLayerMenu, menuParameters.Image);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(menuParameters.Height));

			menu.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, menu);
			menu.SetDepth(Parameters.DepthMenu);
			menu.Register();
			menu.Activate();
		}

		public static void CreateRoom(RoomParameters roomParameters) {
			Room room = CreateEntity<Room, RoomBehaviour>();
			Image backgroundImage = CreateImage(Parameters.SortingLayerRoomBackground, roomParameters.BackgroundImage);

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
			room.SetDepth(Parameters.DepthRoom);
			room.Register();
			room.Activate();

			foreach (RoomTriggerParameters roomTriggerParameters in roomParameters.Triggers)
				CreateRoomTrigger(roomTriggerParameters);
		}

		public static void CreateSplashScreen(SplashScreenParameters splashScreenParameters) {
			SplashScreen splashScreen = CreateEntity<SplashScreen, SplashScreenBehaviour>();
			Image image = CreateImage(Parameters.SortingLayerSplashScreen, splashScreenParameters.Image);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(splashScreenParameters.Height));

			splashScreen.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, splashScreen);
			splashScreen.SetDepth(Parameters.DepthSplashScreen);
			splashScreen.Register();
			splashScreen.Activate();
		}

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

		private static void CreateInventoryTrigger<B>(InventoryTriggerParameters inventoryTriggerParameters) where B : InventoryTriggerBehaviour {
			InventoryTrigger inventoryTrigger = CreateEntity<InventoryTrigger, B>();
			
			Rect area = inventoryTriggerParameters.Area;
			Vector2 size = Geometry.GameToWorldSize(new Vector2(area.width, area.height));
			Vector2 offset = Geometry.GameToWorldPosition(new Vector2(area.x - 0.5f, area.y - 0.5f));
			
			inventoryTrigger.SetSize(size);
			inventoryTrigger.SetOffset(offset);
			inventoryTrigger.SetDepth(Parameters.DepthInventoryTrigger);
			inventoryTrigger.Register();
		}
		
		private static void CreateRoomTrigger(RoomTriggerParameters roomTriggerParameters) {
			RoomTrigger roomTrigger = CreateEntity<RoomTrigger>(roomTriggerParameters.Behaviour);
			
			Rect area = roomTriggerParameters.Area;
			Vector2 size = Geometry.GameToWorldSize(new Vector2(area.width, area.height));
			Vector2 position = Geometry.GameToWorldPosition(new Vector2(area.x, area.y));

			roomTrigger.SetSize(size);
			roomTrigger.SetPosition(position);
			roomTrigger.SetDepth(Parameters.DepthRoomTrigger);
			roomTrigger.Register();
			roomTrigger.Activate();
		}

	}
	
}
