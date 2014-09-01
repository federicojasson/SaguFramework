using UnityEngine;

namespace SaguFramework {

	public class Image : MonoBehaviour {

		// TODO: comments

		private float opacity;
		private float relativeHeight;
		private string sortingLayer;
		private Sprite sprite;
		private SpriteRenderer spriteRenderer;
		
		public void Awake() {
			spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
		}

		public float GetHeightPixels() {
			float heightUnits = GetHeightUnits();
			float heightPixels = UtilityManager.UnitsToPixels(heightUnits);
			
			return heightPixels;
		}
		
		public float GetHeightUnits() {
			return spriteRenderer.bounds.size.y;
		}
		
		public float GetOpacity() {
			return opacity;
		}
		
		public float GetRelativeHeight() {
			return relativeHeight;
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
			return spriteRenderer.bounds.size.x;
		}
		
		public void SetOpacity(float opacity) {
			this.opacity = opacity;
			
			if (sprite != null)
				ChangeOpacity();
		}
		
		public void SetParameters(ImageParameters parameters) {
			SetSprite(null);
			SetOpacity(parameters.Opacity);
			SetRelativeHeight(parameters.RelativeHeight);
			SetSortingLayer(parameters.SortingLayer);
			SetSprite(parameters.Sprite);
		}
		
		public void SetRelativeHeight(float relativeHeight) {
			this.relativeHeight = relativeHeight;
			
			if (sprite != null)
				ChangeRelativeHeight();
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
				ChangeRelativeHeight();
				ChangeSortingLayer();
			}
		}
		
		private void ChangeOpacity() {
			spriteRenderer.color = UtilityManager.GetColor(spriteRenderer.color, opacity);
		}
		
		private void ChangeRelativeHeight() {
			float gameHeightUnits = UtilityManager.GetGameHeightUnits();
			float spriteHeightUnits = sprite.bounds.size.y;
			
			float scale = relativeHeight * gameHeightUnits / spriteHeightUnits;
			transform.localScale = new Vector3(scale, scale, transform.localScale.z);
		}
		
		private void ChangeSortingLayer() {
			spriteRenderer.sortingLayerName = sortingLayer;
		}
		
		private void ChangeSprite() {
			spriteRenderer.sprite = sprite;
		}

	}

}
