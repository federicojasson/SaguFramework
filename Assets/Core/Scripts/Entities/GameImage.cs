using UnityEngine;

public class GameImage : MonoBehaviour {

	private SpriteRenderer spriteRenderer;

	public void Awake() {
		spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
	}

	public float GetOpacity() {
		return spriteRenderer.color.a;
	}
	
	public void SetOpacity(float opacity) {
		spriteRenderer.color = UtilityManager.GetColor(spriteRenderer.color, opacity);
	}

	public void SetParameters(GameImageParameters parameters) {
		SetOpacity(parameters.Opacity);
		SetSize(parameters.Size);
		SetSortingLayer(parameters.SortingLayer);
		SetSprite(parameters.Sprite);
	}

	public void SetSize(float size) {
		int pixelsPerUnit = Parameters.GetPixelsPerUnit();
		float spriteWidth = spriteRenderer.bounds.size.x;
		float spriteHeight = spriteRenderer.bounds.size.y;

		float xScale = size * UtilityManager.GetGameScreenWidth() / (pixelsPerUnit * spriteWidth);
		float yScale = size * UtilityManager.GetGameScreenHeight() / (pixelsPerUnit * spriteHeight);

		transform.localScale = new Vector3(xScale, yScale, transform.localScale.z);
	}

	public void SetSortingLayer(string sortingLayer) {
		spriteRenderer.sortingLayerName = sortingLayer;
	}

	public void SetSprite(Sprite sprite) {
		spriteRenderer.sprite = sprite;
	}
	
}
