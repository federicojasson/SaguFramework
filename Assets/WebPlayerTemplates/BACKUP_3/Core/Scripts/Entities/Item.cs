using UnityEngine;

namespace FrameworkNamespace {

	public class Item : MonoBehaviour {
		
		public ItemParameters Parameters;

		public void Awake() {
			if (ImageParameters.SortingLayer.Length == 0)
				ImageParameters.SortingLayer = Parameters.ItemImageSortingLayer;
		}

	}

}
