namespace SaguFramework {
	
	public class InventoryNextPageInteractiveBehaviour : InteractiveBehaviour {
		
		public override void OnCursorClick() {
			InventoryHandler.GetInstance().NextPage();
		}

	}
	
}
