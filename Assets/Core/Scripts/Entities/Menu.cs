using UnityEngine;

namespace SaguFramework {
	
	public class Menu : MonoBehaviour {

		private MenuBehaviour behaviour;

		public virtual void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterMenu(this);

			// Hides the menu initially
			Hide();
		}

		public virtual void Close() {
			// Destroys the object
			DestroyImmediate(gameObject);
		}

		public void Hide() {
			// Deactivates the object in order to make the menu invisible
			gameObject.SetActive(false);
		}
		
		public virtual void OnDestroy() {
			// Unregisters itself from the ObjectManager
			ObjectManager.UnregisterMenu();
		}

		public void OnEnable() {
			// Moves the menu in front of the camera
			GameCamera.GetInstance().MoveInFront(transform);
		}

		public void OnGUI() {
			// Begins an area that covers the game rectangle
			GUILayout.BeginArea(UtilityManager.GetGameRectangleInGui());

			behaviour.OnShowing();

			GUILayout.EndArea();
		}

		public void SetBehaviour(MenuBehaviour behaviour) {
			this.behaviour = behaviour;
		}
		
		public void Show() {
			// Activates the object in order to make the menu visible
			gameObject.SetActive(true);
		}

	}
	
}
