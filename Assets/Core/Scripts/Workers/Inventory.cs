namespace SaguFramework {
	
	public class Inventory : Worker {

		private static Inventory instance;
		
		public static Inventory GetInstance() {
			return instance;
		}
		
		public override void Awake() {
			base.Awake();
			instance = this;
		}

	}
	
}
