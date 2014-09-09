using System.Collections;

namespace SaguFramework {
	
	public class RoomLoader : Loader {

		private static void CreateCharacters() {
			// TODO
			Factory.CreateCharacter();
		}

		private static void CreateEntities() {
			CreateInventory();
			CreateInventoryItems();
			CreateRoom();
			CreateCharacters();
			CreateItems();
		}

		private static void CreateInventory() {
			Factory.CreateInventory();
			// TODO
		}

		private static void CreateInventoryItems() {
			Factory.CreateInventoryItem();
			// TODO
		}

		private static void CreateItems() {
			Factory.CreateItem();
			// TODO
		}

		private static void CreateRoom() {
			Factory.CreateRoom();
			// TODO
		}
		
		protected override IEnumerator LoadSceneCoroutine() {
			CreateEntities();

			yield break;
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield break;
		}

	}
	
}
