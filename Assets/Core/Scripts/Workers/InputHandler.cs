using UnityEngine;

namespace SaguFramework {
	
	public enum InputMode {
		Disabled,
		Inventory,
		Paused,
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
			// TODO
			behaviour.OnCursorEnter();
		}

		public void NotifyOnMouseExit(InteractiveBehaviour behaviour) {
			// TODO
			behaviour.OnCursorExit();
		}

		public void NotifyOnTriggerEnter2D(TriggerBehaviour behaviour) {
			// TODO
			behaviour.OnPlayerCharacterEnter();
		}
		
		public void NotifyOnTriggerExit2D(TriggerBehaviour behaviour) {
			// TODO
			behaviour.OnPlayerCharacterExit();
		}

		public void SetInputMode(InputMode inputMode) {
			this.inputMode = inputMode;
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

				case InputMode.Paused : {
					CheckInputPaused();
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

		private void CheckInputDisabled() {
			// TODO: debug (remove)
			
			if (Input.GetKeyDown(KeyCode.P))
				Game.PauseGame();
			
			if (Input.GetKeyDown(KeyCode.R))
				Game.ResumeGame();
			
			if (Input.GetKeyDown(KeyCode.I))
				Game.ShowInventory();
			
			if (Input.GetKeyDown(KeyCode.C))
				Game.HideInventory();
		}

		private void CheckInputInventory() {
		}

		private void CheckInputPaused() {
			if (Input.GetKeyDown(Parameters.GetCloseMenuKey()))
				Game.CloseMenu();
		}

		private void CheckInputPlaying() {
			if (Input.GetKeyDown(Parameters.GetToggleInventoryKey()))
				Game.ShowInventory();

			if (Input.GetKeyDown(Parameters.GetPauseGameKey()))
				Game.PauseGame();
		}
		
		private void CheckInputUsingInventoryItem() {
		}

	}
	
}
