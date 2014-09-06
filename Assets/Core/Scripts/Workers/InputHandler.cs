using UnityEngine;

namespace SaguFramework {
	
	public enum InputMode {
		Disabled,
		Inventory,
		MainMenu,
		PauseMenu,
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

		public void SetCurrentInputMode() {
			// TODO: detect


			//inputMode = backupInputMode;

			Debug.Log("inputMode: " + inputMode);
		}

		public void SetInputMode(InputMode inputMode) {
			this.inputMode = inputMode;

			Debug.Log("inputMode: " + inputMode);
		}

		public void Update() {
			switch (inputMode) {
				case InputMode.Inventory : {
					CheckInputInventory();
					break;
				}

				case InputMode.MainMenu : {
					CheckInputMainMenu();
					break;
				}

				case InputMode.PauseMenu : {
					CheckInputPauseMenu();
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

		private void CheckInputMainMenu() {
			if (Input.GetKeyDown(Parameters.GetCloseMenuKey()))
				Game.CloseMenu();
		}

		private void CheckInputPauseMenu() {
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
			// TODO
		}
		
		private void NotifyOnMouseUpAsButtonPlaying(InteractiveBehaviour behaviour) {
			// TODO: la accion depende de la orden
		}
		
		private void NotifyOnMouseUpAsButtonUsingInventoryItem(InteractiveBehaviour behaviour) {
			// TODO: la accion depende de la orden
		}

	}
	
}
