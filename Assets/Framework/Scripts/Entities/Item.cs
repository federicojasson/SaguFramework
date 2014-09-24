namespace SaguFramework {

	/// An item.
	/// All items must have a unique ID.
	public sealed class Item : Entity {

		private string id; // The item's ID

		/// Returns the item's ID.
		public string GetId() {
			return id;
		}

		/// Sets the item's ID.
		public void SetId(string id) {
			this.id = id;
		}

	}
	
}
