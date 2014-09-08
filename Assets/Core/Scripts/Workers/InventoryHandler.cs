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

		public InventoryItem GetSelectedItem() {
			return selectedItem;
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

			Vector2 position = (Vector2) inventory.transform.position + Geometry.GameToWorldPosition(parameters.CenterPosition) - 0.5f * new Vector2(Geometry.GetGameWidthInUnits(), Geometry.GetGameHeightInUnits());
			Vector2 size = Geometry.GameToWorldSize(parameters.InventoryItemsSize);
			Vector2 gap = Geometry.GameToWorldSize(parameters.InventoryItemsGap);
			int rows = parameters.Rows;
			int columns = parameters.Columns;
			int row = 0;
			int column = 0;
			foreach (InventoryItem inventoryItem in pageInventoryItems) {
				float x = position.x - 0.5f * (columns * size.x + (columns - 1) * gap.x) + column * (size.x + gap.x) + 0.5f * size.x;
				float y = position.y + 0.5f * (rows * size.y + (rows - 1) * gap.y) - row * (size.y + gap.y) - 0.5f * size.y;
				inventoryItem.SetPosition(new Vector2(x, y));
				inventoryItem.Show();
				
				column = (column + 1) % columns;
				if (column == 0)
					row = (row + 1) % rows;
			}
		}

		public void UnselectItem() {
			selectedItem = null;
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
