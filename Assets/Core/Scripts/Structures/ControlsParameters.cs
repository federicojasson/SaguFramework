using System;
using UnityEngine;

namespace SaguFramework {

	[Serializable]
	public class ControlsParameters {

		public bool UseMouseWheel;
		public KeyCode[] CloseMenuKeys;
		public KeyCode[] PauseGameKeys;
		public KeyCode[] SetNextOrderKeys;
		public KeyCode[] SetPreviousOrderKeys;
		public KeyCode[] ToggleInventoryKeys;
		public KeyCode[] UnselectInventoryItemKeys;

	}
	
}
