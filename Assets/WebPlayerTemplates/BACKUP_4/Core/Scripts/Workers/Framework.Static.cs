using UnityEngine;

namespace SaguFramework {
	
	public partial class Framework : MonoBehaviour {
		
		private static Framework instance;
		
		public static Framework GetInstance() {
			return instance;
		}
		
	}
	
}
