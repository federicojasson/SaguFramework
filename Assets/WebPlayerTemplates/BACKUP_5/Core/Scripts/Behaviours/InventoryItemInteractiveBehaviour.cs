using SaguFramework;

namespace SaguFramework {
	
	public class InventoryItemInteractiveBehaviour : InteractiveBehaviour {
		
		public override void OnCursorClick() {
			InventoryHandler.GetInstance().SelectItem(Utilities.GetGrandparent(this).GetComponent<InventoryItem>());
		}

	}
	
}
