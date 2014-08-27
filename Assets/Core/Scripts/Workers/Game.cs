using SaguFramework.Structures.Serializable;
using UnityEngine;

namespace SaguFramework.Workers {

	public partial class Game : MonoBehaviour {

		public GameParameters GameParameters;

		public void Awake() {
			// Sets itself as the singleton instance
			instance = this;
		}

	}

}
