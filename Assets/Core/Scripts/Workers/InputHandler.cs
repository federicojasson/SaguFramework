using UnityEngine;

namespace SaguFramework {
	
	public enum InputMode {
		Disabled,
		Inventory,
		Paused,
		Playing,
		UsingItem
	};
	
	public class InputHandler : Worker {

		private static InputHandler instance;
		
		public static InputHandler GetInstance() {
			return instance;
		}

		private InputMode mode;

		public override void Awake() {
			base.Awake();
			instance = this;
			mode = InputMode.Disabled;
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

		public void SetMode(InputMode mode) {
			this.mode = mode;
		}

		public void Update() {
			// TODO

			if (Input.GetKeyDown(KeyCode.P))
				Game.PauseGame();

			if (Input.GetKeyDown(KeyCode.R))
				Game.ResumeGame();

			if (Input.GetKeyDown(KeyCode.I))
				Game.ShowInventory();
			
			if (Input.GetKeyDown(KeyCode.C))
				Game.HideInventory();
		}

	}
	
}
