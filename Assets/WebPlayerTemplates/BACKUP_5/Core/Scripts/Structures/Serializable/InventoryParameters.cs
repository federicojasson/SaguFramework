using System;
using UnityEngine;

namespace SaguFramework {
	
	[Serializable]
	public class InventoryParameters {

		public ImageParameters Image;
		public Rect PreviousPageArea;
		public InteractiveParameters PreviousPageInteractive;
		public Rect NextPageArea;
		public InteractiveParameters NextPageInteractive;
		public Rect CloseArea;
		public InteractiveParameters CloseInteractive;
		public Vector2 InventoryItemsSize;
		public Vector2 InventoryItemsGap;
		public Vector2 CenterPosition;
		public int Rows;
		public int Columns;
		
	}
	
}
