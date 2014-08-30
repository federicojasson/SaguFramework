using UnityEngine;

namespace SaguFramework {
	
	public partial class Masker : MonoBehaviour {

		private static Masker instance;
		
		public static Masker GetInstance() {
			return instance;
		}

	}
	
}
