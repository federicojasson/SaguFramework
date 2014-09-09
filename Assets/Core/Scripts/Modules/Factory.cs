using UnityEngine;

namespace SaguFramework {
	
	public static class Factory {

		public static Character CreateCharacter(CharacterParameters parameters) {
			Character character = CreateEntity<Character>(parameters.Behaviour);
			
			return character;
		}

		public static Inventory CreateInventory(InventoryParameters parameters) {
			Inventory inventory = CreateEntity<Inventory, InventoryBehaviour>();
			
			return inventory;
		}

		public static InventoryItem CreateInventoryItem(InventoryItemParameters parameters) {
			InventoryItem inventoryItem = CreateEntity<InventoryItem>(parameters.Behaviour);
			
			return inventoryItem;
		}

		public static Item CreateItem(ItemParameters parameters) {
			Item item = CreateEntity<Item>(parameters.Behaviour);

			return item;
		}

		public static Room CreateRoom(RoomParameters parameters) {
			Room room = CreateEntity<Room, RoomBehaviour>();
			
			return room;
		}

		private static E CreateEntity<E, B>() where E : Entity where B : EntityBehaviour {
			GameObject entityGameObject = new GameObject();
			E entity = entityGameObject.AddComponent<E>();
			
			GameObject entityBehaviourGameObject = new GameObject();
			B entityBehaviour = entityBehaviourGameObject.AddComponent<B>();
			
			entity.SetBehaviour(entityBehaviour);
			
			return entity;
		}

		private static E CreateEntity<E>(EntityBehaviour entityBehaviourModel) where E : Entity {
			GameObject entityGameObject = new GameObject();
			E entity = entityGameObject.AddComponent<E>();

			GameObject entityBehaviourGameObject = new GameObject();
			EntityBehaviour entityBehaviour = (EntityBehaviour) entityBehaviourGameObject.AddComponent(entityBehaviourModel.GetType());

			entity.SetBehaviour(entityBehaviour);

			return entity;
		}

	}
	
}
