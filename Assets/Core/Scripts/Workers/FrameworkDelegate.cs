using UnityEngine;

namespace SaguFramework {
	
	public class FrameworkDelegate : Worker {
		
		private static FrameworkDelegate instance;
		
		public static FrameworkDelegate GetInstance() {
			return instance;
		}

		public FrameworkParameters FrameworkParameters;

		public override void Awake() {
			base.Awake();
			instance = this;
		}

	}
	
}
