using UnityEngine;

namespace FrameworkNamespace {

	public partial class Inventory : MonoBehaviour {

		public void Awake() {
			instance = this;
		}

	}

}
