using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {
	
	public class RoomLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			CreateRoom();
			CreateItems(1); // TODO

			yield break; // TODO
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield break; // TODO
		}

		private void CreateItems(float scaleFactor) {
			string currentRoomId = State.GetCurrentRoomId();
			List<string> itemIds = State.GetRoomItemIds(currentRoomId);

			foreach (string itemId in itemIds) {
				Vector2 position = State.GetItemState(itemId).GetLocation().GetPosition();
				Factory.CreateItem(itemId, position, scaleFactor);
			}
		}

		private void CreateRoom() {
			string currentRoomId = State.GetCurrentRoomId();
			Factory.CreateRoom(currentRoomId);
		}

	}
	
}
