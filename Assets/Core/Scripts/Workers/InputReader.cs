namespace SaguFramework {
	
	public enum InputMode {
		Deactivated,
		Playing
	};
	
	public class InputReader : Worker {

		private static InputReader instance;
		
		public static InputReader GetInstance() {
			return instance;
		}

		private InputMode mode;

		public override void Awake() {
			base.Awake();
			instance = this;
			mode = InputMode.Deactivated;
		}

		public void SetMode(InputMode mode) {
			this.mode = mode;
		}

		public void Update() {
			// TODO
		}

	}
	
}
