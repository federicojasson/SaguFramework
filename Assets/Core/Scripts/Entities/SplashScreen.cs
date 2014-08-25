using UnityEngine;

public class SplashScreen : MonoBehaviour {

	public FadeParameters FadeInParameters;
	public FadeParameters FadeOutParameters;
	public GameImageParameters ImageParameters;

	public virtual void Awake() {
		if (FadeInParameters.Texture == null)
			FadeInParameters.Texture = GuiManager.GetDefaultFadeTexture();
		
		if (FadeOutParameters.Texture == null)
			FadeOutParameters.Texture = GuiManager.GetDefaultFadeTexture();
		
		if (ImageParameters.SortingLayer.Length == 0)
			ImageParameters.SortingLayer = Parameters.SplashScreenImageSortingLayer;
	}

}
