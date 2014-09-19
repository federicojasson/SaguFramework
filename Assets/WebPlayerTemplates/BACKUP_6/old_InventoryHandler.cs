using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SaguFramework {

	// TODO: worker?

	public class old_InventoryHandler : old_Worker {

		/*private static int page;

		static old_InventoryHandler() {
			page = 0;
		}

		public static void ToggleInventory() {
			Inventory inventory = Objects.GetInventory();
			if (inventory.IsActivated()) {
				foreach (InventoryTrigger inventoryTrigger in Objects.GetInventoryTriggers())
					inventoryTrigger.Deactivate();

				Objects.GetInventory().Deactivate();
				HideInventoryItems();
			} else {
				foreach (InventoryTrigger inventoryTrigger in Objects.GetInventoryTriggers())
					inventoryTrigger.Activate();

				Objects.GetInventory().Activate();
				ShowInventoryItems();
			}

			SoundPlayer.PlayInventoryEffect();
			GameHandler.UpdateGameMode();
		}

		public static void ShowNextPage() {
			int nextPage = Mathf.Min(GetPageCount() - 1, page + 1);

			if (page < nextPage) {
				SoundPlayer.PlayInventoryPageEffect();
				page = nextPage;
				ShowInventoryItems();
			}
		}
		
		public static void ShowPreviousPage() {
			int previousPage = Mathf.Max(0, page - 1);
			
			if (page > previousPage) {
				SoundPlayer.PlayInventoryPageEffect();
				page = previousPage;
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
			foreach (InventoryItem inventoryItem in Objects.GetInventoryItems().Values)
				inventoryItem.Deactivate();
		}

		private static void ShowInventoryItems() {
			List<InventoryItem> inventoryItems = Objects.GetInventoryItems().Values.ToList();
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
		}*/

	}
	
}
