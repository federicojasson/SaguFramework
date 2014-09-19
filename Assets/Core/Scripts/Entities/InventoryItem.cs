using UnityEngine;

namespace SaguFramework {
	
	public sealed class InventoryItem : Entity {
		
		private string id;
		private Image image;
		private Vector2 offset;

		public string GetId() {
			return id;
		}
		
		public Image GetImage() {
			return image;
		}

		public void SetId(string id) {
			this.id = id;
		}
		
		public void SetImage(Image image) {
			this.image = image;
		}

		public void SetOffset(Vector2 offset) {
			this.offset = offset;
		}
		
		public void Update() {
			SetPosition(CameraHandler.GetCameraPosition() + offset);
      	}

	}
	
}
