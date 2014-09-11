using UnityEngine;

namespace SaguFramework {
	
	public class Location {
		
		private Vector2 position;
		private string roomId;
		
		public Location(Vector2 position, string roomId) {
			this.position = position;
			this.roomId = roomId;
		}
		
		public Vector2 GetPosition() {
			return position;
		}
		
		public string GetRoomId() {
			return roomId;
		}
		
	}
	
}
