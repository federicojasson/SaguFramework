namespace SaguFramework {
	
	public class InventoryPreviousPageInteractiveBehaviour : InteractiveBehaviour {
		
		public override void OnCursorClick() {
			InventoryHandler.GetInstance().PreviousPage();
		}

	}
	
}
