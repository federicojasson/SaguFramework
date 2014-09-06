namespace SaguFramework {
	
	public class InventoryHandler : Worker {

		private static InventoryHandler instance;
		
		public static InventoryHandler GetInstance() {
			return instance;
		}
		
		public override void Awake() {
			base.Awake();
			instance = this;
		}

		public void HideInventory() {
			Objects.GetInventory().Hide();
		}

		public void ShowInventory() {
			Objects.GetInventory().Show();
		}

	}
	
}
