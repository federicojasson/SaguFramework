using UnityEngine;

namespace SaguFramework {
	
	public partial class AudioPlayer : MonoBehaviour {
		
		private static AudioPlayer instance;
		
		public static AudioPlayer GetInstance() {
			return instance;
		}
		
	}
	
}
