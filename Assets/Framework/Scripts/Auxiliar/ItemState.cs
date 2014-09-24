namespace SaguFramework {

	/// Represents the state of an item.
	/// The state of an item is directly related with the state of the game (which is a set of character's states,
	/// item's states, hints, etc.).
	public sealed class ItemState {
		
		private Location location; // The item's location
		
		/// Initializes an item's state.
		/// Receives its location.
		public ItemState(Location location) {
			this.location = location;
		}
		
		/// Returns the item's location.
		public Location GetLocation() {
			return location;
		}
		
	}
	
}
