namespace SaguFramework {

	public enum Direction {
		Left,
		Right
	};

	public class CharacterState {

		private Direction direction;
		private Location location;
		
		public CharacterState(Direction direction, Location location) {
			this.direction = direction;
			this.location = location;
		}

		public Direction GetDirection() {
			return direction;
		}
		
		public Location GetLocation() {
			return location;
		}
		
	}
	
}
