using UnityEngine;

namespace SaguFramework {
	
	public class Menu : MonoBehaviour {

		private MenuBehaviour behaviour;

		public virtual void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterMenu(this);

			// Sets itself as the game camera's active target
			GameCamera.GetInstance().SetTarget(transform, true);
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

		public void OnGUI() {
			behaviour.OnShowing();
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
