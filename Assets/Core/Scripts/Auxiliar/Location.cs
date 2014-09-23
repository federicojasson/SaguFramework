using UnityEngine;

namespace SaguFramework {

	/// Represents a game's location.
	/// Location objects are used to indicate the entities' position and in what room they are.
	public sealed class Location {
		
		private Vector2 position; // The position in game space
		private string room; // The room's ID

		/// Initializes a location.
		/// It receives its position in the game and the room's ID.
		public Location(Vector2 position, string room) {
			this.position = position;
			this.room = room;
		}
		
		/// Returns the position in game space.
		public Vector2 GetPosition() {
			return position;
		}

		/// Returns the room's ID.
		public string GetRoom() {
			return room;
		}
		
	}
	
}
