using UnityEngine;

namespace SaguFramework.Workers {
	
	public partial class Assets : MonoBehaviour {
		
		private static Assets instance;

		public static Assets GetInstance() {
			return instance;
		}
		
	}
	
}
