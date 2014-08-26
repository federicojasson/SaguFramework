using UnityEngine;

namespace FrameworkNamespace {

	public class Menu : MonoBehaviour {

		public GameImageParameters ImageParameters;

		public virtual void Awake() {
			if (ImageParameters.SortingLayer.Length == 0)
				ImageParameters.SortingLayer = Parameters.MenuImageSortingLayer;

			// Hides the menu initially
			Hide();
		}

		public void Close() {
			Destroy(this);
		}

		public void Hide() {
			gameObject.SetActive(false);
		}
		
		public void Show() {
			gameObject.SetActive(true);
		}
		
	}

}
