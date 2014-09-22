using System;
using UnityEngine;

namespace SaguFramework {
	
	// TODO: comentar

	[Serializable]
	public sealed class InventoryParameters {
		
		public float Height;
		public int Rows;
		public int Columns;
		public Vector2 CellSize;
		public Vector2 CellGap;
		public Vector2 TableCenter;
		public ImageParameters Image;
		public InventoryTriggerParameters HideTrigger;
		public InventoryTriggerParameters PreviousPageTrigger;
		public InventoryTriggerParameters NextPageTrigger;

	}
	
}
