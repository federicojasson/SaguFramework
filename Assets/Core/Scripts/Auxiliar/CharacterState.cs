namespace SaguFramework {

	/// Represents the state of a character.
	/// The state of a character is directly related with the state of the game (which is a set of character's states,
	/// item's states, hints, etc.).
	public sealed class CharacterState {
		
		private Direction direction; // The character's direction
		private Location location; // The character's location

		/// Initializes a character's state.
		/// It receives its direction and location.
		public CharacterState(Direction direction, Location location) {
			this.direction = direction;
			this.location = location;
		}

		/// Gets the character's direction.
		public Direction GetDirection() {
			return direction;
		}

		/// Gets the character's location.
		public Location GetLocation() {
			return location;
		}
		
	}
	
}
