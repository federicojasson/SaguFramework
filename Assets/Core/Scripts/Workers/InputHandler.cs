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

		private InputMode backupInputMode;
		private InputMode inputMode;

		public override void Awake() {
			base.Awake();
			instance = this;
			inputMode = InputMode.Disabled;
		}

		public void NotifyOnMouseEnter(InteractiveBehaviour behaviour) {
			// TODO
			//behaviour.OnCursorEnter();
		}

		public void NotifyOnMouseExit(InteractiveBehaviour behaviour) {
			// TODO
			//behaviour.OnCursorExit();
		}

		public void NotifyOnTriggerEnter2D(TriggerBehaviour behaviour) {
			// TODO
			//behaviour.OnPlayerCharacterEnter();
		}
		
		public void NotifyOnTriggerExit2D(TriggerBehaviour behaviour) {
			// TODO
			//behaviour.OnPlayerCharacterExit();
		}

		public void SetBackupInputMode() {
			inputMode = backupInputMode;

			Debug.Log("inputMode: " + inputMode + " - backupInputMode: " + backupInputMode);
		}

		public void SetInputMode(InputMode inputMode) {
			if (inputMode == InputMode.PauseMenu)
				backupInputMode = this.inputMode;
			
			this.inputMode = inputMode;

			Debug.Log("inputMode: " + inputMode + " - backupInputMode: " + backupInputMode);
		}

		public void Update() {
			switch (inputMode) {
				case InputMode.Disabled : {
					CheckInputDisabled();
					break;
				}

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

		private void CheckInputDisabled() {} // TODO: remove it?

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

	}
	
}
