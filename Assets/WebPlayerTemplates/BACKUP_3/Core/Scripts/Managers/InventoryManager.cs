using System.Collections.Generic;

namespace FrameworkNamespace {

	public static class InventoryManager {

		private static List<InventoryItem> inventoryItems;

		static InventoryManager() {
			inventoryItems = new List<InventoryItem>();
		}

		public static void ClearInventory() {
			inventoryItems.Clear();
		}

	}

}
