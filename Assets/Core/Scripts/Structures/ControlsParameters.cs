using System;
using UnityEngine;

namespace SaguFramework {
	
	// TODO: comentar

	[Serializable]
	public sealed class ControlsParameters {

		public bool UseMouseWheel;
		public KeyCode[] CloseMenuKeys;
		public KeyCode[] PauseGameKeys;
		public KeyCode[] SetNextOrderKeys;
		public KeyCode[] SetPreviousOrderKeys;
		public KeyCode[] ToggleInventoryKeys;
		public KeyCode[] UnselectInventoryItemKeys;

	}
	
}
