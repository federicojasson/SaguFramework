using UnityEngine;

namespace FrameworkNamespace {

	public class Item : MonoBehaviour {
		
		public GameImageParameters ImageParameters;

		public void Awake() {
			if (ImageParameters.SortingLayer.Length == 0)
				ImageParameters.SortingLayer = Parameters.ItemImageSortingLayer;
		}

	}

}
