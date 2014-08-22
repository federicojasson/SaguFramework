using UnityEngine;

public class Room : MonoBehaviour {
	
	public GameImageParameters BackgroundImageParameters;
	public Vector2Map EntryPositions;
	public FadeParameters FadeInParameters;
	public FadeParameters FadeOutParameters;
	public GameImageParameters ForegroundImageParameters;
	public float ScaleFactor;

	public virtual void Awake() {
		if (BackgroundImageParameters.SortingLayer.Length == 0)
			BackgroundImageParameters.SortingLayer = Parameters.RoomBackgroundImageSortingLayer;

		if (FadeInParameters.Sprite == null)
			FadeInParameters.Sprite = GuiManager.GetDefaultFadeSprite();
		
		if (FadeOutParameters.Sprite == null)
			FadeOutParameters.Sprite = GuiManager.GetDefaultFadeSprite();

		if (ForegroundImageParameters.SortingLayer.Length == 0)
			ForegroundImageParameters.SortingLayer = Parameters.RoomForegroundImageSortingLayer;
	}

}
