using UnityEngine;

namespace FrameworkNamespace {

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

			if (FadeInParameters.Texture == null)
				FadeInParameters.Texture = GuiManager.GetDefaultFadeTexture();
			
			if (FadeOutParameters.Texture == null)
				FadeOutParameters.Texture = GuiManager.GetDefaultFadeTexture();

			if (ForegroundImageParameters.SortingLayer.Length == 0)
				ForegroundImageParameters.SortingLayer = Parameters.RoomForegroundImageSortingLayer;
		}

	}

}
