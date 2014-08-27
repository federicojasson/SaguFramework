using SaguFramework.Structures.Serializable;
using UnityEngine;

namespace SaguFramework.Workers {
	
	public partial class Game : MonoBehaviour {
		
		private static Game instance;

		public static Game GetInstance() {
			return instance;
		}
		
	}
	
}
