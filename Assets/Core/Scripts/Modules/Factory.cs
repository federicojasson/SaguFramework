using UnityEngine;

namespace SaguFramework {
	
	public static class Factory {

		public static void CreateCharacter(string characterId, CharacterState characterState, CharacterParameters characterParameters, RoomParameters roomParameters) {
			Character character = CreateEntity<Character>(characterParameters.Behaviour);
			Image image = CreateImage(characterParameters.Image, Parameters.SortingLayerCharacter);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(characterParameters.Height * roomParameters.ScaleFactor));

			character.SetId(characterId);
			character.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, character);
			character.SetPosition(Geometry.GameToWorldPosition(characterState.GetLocation().GetPosition()));
			character.Register();

			// TODO: direction
		}

		public static void CreateInventory(InventoryParameters inventoryParameters) {
			Inventory inventory = CreateEntity<Inventory, InventoryBehaviour>();
			Image image = CreateImage(inventoryParameters.Image, Parameters.SortingLayerInventory);
			InventoryTrigger hideTrigger = CreateInventoryTrigger<InventoryHideBehaviour>(inventoryParameters.HideTrigger);
			InventoryTrigger previousPageTrigger = CreateInventoryTrigger<InventoryPreviousPageBehaviour>(inventoryParameters.PreviousPageTrigger);
			InventoryTrigger nextPageTrigger = CreateInventoryTrigger<InventoryNextPageBehaviour>(inventoryParameters.NextPageTrigger);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(inventoryParameters.Height));

			inventory.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, inventory);
			Utilities.SetParent(hideTrigger, inventory);
			Utilities.SetParent(previousPageTrigger, inventory);
			Utilities.SetParent(nextPageTrigger, inventory);
			inventory.Hide();
			inventory.Register();
		}

		public static void CreateInventoryItem(string inventoryItemId, InventoryItemParameters inventoryItemParameters, InventoryParameters inventoryParameters) {
			InventoryItem inventoryItem = CreateEntity<InventoryItem>(inventoryItemParameters.Behaviour);
			Image image = CreateImage(inventoryItemParameters.Image, Parameters.SortingLayerInventoryItem);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldSize(inventoryParameters.CellSize));

			inventoryItem.SetId(inventoryItemId);
			inventoryItem.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, inventoryItem);
			inventoryItem.Hide();
			inventoryItem.Register();
		}

		public static void CreateItem(string itemId, ItemState itemState, ItemParameters itemParameters, RoomParameters roomParameters) {
			Item item = CreateEntity<Item>(itemParameters.Behaviour);
			Image image = CreateImage(itemParameters.Image, Parameters.SortingLayerItem);
			
			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(itemParameters.Height * roomParameters.ScaleFactor));

			item.SetId(itemId);
			item.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, item);
			item.SetPosition(Geometry.GameToWorldPosition(itemState.GetLocation().GetPosition()));
			item.Register();
		}
		
		public static void CreateMenu(MenuParameters menuParameters) {
			Menu menu = CreateEntity<Menu>(menuParameters.Behaviour);
			Image image = CreateImage(menuParameters.Image, Parameters.SortingLayerMenu);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(menuParameters.Height));
			
			menu.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, menu);
			menu.Register();
		}

		public static void CreateRoom(RoomParameters roomParameters) {
			Room room = CreateEntity<Room, RoomBehaviour>();
			Image backgroundImage = CreateImage(roomParameters.BackgroundImage, Parameters.SortingLayerRoomBackground);
			Image foregroundImage = CreateImage(roomParameters.ForegroundImage, Parameters.SortingLayerRoomForeground);

			Vector2 size = Utilities.GetSize(backgroundImage.GetSize(), Geometry.GameToWorldHeight(roomParameters.Height));
			Vector2 position = 0.5f * size;

			room.SetSize(size);
			backgroundImage.SetSize(size);
			foregroundImage.SetSize(size);
			Utilities.SetParent(backgroundImage, room);
			Utilities.SetParent(foregroundImage, room);
			room.SetPosition(position);
			room.Register();

			foreach (RoomTriggerParameters roomTriggerParameters in roomParameters.Triggers) {
				RoomTrigger trigger = CreateRoomTrigger(roomTriggerParameters);
				Utilities.SetParent(trigger, room);
			}
		}

		public static void CreateSplashScreen(SplashScreenParameters splashScreenParameters) {
			SplashScreen splashScreen = CreateEntity<SplashScreen, SplashScreenBehaviour>();
			Image image = CreateImage(splashScreenParameters.Image, Parameters.SortingLayerSplashScreen);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(splashScreenParameters.Height));

			splashScreen.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, splashScreen);
			splashScreen.Register();
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

		private static Image CreateImage(ImageParameters imageParameters, string defaultSortingLayer) {
			string sortingLayer = imageParameters.SortingLayer;
			if (sortingLayer.Length == 0)
				sortingLayer = defaultSortingLayer;

			GameObject imageGameObject = new GameObject();
			Image image = imageGameObject.AddComponent<Image>();
			
			image.SetOpacity(imageParameters.Opacity);
			image.SetSortingLayer(sortingLayer);
			image.SetSprite(imageParameters.Sprite);
			
			return image;
		}

		private static InventoryTrigger CreateInventoryTrigger<B>(InventoryTriggerParameters inventoryTriggerParameters) where B : InventoryTriggerBehaviour {
			InventoryTrigger inventoryTrigger = CreateEntity<InventoryTrigger, B>();
			
			Rect area = inventoryTriggerParameters.Area;
			Vector2 size = new Vector2(area.width, area.height);
			Vector2 position = new Vector2(area.x - 0.5f, area.y - 0.5f);
			
			inventoryTrigger.SetSize(Geometry.GameToWorldSize(size));
			inventoryTrigger.SetPosition(Geometry.GameToWorldPosition(position));
			inventoryTrigger.Register();

			return inventoryTrigger;
		}

		private static RoomTrigger CreateRoomTrigger(RoomTriggerParameters roomTriggerParameters) {
			RoomTrigger roomTrigger = CreateEntity<RoomTrigger>(roomTriggerParameters.Behaviour);
			
			Rect area = roomTriggerParameters.Area;
			Vector2 size = new Vector2(area.width, area.height);
			Vector2 position = new Vector2(area.x, area.y);
			
			roomTrigger.SetSize(Geometry.GameToWorldSize(size));
			roomTrigger.SetPosition(Geometry.GameToWorldPosition(position));
			roomTrigger.Register();

			return roomTrigger;
		}

	}
	
}
