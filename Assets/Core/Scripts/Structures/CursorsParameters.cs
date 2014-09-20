using System;
using UnityEngine;

namespace SaguFramework {
	
	[Serializable]
	public sealed class CursorsParameters {

		public Vector2 CursorPreferredSize;
		public Vector2 UsedInventoryItemPreferredSize;
		public Texture2D ClickTexture;
		public Texture2D LookTexture;
		public Texture2D PickUpTexture;
		public Texture2D SpeakTexture;
		public Texture2D WalkTexture;
		
	}
	
}
