using UnityEngine;

namespace SaguFramework {
	
	public class Room : MonoBehaviour {

		private float height;

		public void Update() {
			Image backgroundImage = GetBackgroundImage();
			
			Vector2 currentSize = backgroundImage.GetSize();
			float aspectRatio = currentSize.x / currentSize.y;
			
			float sizeY = Geometry.GameToWorldHeight(height);
			float sizeX = sizeY * aspectRatio;
			Vector2 size = new Vector2(sizeX, sizeY);
			
			backgroundImage.SetSize(size);
			GetForegroundImage().SetSize(size);

			float gameHeightUnits = Geometry.GetGameHeightUnits(); // TODO: use size
			float gameWidthUnits = Geometry.GetGameWidthUnits();

			float x = 0.5f * size.x / gameWidthUnits;
			float y = 0.5f * size.y / gameHeightUnits;
			Vector2 position = new Vector2(x, y);

			transform.position = Geometry.GameToWorldPosition(position);
		}
		
		public void SetHeight(float height) {
			this.height = height;
		}
		
		private Image GetBackgroundImage() {
			return GetComponentsInChildren<Image>()[0];
		}
		
		private Image GetForegroundImage() {
			return GetComponentsInChildren<Image>()[1];
		}

	}
	
}
