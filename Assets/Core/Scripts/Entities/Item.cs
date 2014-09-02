using UnityEngine;

namespace SaguFramework {
	
	public class Item : MonoBehaviour {

		private float height;
		private Vector2 position;

		public void Awake() {
			Objects.RegisterItem(this);
		}

		public void OnDestroy() {
			Objects.UnregisterItem(this);
		}

		public void SetHeight(float height) {
			this.height = height;
		}

		public void SetPosition(Vector2 position) {
			this.position = position;
		}

		public void Update() {
			Image image = GetImage();

			Vector2 currentSize = image.GetSize();
			float aspectRatio = currentSize.x / currentSize.y;

			float sizeY = Geometry.GameToWorldHeight(height);
			float sizeX = sizeY * aspectRatio;
			Vector2 size = new Vector2(sizeX, sizeY);

			image.SetSize(size);
			GetInteractive().SetSize(size);

			transform.position = Geometry.GameToWorldPosition(position);
		}

		private Image GetImage() {
			return GetComponentInChildren<Image>();
		}

		private Interactive GetInteractive() {
			return GetComponentInChildren<Interactive>();
		}

		private ItemBehaviour GetItemBehaviour() {
			return GetComponentInChildren<ItemBehaviour>();
		}

	}
	
}
