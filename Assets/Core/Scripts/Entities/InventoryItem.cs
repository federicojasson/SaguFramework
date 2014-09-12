namespace SaguFramework {
	
	public class InventoryItem : Entity {
		
		private string id;
		private Image image;

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

	}
	
}
