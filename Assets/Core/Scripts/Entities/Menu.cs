using UnityEngine;

public class Menu : MonoBehaviour {

	public FadeParameters FadeInParameters;
	public FadeParameters FadeOutParameters;
	public GameImageParameters ImageParameters;

	public virtual void Awake() {
		if (FadeInParameters.Texture == null)
			FadeInParameters.Texture = GuiManager.GetDefaultFadeTexture();

		if (FadeOutParameters.Texture == null)
			FadeOutParameters.Texture = GuiManager.GetDefaultFadeTexture();

		if (ImageParameters.SortingLayer.Length == 0)
			ImageParameters.SortingLayer = Parameters.MenuImageSortingLayer;

		// Hides the menu initially
		Hide();
	}

	public void Close() {
		Destroy(gameObject);
	}
	
	public void Hide() {
		gameObject.SetActive(false);
	}
	
	public void Show() {
		gameObject.SetActive(true);
	}

}
