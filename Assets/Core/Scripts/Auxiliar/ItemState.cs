namespace SaguFramework {
	
	public sealed class ItemState {
		
		private Location location;
		
		public ItemState(Location location) {
			this.location = location;
		}
		
		public Location GetLocation() {
			return location;
		}
		
	}
	
}
