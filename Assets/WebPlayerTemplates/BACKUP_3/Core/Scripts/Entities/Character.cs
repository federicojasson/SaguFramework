using UnityEngine;

namespace FrameworkNamespace {

	public class Character : MonoBehaviour {
		
		public CharacterParameters Parameters;

		public void Awake() {
			if (ImageParameters.SortingLayer.Length == 0)
				ImageParameters.SortingLayer = Parameters.CharacterImageSortingLayer;
		}

	}

}
