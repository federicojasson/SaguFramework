using UnityEngine;

namespace SaguFramework {
	
	public sealed class Location {
		
		private Vector2 position;
		private string room;
		
		public Location(Vector2 position, string room) {
			this.position = position;
			this.room = room;
		}
		
		public Vector2 GetPosition() {
			return position;
		}
		
		public string GetRoom() {
			return room;
		}
		
	}
	
}
