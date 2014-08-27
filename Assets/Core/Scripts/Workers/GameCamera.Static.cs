using UnityEngine;

namespace SaguFramework {
	
	public partial class GameCamera : MonoBehaviour {

		private static GameCamera instance;
		
		public static GameCamera GetInstance() {
			return instance;
		}

	}
	
}
