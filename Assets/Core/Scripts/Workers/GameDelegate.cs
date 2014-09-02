using UnityEngine;

namespace SaguFramework {
	
	public class GameDelegate : Worker {

		private static GameDelegate instance;
		
		public static GameDelegate GetInstance() {
			return instance;
		}

		public GameParameters GameParameters;
		
		public override void Awake() {
			base.Awake();
			instance = this;
		}

	}
	
}
