using UnityEngine;

namespace SaguFramework {

	/// Represents a game location.
	/// A location object is used to indicate the position of an entity in a certain room.
	public sealed class Location {
		
		private Vector2 position; // The position in game space
		private string room; // The room's ID

		/// Initializes a location.
		/// Receives the position in the game and the room's ID.
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
