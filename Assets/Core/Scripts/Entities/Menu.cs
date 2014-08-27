using SaguFramework.Behaviours;
using SaguFramework.Managers;
using UnityEngine;

namespace SaguFramework.Entities {
	
	public class Menu : MonoBehaviour {

		private MenuBehaviour behaviour;

		public virtual void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterMenu(this);
		}

		public void Close() {
			// Destroys the object
			Destroy(gameObject);
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
			behaviour.OnShow();
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
