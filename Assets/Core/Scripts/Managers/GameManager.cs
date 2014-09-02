using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {

	public static class GameManager {
		
		// TODO: usar esta clase unicamente como interfaz para las clases del juego

		public static void AddToInventory(string inventoryItemId) {
			// TODO: order and comment

			InventoryParameters inventoryParameters = ParameterManager.GetInventoryParameters();
			InventoryItemParameters inventoryItemParameters = ParameterManager.GetInventoryItemParameters(inventoryItemId);

			CreationManager.CreateInventoryItem(inventoryItemParameters, inventoryParameters.InventoryItemsHeight);

			StateManager.AddInventoryItem(inventoryItemId);
		}

		public static void ChangeRoom(string roomId, string entryPositionId, bool useSplashScreen) {
			// Gets the new room's parameters
			RoomParameters roomParameters = ParameterManager.GetRoomParameters(roomId);

			// Gets the player character's new location
			Vector2 positionInGame = roomParameters.EntryPositions[entryPositionId];
			Location location = new Location(positionInGame, roomId);

			// Gets the player character's ID
			string playerCharacterId = StateManager.GetPlayerCharacterId();

			// Sets the player character's new location
			StateManager.SetCharacterLocation(playerCharacterId, location);

			// Sets the current room's ID
			StateManager.SetCurrentRoomId(roomId);

			// Reloads the room scene
			ObjectManager.GetLoader().LoadScene(ParameterManager.SceneRoom);
		}

		public static void CloseMenu() {
			// Closes the last opened menu
			ObjectManager.GetMenu().Close();

			// Checks if there is another opened menu and shows it
			if (ObjectManager.GetMenuCount() > 0)
				ObjectManager.GetMenu().Show();
		}

		public static void Exit() {
			Application.Quit();
		}

		public static string[] GetStateIds() {
			return StateManager.GetStateIds();
		}

		public static void HideInventory() {
			// TODO: order and comment

			// Hides the inventory
			ObjectManager.GetInventory().Hide();

			// TODO: hide all or only the ones showing?
			foreach (InventoryItem inventoryItem in ObjectManager.GetInventoryItems())
				inventoryItem.Hide();
		}

		public static void LoadGame(string stateId, bool useSplashScreen) {
			// Loads the state
			StateManager.LoadState(stateId);

			// Gets the loader
			Loader loader = ObjectManager.GetLoader();

			if (useSplashScreen)
				// Loads the splash screen scene
				loader.LoadScene(ParameterManager.SceneSplashScreen);
			else
				// Loads the room scene
				loader.LoadScene(ParameterManager.SceneRoom);
		}

		public static void NewGame(bool useSplashScreen) {
			// Loads the initial state
			StateManager.LoadInitialState();

			// Gets the loader
			Loader loader = ObjectManager.GetLoader();

			if (useSplashScreen)
				// Loads the splash screen scene
				loader.LoadScene(ParameterManager.SceneSplashScreen);
			else
				// Loads the room scene
				loader.LoadScene(ParameterManager.SceneRoom);
		}

		public static void OpenMainMenu() {
			// Loads the main menu scene
			ObjectManager.GetLoader().LoadScene(ParameterManager.SceneMainMenu);
		}

		public static void OpenMenu(string menuId) {
			// Checks if there is any opened menu and hides it
			if (ObjectManager.GetMenuCount() > 0)
				ObjectManager.GetMenu().Hide();

			// Gets the menu's parameters
			MenuParameters menuParameters = ParameterManager.GetMenuParameters(menuId);
			
			// Creates the menu
			CreationManager.CreateMenu(menuParameters);

			// Shows the menu
			ObjectManager.GetMenu().Show();
		}

		public static void SaveGame(string stateId) {
			// Saves the state
			StateManager.SaveState(stateId);
		}

		public static void ShowInventory() {
			// TODO: order this

			// Shows the inventory
			Inventory inventory = ObjectManager.GetInventory();
			inventory.Show();

			// Gets the page's inventory items
			InventoryParameters inventoryParameters = ParameterManager.GetInventoryParameters();
			int inventoryPage = StateManager.GetInventoryPage();
			int rows = inventoryParameters.Rows;
			int columns = inventoryParameters.Columns;
			int inventoryItemsPerPage = rows * columns;
			List<InventoryItem> inventoryItems = ObjectManager.GetInventoryItems();
			int index = inventoryPage * inventoryItemsPerPage;

			int pageCount = Mathf.CeilToInt(inventoryItems.Count / (float) inventoryItemsPerPage);

			if (inventoryItems.Count == 0)
				return;

			if (inventoryPage > pageCount - 1)
				return;

			int count;

			if (inventoryPage == pageCount - 1) {
				count = inventoryItems.Count % inventoryItemsPerPage;
				if (count == 0)
					count = inventoryItemsPerPage;
			} else
				count = inventoryItemsPerPage;
			
			List<InventoryItem> pageInventoryItems = ObjectManager.GetInventoryItems().GetRange(index, count);

			Debug.Log(Screen.height);

			// Shows the page's inventory items
			float horizontalGap = UtilityManager.GameToWorldWidth(inventoryParameters.InventoryItemsHorizontalGap);
			float verticalGap = UtilityManager.GameToWorldHeight(inventoryParameters.InventoryItemsVerticalGap);
			float height = UtilityManager.GameToWorldHeight(inventoryParameters.InventoryItemsHeight);
			float width = UtilityManager.GameToWorldWidth(inventoryParameters.InventoryItemsWidth);
			float xInWorld = inventory.transform.position.x - UtilityManager.GetGameWidthUnits() / 2f + UtilityManager.GetGameWidthUnits() * inventoryParameters.RelativePosition.x;
			float yInWorld = inventory.transform.position.y - UtilityManager.GetGameHeightUnits() / 2f + UtilityManager.GetGameHeightUnits() * inventoryParameters.RelativePosition.y;
			Vector2 positionInWorld = new Vector2(xInWorld, yInWorld);
			int row = 0;
			int column = 0;
			foreach (InventoryItem inventoryItem in pageInventoryItems) {
				// TODO: usar gap
				//float x = column * (width + gap) + width / 2f + positionInGame.x - (columns / 2f) * (width + gap);
				//float y = (rows - 1 - row) * (height + gap) - height / 2f + positionInGame.y + (rows / 2f) * (height + gap);
				float x = column * (width + horizontalGap) + positionInWorld.x - (columns / 2f) * (width + horizontalGap) + width / 2f;
				float y = (rows - 1 - row) * (height + verticalGap) + positionInWorld.y - (rows / 2f) * (height + verticalGap) + height / 2f;
				inventoryItem.transform.position = UtilityManager.GetPosition(new Vector2(x, y), inventoryItem.transform.position.z);
				inventoryItem.Show();

				column = (column + 1) % columns;
				if (column == 0)
					row = (row + 1) % rows;
			}
		}

	}

}
