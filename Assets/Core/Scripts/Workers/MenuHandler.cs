namespace SaguFramework {
	
	public class MenuHandler : Worker {

		private static MenuHandler instance;
		
		public static MenuHandler GetInstance() {
			return instance;
		}
		
		public override void Awake() {
			base.Awake();
			instance = this;
		}

	}
	
}
