using UnityEngine;

namespace FrameworkNamespace {

	public class GameImage : MonoBehaviour {

		private float opacity;
		private float relativeSize;
		private string sortingLayer;
		private Sprite sprite;

		public void Awake() {
			gameObject.AddComponent<SpriteRenderer>();
		}
		
		public float GetHeightPixels() {
			float heightUnits = GetHeightUnits();
			float heightPixels = UtilityManager.UnitsToPixels(heightUnits);
			
			return heightPixels;
		}
		
		public float GetHeightUnits() {
			return gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
		}

		public float GetOpacity() {
			return opacity;
		}

		public float GetRelativeSize() {
			return relativeSize;
		}

		public string GetSortingLayer() {
			return sortingLayer;
		}

		public Sprite GetSprite() {
			return sprite;
		}

		public float GetWidthPixels() {
			float widthUnits = GetWidthUnits();
			float widthPixels = UtilityManager.UnitsToPixels(widthUnits);

			return widthPixels;
		}

		public float GetWidthUnits() {
			return gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
		}
		
		public void SetOpacity(float opacity) {
			this.opacity = opacity;

			if (sprite != null)
				ChangeOpacity();
		}

		public void SetParameters(GameImageParameters parameters) {
			SetSprite(null);
			SetOpacity(parameters.Opacity);
			SetRelativeSize(parameters.RelativeSize);
			SetSortingLayer(parameters.SortingLayer);
			SetSprite(parameters.Sprite);
		}

		public void SetRelativeSize(float relativeSize) {
			this.relativeSize = relativeSize;

			if (sprite != null)
				ChangeRelativeSize();
		}

		public void SetSortingLayer(string sortingLayer) {
			this.sortingLayer = sortingLayer;

			if (sprite != null)
				ChangeSortingLayer();
		}

		public void SetSprite(Sprite sprite) {
			this.sprite = sprite;

			if (sprite != null) {
				ChangeSprite();
				ChangeOpacity();
				ChangeRelativeSize();
				ChangeSortingLayer();
			}
		}

		private void ChangeOpacity() {
			SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
			spriteRenderer.color = UtilityManager.GetColor(spriteRenderer.color, opacity);
		}
		
		private void ChangeRelativeSize() {
			float gameHeightUnits = UtilityManager.GetGameHeightUnits();
			float spriteHeightUnits = sprite.bounds.size.y;

			float scale = relativeSize * gameHeightUnits / spriteHeightUnits;
			transform.localScale = new Vector3(scale, scale, transform.localScale.z);
		}
		
		private void ChangeSortingLayer() {
			gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
		}
		
		private void ChangeSprite() {
			gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
		}
		
	}

}
