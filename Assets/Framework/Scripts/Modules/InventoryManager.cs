using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SaguFramework {

	/// Manages the entities related with the inventory: the inventory itself, the triggers and the items.
	public static class InventoryManager {

		private static int page; // The current page
		
		/// Performs class initialization tasks.
		static InventoryManager() {
			page = 0;
		}

		/// Refreshs the current page.
		/// Useful when the inventory is being shown and the items change.
		public static void RefreshCurrentPage() {
			ShowInventoryItems();
		}

		/// Shows the last page.
		/// Useful when the inventory is being shown and a new item is added.
		public static void ShowLastPage() {
			page = GetPageCount() - 1;
			ShowInventoryItems();
		}
		
		/// Shows the next page.
		public static void ShowNextPage() {
			CorrectPage();
			page++;
			ShowInventoryItems();
		}

		/// Shows the previous page.
		public static void ShowPreviousPage() {
			CorrectPage();
			page--;
			ShowInventoryItems();
		}
		
		/// Toggles the inventory: if it is being shown, it hides it, and vice versa.
		public static void ToggleInventory() {
			Inventory inventory = Entities.GetInventory();
			if (inventory.IsActivated()) {
				foreach (InventoryTrigger inventoryTrigger in Entities.GetInventoryTriggers())
					inventoryTrigger.Deactivate();
				
				Entities.GetInventory().Deactivate();
				HideInventoryItems();
			} else {
				foreach (InventoryTrigger inventoryTrigger in Entities.GetInventoryTriggers())
					inventoryTrigger.Activate();
				
				Entities.GetInventory().Activate();
				ShowInventoryItems();
			}
			
			SoundPlayer.PlayInventoryEffect();
			InputReader.RefreshInputMode();
		}

		/// Sets the page between appropriate limits.
		/// Useful because sometimes the page gets out of sync because the items change.
		private static void CorrectPage() {
			// Upper bound
			page = Mathf.Min(page, GetPageCount() - 1);

			// Lower bound
			page = Mathf.Max(page, 0);
		}
		
		/// Returns the amount of item cells per page.
		private static int GetCellsPerPage() {
			InventoryParameters parameters = Parameters.GetInventoryParameters();
			int rows = parameters.Rows;
			int columns = parameters.Columns;
			
			return rows * columns;
		}

		/// Returns the amount of pages based on the amount of items in the inventory and the cells per page.
		private static int GetPageCount() {
			int inventoryItemCount = Entities.GetInventoryItems().Count;
			return Mathf.CeilToInt(inventoryItemCount / (float) GetCellsPerPage());
		}

		/// Hides all the inventory items.
		private static void HideInventoryItems() {
			foreach (InventoryItem inventoryItem in Entities.GetInventoryItems().Values)
				inventoryItem.Deactivate();
		}

		/// Shows the inventory items of the current page.
		private static void ShowInventoryItems() {
			// Gets the inventory items in a list
			List<InventoryItem> inventoryItems = Entities.GetInventoryItems().Values.ToList();
			int inventoryItemCount = inventoryItems.Count;
			
			if (inventoryItemCount == 0)
				// There are no inventory items
				return;

			// Hides all the inventory items
			HideInventoryItems();

			// Corrects the current page value
			CorrectPage();

			// Gets the inventory item count and offset in the list, based on the current page
			int cellsPerPage = GetCellsPerPage();
			int index = page * cellsPerPage;
			int count;
			if (page < GetPageCount() - 1)
				count = cellsPerPage;
			else
				count = 1 + (inventoryItemCount - 1 + cellsPerPage) % cellsPerPage;

			// Gets the inventory items in the page
			List<InventoryItem> pageInventoryItems = inventoryItems.GetRange(index, count);

			// Calculates the offset of each inventory item and show them

			InventoryParameters inventoryParameters = Parameters.GetInventoryParameters();
			int rows = inventoryParameters.Rows;
			int columns = inventoryParameters.Columns;
			Vector2 tableCenter = inventoryParameters.TableCenter;
			
			Vector2 cellSize = Geometry.GameToWorldSize(inventoryParameters.CellSize);
			Vector2 cellGap = Geometry.GameToWorldSize(inventoryParameters.CellGap);
			
			float tableCenterOffsetX = Geometry.GameToWorldX(tableCenter.x - 0.5f);
			float tableCenterOffsetY = Geometry.GameToWorldY(tableCenter.y - 0.5f);
			
			float cellAndGapWidth = cellSize.x + cellGap.x;
			float cellAndGapHeight = cellSize.y + cellGap.y;
			float tableWidth = columns * cellAndGapWidth - cellGap.x;
			float tableHeight = rows * cellAndGapHeight - cellGap.y;
			
			float widthOffset = tableCenterOffsetX - 0.5f * tableWidth + 0.5f * cellSize.x;
			float heightOffset = tableCenterOffsetY - 0.5f * tableHeight + 0.5f * cellSize.y;
			
			int row = rows - 1;
			int column = 0;
			foreach (InventoryItem inventoryItem in pageInventoryItems) {
				float offsetX = widthOffset + column * cellAndGapWidth;
				float offsetY = heightOffset + row * cellAndGapHeight;
				inventoryItem.SetOffset(new Vector2(offsetX, offsetY));
				inventoryItem.Activate();
				
				column = (column + 1) % columns;
				if (column == 0)
					row = (rows + row - 1) % rows;
			}
		}

	}

}
