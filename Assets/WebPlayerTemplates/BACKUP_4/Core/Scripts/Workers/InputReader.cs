using UnityEngine;

namespace SaguFramework {
	
	public class InputReader : MonoBehaviour {

		private bool inventory = false; // TODO: remove

		public void Update() {
			// TODO: just to debug

			if (Input.GetKeyDown(KeyCode.P))
				GameManager.OpenMenu("PauseMenu");

			if (Input.GetKeyDown(KeyCode.M))
				GameManager.OpenMainMenu();

			if (Input.GetKeyDown(KeyCode.E)) {
				GameManager.AddToInventory("InventoryErlenmeyer0");
				GameManager.AddToInventory("InventoryErlenmeyer1");
				GameManager.AddToInventory("InventoryErlenmeyer2");
				GameManager.AddToInventory("InventoryErlenmeyer3");
				GameManager.AddToInventory("InventoryErlenmeyer4");
				GameManager.AddToInventory("InventoryErlenmeyer5");
				GameManager.AddToInventory("InventoryErlenmeyer6");
				GameManager.AddToInventory("InventoryErlenmeyer7");
				GameManager.AddToInventory("InventoryErlenmeyer8");
				//GameManager.AddToInventory("InventoryErlenmeyer9");

				StateManager.SetInventoryPage(0);
			}

			if (Input.GetKeyDown(KeyCode.H))
				if (StateManager.HintExists("prueba"))
					Debug.Log("Hint exists!");

			if (Input.GetKeyDown(KeyCode.I)) {
				if (inventory)
					GameManager.HideInventory();
				else
					GameManager.ShowInventory();

				inventory = ! inventory;
			}
		}
		
	}
	
}
