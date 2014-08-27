using UnityEngine;

namespace SaguFramework {

	public class Location {

		private Vector2 positionInGame;
		private string roomId;

		public Location(Vector2 positionInGame, string roomId) {
			this.positionInGame = positionInGame;
			this.roomId = roomId;
		}

		public Vector2 GetPositionInGame() {
			return positionInGame;
		}

		public string GetRoomId() {
			return roomId;
		}

	}

}
