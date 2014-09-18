using UnityEngine;

namespace SaguFramework {
	
	public sealed class Image : MonoBehaviour {

		private Animator animator;
		private new SpriteRenderer renderer;

		public void Awake() {
			animator = gameObject.AddComponent<Animator>();
			renderer = gameObject.AddComponent<SpriteRenderer>();
		}

		public Animator GetAnimator() {
			return animator;
		}

		public Vector2 GetSize() {
			Sprite sprite = renderer.sprite;
			if (sprite == null)
				return Vector2.zero;

			float width = transform.localScale.x * sprite.bounds.size.x;
			float height = transform.localScale.y * sprite.bounds.size.y;
			
			return new Vector2(width, height);
		}

		public Texture2D GetTexture() {
			return renderer.sprite.texture;
		}

		public void SetAnimatorController(RuntimeAnimatorController animatorController) {
			animator.runtimeAnimatorController = animatorController;
		}

		public void SetOpacity(float opacity) {
			renderer.color = Utilities.GetColor(renderer.color, opacity);
		}

		public void SetSize(Vector2 size) {
			Sprite sprite = renderer.sprite;
			if (sprite == null)
				return;

			float scaleX = size.x / sprite.bounds.size.x;
			float scaleY = size.y / sprite.bounds.size.y;

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
