using UnityEngine;

public class SplashScreen : MonoBehaviour {

	public FadeParameters FadeInParameters;
	public FadeParameters FadeOutParameters;
	public GameImage Image;

	public virtual void Awake() {
		if (FadeInParameters.Sprite == null)
			FadeInParameters.Sprite = GuiManager.GetDefaultFadeSprite();
		
		if (FadeOutParameters.Sprite == null)
			FadeOutParameters.Sprite = GuiManager.GetDefaultFadeSprite();
	}

}
