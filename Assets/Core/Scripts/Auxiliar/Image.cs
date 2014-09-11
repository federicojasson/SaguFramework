using UnityEngine;

namespace SaguFramework {
	
	public class Image : MonoBehaviour {

		private new SpriteRenderer renderer;

		public void Awake() {
			renderer = gameObject.AddComponent<SpriteRenderer>();
		}

		public Vector2 GetSize() {
			float width = transform.localScale.x * renderer.sprite.bounds.size.x;
			float height = transform.localScale.y * renderer.sprite.bounds.size.y;
			
			return new Vector2(width, height);
		}

		public void SetOpacity(float opacity) {
			renderer.color = Utilities.GetColor(renderer.color, opacity);
		}

		public void SetSize(Vector2 size) {
			float scaleX = size.x / renderer.sprite.bounds.size.x;
			float scaleY = size.y / renderer.sprite.bounds.size.y;
			transform.localScale = new Vector3(scaleX, scaleY, transform.localScale.z);
		}

		public void SetSortingLayer(string sortingLayer) {
			renderer.sortingLayerName = sortingLayer;
		}

		public void SetSprite(Sprite sprite) {
			renderer.sprite = sprite;
		}

	}
	
}
