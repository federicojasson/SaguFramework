using UnityEngine;

namespace SaguFramework {

	/// The inventory items are shown over the inventory.
	public sealed class InventoryItem : Entity {
		
		private string id; // The inventory item's ID
		private Image image; // The inventory item's image
		private Vector2 offset; // The offset from the camera
		
		/// Returns the inventory item's ID.
		public string GetId() {
			return id;
		}

		/// Returns the inventory item's image.
		public Image GetImage() {
			return image;
		}
		
		/// Sets the inventory item's ID.
		public void SetId(string id) {
			this.id = id;
		}
		
		/// Sets the inventory item's image.
		public void SetImage(Image image) {
			this.image = image;
		}
		
		/// Sets the offset in world space.
		public void SetOffset(Vector2 offset) {
			this.offset = offset;
		}
		
		public void Update() {
			// Follows the camera (and applies an offset)
			SetPosition(CameraHandler.GetCameraPosition() + offset);
      	}

	}
	
}
