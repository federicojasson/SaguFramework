using UnityEngine;

namespace SaguFramework {
	
	public partial class Fader : MonoBehaviour {

		private static Fader instance;
		
		public static Fader GetInstance() {
			return instance;
		}

	}
	
}
