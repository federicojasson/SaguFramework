using System;
using UnityEngine;

namespace SaguFramework {
	
	// TODO: comentar

	[Serializable]
	public sealed class GraphicsParameters {

		public float GamePreferredWidth;
		public float GamePreferredHeight;
		public Color CameraBackgroundColor;
		public Texture2D DefaultFadeTexture;
		public Texture2D WindowboxTexture;
		public GUISkin Skin;
		public CursorsParameters Cursors;

	}
	
}
