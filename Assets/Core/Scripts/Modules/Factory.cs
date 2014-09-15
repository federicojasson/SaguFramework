using UnityEngine;

namespace SaguFramework {
	
	public static class Factory {

		public static void CreateCharacter(string characterId, CharacterState characterState, CharacterParameters characterParameters, RoomParameters roomParameters) {
			// TODO

			Character character = CreateEntity<Character>(characterParameters.Behaviour);
			//Image image = CreateImage(characterParameters.Image, Parameters.SortingLayerCharacter);
			CharacterAnimator characterAnimator = CreateCharacterAnimator(characterParameters.AnimatorController);

			//Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(characterParameters.Height * roomParameters.ScaleFactor));

			character.SetId(characterId);
			character.SetSize(new Vector2(292.5f, 585)); // TODO
			characterAnimator.SetSize(new Vector2(292.5f, 585)); // TODO
			//image.SetSize(size);
			//Utilities.SetParent(image, character);
			Utilities.SetParent(characterAnimator, character);
			character.SetDepth(Parameters.DepthCharacter);
			character.SetPosition(Geometry.GameToWorldPosition(characterState.GetLocation().GetPosition()));
			character.Register();
			character.Show();

			// TODO: direction
		}

		public static void CreateInventory(InventoryParameters inventoryParameters) {
			Inventory inventory = CreateEntity<Inventory, InventoryBehaviour>();
			Image image = CreateImage(inventoryParameters.Image, Parameters.SortingLayerInventory);

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
			Image image = CreateImage(inventoryItemParameters.Image, Parameters.SortingLayerInventoryItem);

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
			Image image = CreateImage(itemParameters.Image, Parameters.SortingLayerItem);
			
			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(itemParameters.Height * roomParameters.ScaleFactor));

			item.SetId(itemId);
			item.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, item);
			item.SetDepth(Parameters.DepthItem);
			item.SetPosition(Geometry.GameToWorldPosition(itemState.GetLocation().GetPosition()));
			item.Register();
			item.Show();
		}
		
		public static void CreateMenu(MenuParameters menuParameters) {
			Menu menu = CreateEntity<Menu>(menuParameters.Behaviour);
			Image image = CreateImage(menuParameters.Image, Parameters.SortingLayerMenu);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(menuParameters.Height));

			menu.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, menu);
			menu.SetDepth(Parameters.DepthMenu);
			menu.Register();
			menu.Show();
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
			room.SetDepth(Parameters.DepthRoom);
			room.SetPosition(position);
			room.Register();
			room.Show();

			foreach (RoomTriggerParameters roomTriggerParameters in roomParameters.Triggers)
				CreateRoomTrigger(roomTriggerParameters);
		}

		public static void CreateSplashScreen(SplashScreenParameters splashScreenParameters) {
			SplashScreen splashScreen = CreateEntity<SplashScreen, SplashScreenBehaviour>();
			Image image = CreateImage(splashScreenParameters.Image, Parameters.SortingLayerSplashScreen);

			Vector2 size = Utilities.GetSize(image.GetSize(), Geometry.GameToWorldHeight(splashScreenParameters.Height));

			splashScreen.SetSize(size);
			image.SetSize(size);
			Utilities.SetParent(image, splashScreen);
			splashScreen.SetDepth(Parameters.DepthSplashScreen);
			splashScreen.Register();
			splashScreen.Show();
		}

		private static CharacterAnimator CreateCharacterAnimator(RuntimeAnimatorController animatorController) {
			GameObject characterAnimatorGameObject = new GameObject();
			CharacterAnimator characterAnimator = characterAnimatorGameObject.AddComponent<CharacterAnimator>();
			
			characterAnimator.SetAnimatorController(animatorController);
			
			return characterAnimator;
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

		private static void CreateInventoryTrigger<B>(InventoryTriggerParameters inventoryTriggerParameters) where B : InventoryTriggerBehaviour {
			InventoryTrigger inventoryTrigger = CreateEntity<InventoryTrigger, B>();
			
			Rect area = inventoryTriggerParameters.Area;
			Vector2 size = new Vector2(area.width, area.height);
			Vector2 position = new Vector2(area.x - 0.5f, area.y - 0.5f);
			
			inventoryTrigger.SetSize(Geometry.GameToWorldSize(size));
			inventoryTrigger.SetDepth(Parameters.DepthInventoryTrigger);
			inventoryTrigger.SetPosition(Geometry.GameToWorldPosition(position));
			inventoryTrigger.Register();
		}
		
		private static void CreateRoomTrigger(RoomTriggerParameters roomTriggerParameters) {
			RoomTrigger roomTrigger = CreateEntity<RoomTrigger>(roomTriggerParameters.Behaviour);
			
			Rect area = roomTriggerParameters.Area;
			Vector2 size = new Vector2(area.width, area.height);
			Vector2 position = new Vector2(area.x, area.y);
			
			roomTrigger.SetSize(Geometry.GameToWorldSize(size));
			roomTrigger.SetDepth(Parameters.DepthRoomTrigger);
			roomTrigger.SetPosition(Geometry.GameToWorldPosition(position));
			roomTrigger.Register();
			roomTrigger.Show();
		}

	}
	
}
