using UnityEngine;

namespace FrameworkNamespace {

	public class Room : MonoBehaviour {

		public RoomParameters Parameters;

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
