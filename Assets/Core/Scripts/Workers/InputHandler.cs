using UnityEngine;

namespace SaguFramework {
	
	public enum InputMode {
		Disabled,
		Inventory,
		Menu,
		Playing,
		UsingInventoryItem
	};
	
	public class InputHandler : Worker {

		private static InputHandler instance;

		public static InputHandler GetInstance() {
			return instance;
		}

		private InputMode inputMode;

		public override void Awake() {
			base.Awake();
			instance = this;
			Disable();
		}
		
		public void Disable() {
			inputMode = InputMode.Disabled;
		}

		public void NotifyOnMouseEnter(InteractiveBehaviour behaviour) {
			switch (inputMode) {
				case InputMode.Inventory : {
					NotifyOnMouseEnterInventory(behaviour);
					break;
				}
					
				case InputMode.Playing : {
					NotifyOnMouseEnterPlaying(behaviour);
					break;
				}
					
				case InputMode.UsingInventoryItem : {
					NotifyOnMouseEnterUsingInventoryItem(behaviour);
					break;
				}
			}
		}

		public void NotifyOnMouseExit(InteractiveBehaviour behaviour) {
			switch (inputMode) {
				case InputMode.Inventory : {
					NotifyOnMouseExitInventory(behaviour);
					break;
				}
					
				case InputMode.Playing : {
					NotifyOnMouseExitPlaying(behaviour);
					break;
				}
					
				case InputMode.UsingInventoryItem : {
					NotifyOnMouseExitUsingInventoryItem(behaviour);
					break;
				}
			}
		}

		public void NotifyOnMouseUpAsButton(InteractiveBehaviour behaviour) {
			switch (inputMode) {
				case InputMode.Inventory : {
					NotifyOnMouseUpAsButtonInventory(behaviour);
					break;
				}
					
				case InputMode.Playing : {
					NotifyOnMouseUpAsButtonPlaying(behaviour);
					break;
				}
					
				case InputMode.UsingInventoryItem : {
					NotifyOnMouseUpAsButtonUsingInventoryItem(behaviour);
					break;
				}
			}
		}

		public void NotifyOnTriggerEnter2D(TriggerBehaviour behaviour) {
			behaviour.OnPlayerCharacterEnter();
		}
		
		public void NotifyOnTriggerExit2D(TriggerBehaviour behaviour) {
			behaviour.OnPlayerCharacterExit();
		}

		// TODO
		/*public void SetInputMode(InputMode inputMode) {
			this.inputMode = inputMode;
		}*/

		public void Update() {
			switch (inputMode) {
				case InputMode.Inventory : {
					CheckInputInventory();
					break;
				}

				case InputMode.Menu : {
					CheckInputMenu();
					break;
				}

				case InputMode.Playing : {
					CheckInputPlaying();
					break;
				}

				case InputMode.UsingInventoryItem : {
					CheckInputUsingInventoryItem();
					break;
				}
			}
		}

		public void UpdateInputMode() {
			if (Objects.GetMenuCount() > 0) {
				inputMode = InputMode.Menu;
				return;
			}

			if (InventoryHandler.GetInstance().GetSelectedItem() != null) {
				inputMode = InputMode.UsingInventoryItem;
				return;
			}
			
			Inventory inventory = Objects.GetInventory();
			if (inventory != null && inventory.IsShowing()) {
				inputMode = InputMode.Inventory;
				return;
			}
			
			if (Objects.GetRoom() != null) {
				inputMode = InputMode.Playing;
				return;
			}
			
			inputMode = InputMode.Disabled;
		}





		private void CheckInputInventory() {
			if (Input.GetKeyDown(Parameters.GetPauseGameKey()))
				Game.PauseGame();

			if (Input.GetKeyDown(Parameters.GetToggleInventoryKey()))
				Game.HideInventory();

			if (Input.GetMouseButtonDown(Parameters.GetExecuteOrderMouse()))
				;//OrderManager.ExecuteCurrentOrder(); TODO
			
			if (Input.GetMouseButtonDown(Parameters.GetNextOrderMouse()))
				;//OrderManager.SetNextRotativeOrder(); TODO
		}

		private void CheckInputMenu() {
			if (Input.GetKeyDown(Parameters.GetCloseMenuKey()))
				Game.CloseMenu();
		}

		private void CheckInputPlaying() {
			if (Input.GetKeyDown(Parameters.GetPauseGameKey()))
				Game.PauseGame();

			if (Input.GetKeyDown(Parameters.GetToggleInventoryKey()))
				Game.ShowInventory();

			if (Input.GetMouseButtonDown(Parameters.GetExecuteOrderMouse()))
				;//OrderManager.ExecuteCurrentOrder(); TODO
			
			if (Input.GetMouseButtonDown(Parameters.GetNextOrderMouse()))
				;//OrderManager.SetNextRotativeOrder(); TODO
		}
		
		private void CheckInputUsingInventoryItem() {
		}



















		private void NotifyOnMouseEnterInventory(InteractiveBehaviour behaviour) {
			Component parent = Utilities.GetGrandparent(behaviour);

			if (parent.GetComponent<Inventory>() != null) {
				behaviour.OnCursorEnter();
				return;
			}

			if (parent.GetComponent<InventoryItem>() != null) {
				behaviour.OnCursorEnter();
				return;
			}
		}

		private void NotifyOnMouseEnterPlaying(InteractiveBehaviour behaviour) {
			behaviour.OnCursorEnter();
		}

		private void NotifyOnMouseEnterUsingInventoryItem(InteractiveBehaviour behaviour) {
			behaviour.OnCursorEnter();
		}





		
		private void NotifyOnMouseExitInventory(InteractiveBehaviour behaviour) {
			Component parent = Utilities.GetGrandparent(behaviour);
			
			if (parent.GetComponent<Inventory>() != null) {
				behaviour.OnCursorExit();
				return;
			}
			
			if (parent.GetComponent<InventoryItem>() != null) {
				behaviour.OnCursorExit();
				return;
			}
		}
		
		private void NotifyOnMouseExitPlaying(InteractiveBehaviour behaviour) {
			behaviour.OnCursorExit();
		}
		
		private void NotifyOnMouseExitUsingInventoryItem(InteractiveBehaviour behaviour) {
			behaviour.OnCursorExit();
		}




		
		private void NotifyOnMouseUpAsButtonInventory(InteractiveBehaviour behaviour) {
			Component parent = Utilities.GetGrandparent(behaviour);
			
			if (parent.GetComponent<Inventory>() != null) {
				behaviour.OnCursorClick();
				return;
			}
			
			if (parent.GetComponent<InventoryItem>() != null) {
				behaviour.OnCursorClick();
				return;
			}
		}
		
		private void NotifyOnMouseUpAsButtonPlaying(InteractiveBehaviour behaviour) {
			// TODO: la accion depende de la orden
		}
		
		private void NotifyOnMouseUpAsButtonUsingInventoryItem(InteractiveBehaviour behaviour) {
			// TODO: la accion depende de la orden
		}

	}
	
}
