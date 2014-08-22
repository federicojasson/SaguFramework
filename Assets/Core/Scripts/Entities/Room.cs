using UnityEngine;

public class Room : MonoBehaviour {
	
	public GameImage BackgroundImage;
	public Vector2Map EntryPositions;
	public FadeParameters FadeInParameters;
	public FadeParameters FadeOutParameters;
	public GameImage ForegroundImage;
	public float ScaleFactor;

	public virtual void Awake() {
		if (FadeInParameters.Sprite == null)
			FadeInParameters.Sprite = GuiManager.GetDefaultFadeSprite();
		
		if (FadeOutParameters.Sprite == null)
			FadeOutParameters.Sprite = GuiManager.GetDefaultFadeSprite();
	}

}
