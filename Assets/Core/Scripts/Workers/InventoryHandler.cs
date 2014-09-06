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
			Inventory inventory = Objects.GetInventory();
			inventory.Show();
			
			List<InventoryItem> inventoryItems = Objects.GetInventoryItems();

			if (inventoryItems.Count == 0)
				return;

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

			Vector2 position = (Vector2) inventory.transform.position + Geometry.GameToWorldPosition(parameters.CenterPosition);
			Vector2 size = Geometry.GameToWorldSize(parameters.InventoryItemsSize);
			Vector2 gap = parameters.InventoryItemsGap;
			int rows = parameters.Rows;
			int columns = parameters.Columns;
			int row = 0;
			int column = 0;
			foreach (InventoryItem inventoryItem in pageInventoryItems) {
				float x = column * (size.x + gap.x) + position.x - (columns / 2f) * (size.x + gap.x) + size.x / 2f;
				float y = (rows - 1 - row) * (size.y + gap.y) + position.y - (rows / 2f) * (size.y + gap.y) + size.y / 2f;
				inventoryItem.SetPosition(new Vector2(x, y));
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
