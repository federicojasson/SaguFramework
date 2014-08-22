using UnityEngine;

public class Menu : MonoBehaviour {

	public FadeParameters FadeInParameters;
	public FadeParameters FadeOutParameters;
	public GameImageParameters ImageParameters;

	public virtual void Awake() {
		if (FadeInParameters.Sprite == null)
			FadeInParameters.Sprite = GuiManager.GetDefaultFadeSprite();

		if (FadeOutParameters.Sprite == null)
			FadeOutParameters.Sprite = GuiManager.GetDefaultFadeSprite();

		if (ImageParameters.SortingLayer.Length == 0)
			ImageParameters.SortingLayer = Parameters.MenuImageSortingLayer;

		// Hides the menu initially
		Hide();
	}

	public void Close() {
		Destroy(gameObject);
	}
	
	public void Hide() {
		enabled = false;
	}
	
	public void Show() {
		enabled = true;
	}

}
