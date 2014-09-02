using System;
using UnityEngine;

namespace SaguFramework {
	
	[Serializable]
	public class InventoryParameters {
		
		public ImageParameters BackgroundImage;
		public int Columns;
		public float InventoryItemsHeight;
		public float InventoryItemsHorizontalGap;
		public float InventoryItemsVerticalGap;
		public float InventoryItemsWidth;
		public BoxCollider2D NextPage;
		public BoxCollider2D PreviousPage;
		public Vector2 RelativePosition;
		public int Rows;
		
	}
	
}
