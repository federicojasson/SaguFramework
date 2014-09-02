using UnityEngine;

namespace SaguFramework {
	
	public partial class Game : MonoBehaviour {
		
		private static Game instance;

		public static Game GetInstance() {
			return instance;
		}
		
	}
	
}
