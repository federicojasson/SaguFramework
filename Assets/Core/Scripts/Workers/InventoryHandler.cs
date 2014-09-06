using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {
	
	public class InventoryHandler : Worker {

		private static InventoryHandler instance;
		
		public static InventoryHandler GetInstance() {
			return instance;
		}

		private int page;
		private InventoryItem selectedItem;
		
		public override void Awake() {
			base.Awake();
			instance = this;
			page = 0;
		}

		public void HideInventory() {
			foreach (InventoryItem inventoryItem in Objects.GetInventoryItems())
				inventoryItem.Hide();

			Objects.GetInventory().Hide();
		}

		public void NextPage() {
			page = Mathf.Min(GetPageCount() - 1, page + 1);

			HideInventory();
			ShowInventory();
		}

		public void PreviousPage() {
			page = Mathf.Max(0, page - 1);

			HideInventory();
			ShowInventory();
		}

		public void SelectItem(InventoryItem inventoryItem) {
			selectedItem = inventoryItem;
			InputHandler.GetInstance().SetInputMode(InputMode.UsingInventoryItem);
		}

		public void ShowInventory() {
			Objects.GetInventory().Show();
			
			List<InventoryItem> inventoryItems = Objects.GetInventoryItems();
			int itemsPerPage = GetItemsPerPage();
			int index = page * itemsPerPage;
			int count;
			if (page == GetPageCount() - 1) {
				count = inventoryItems.Count % itemsPerPage;
				if (count == 0)
					count = itemsPerPage;
			} else
				count = itemsPerPage;

			InventoryParameters parameters = Parameters.GetInventoryParameters();
			List<InventoryItem> pageInventoryItems = inventoryItems.GetRange(index, count);

			int row = 0;
			int column = 0;
			foreach (InventoryItem inventoryItem in pageInventoryItems) {
				; // TODO


				float x = column * (width + horizontalGap) + positionInWorld.x - (columns / 2f) * (width + horizontalGap) + width / 2f;
				float y = (rows - 1 - row) * (height + verticalGap) + positionInWorld.y - (rows / 2f) * (height + verticalGap) + height / 2f;
				inventoryItem.transform.position = UtilityManager.GetPosition(new Vector2(x, y), inventoryItem.transform.position.z);

				inventoryItem.SetPosition(new Vector2());
				inventoryItem.Show();
				
				column = (column + 1) % columns;
				if (column == 0)
					row = (row + 1) % rows;
			}
		}

		public void UnselectItem() {
			selectedItem = null;
			InputHandler.GetInstance().SetCurrentInputMode();
		}

		private int GetItemsPerPage() {
			InventoryParameters parameters = Parameters.GetInventoryParameters();
			int rows = parameters.Rows;
			int columns = parameters.Columns;
			return rows * columns;
		}

		private int GetPageCount() {
			List<InventoryItem> inventoryItems = Objects.GetInventoryItems();
			return Mathf.CeilToInt(inventoryItems.Count / (float) GetItemsPerPage());
		}

	}
	
}
