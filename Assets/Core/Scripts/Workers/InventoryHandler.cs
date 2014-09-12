using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {
	
	public class InventoryHandler : Worker {

		private static int page;

		static InventoryHandler() {
			page = 0;
		}

		public static void ToggleInventory() {
			Inventory inventory = Objects.GetInventory();
			if (inventory.IsShowing()) {
				Objects.GetInventory().Hide();
				HideInventoryItems();
			} else {
				Objects.GetInventory().Show();
				ShowInventoryItems();
			}

			GameHandler.UpdateGameMode();
		}

		public static void ShowPreviousPage() {
			int previousPage = Mathf.Max(0, page - 1);

			if (page != previousPage) {
				page = previousPage;
				ShowInventoryItems();
			}
		}

		public static void ShowNextPage() {
			int nextPage = Mathf.Min(GetPageCount() - 1, page + 1);

			if (page != nextPage) {
				page = nextPage;
				ShowInventoryItems();
			}
		}

		private static int GetCellsPerPage() {
			InventoryParameters parameters = Parameters.GetInventoryParameters();
			int rows = parameters.Rows;
			int columns = parameters.Columns;

			return rows * columns;
		}
		
		private static int GetPageCount() {
			int inventoryItemCount = Objects.GetInventoryItems().Count;
			return Mathf.CeilToInt(inventoryItemCount / (float) GetCellsPerPage());
		}

		private static void HideInventoryItems() {
			foreach (InventoryItem inventoryItem in Objects.GetInventoryItems())
				inventoryItem.Hide();
		}

		private static void ShowInventoryItems() {
			List<InventoryItem> inventoryItems = Objects.GetInventoryItems();
			int inventoryItemCount = inventoryItems.Count;

			if (inventoryItemCount == 0)
				return;

			HideInventoryItems();

			int cellsPerPage = GetCellsPerPage();
			int index = page * cellsPerPage;
			int count;
			if (page < GetPageCount() - 1)
				count = cellsPerPage;
			else
				count = 1 + (inventoryItemCount - 1 + cellsPerPage) % cellsPerPage;

			List<InventoryItem> pageInventoryItems = inventoryItems.GetRange(index, count);
			
			InventoryParameters inventoryParameters = Parameters.GetInventoryParameters();
			int rows = inventoryParameters.Rows;
			int columns = inventoryParameters.Columns;
			Vector2 cellSize = Geometry.GameToWorldSize(inventoryParameters.CellSize);
			Vector2 cellGap = Geometry.GameToWorldSize(inventoryParameters.CellGap);
			Vector2 tableCenter = Geometry.GameToWorldPosition(inventoryParameters.TableCenter);
			Vector2 inventoryPosition = Objects.GetInventory().GetPosition();
			Vector2 tableCenterPosition = tableCenter + inventoryPosition - 0.5f * Geometry.GetGameSizeInUnits();

			float cellAndGapWidth = cellSize.x + cellGap.x;
			float cellAndGapHeight = cellSize.y + cellGap.y;
			float tableWidth = columns * cellAndGapWidth - cellGap.x;
			float tableHeight = rows * cellAndGapHeight - cellGap.y;

			float offsetX = tableCenterPosition.x - 0.5f * tableWidth + 0.5f * cellSize.x;
			float offsetY = tableCenterPosition.y - 0.5f * tableHeight + 0.5f * cellSize.y;

			int row = rows - 1;
			int column = 0;
			foreach (InventoryItem inventoryItem in pageInventoryItems) {
				float x = offsetX + column * cellAndGapWidth;
				float y = offsetY + row * cellAndGapHeight;
				inventoryItem.SetPosition(new Vector2(x, y));
				inventoryItem.Show();

				column = (column + 1) % columns;
				if (column == 0)
					row = (rows + row - 1) % rows;
			}
		}

	}
	
}
