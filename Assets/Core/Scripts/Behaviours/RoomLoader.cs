using System.Collections;
using UnityEngine;

public class RoomLoader : MonoBehaviour {

	public Curtain curtain;
	public Menu pauseMenu;

	public void Awake() {
		// Shows the background
		curtain.ShowBackground();
		
		// Shows a random splash screen (if there is any)
		curtain.ShowRandomSplashScreen();
		
		// Loads resources asynchronously
		StartCoroutine(LoadCoroutine());
	}

	public void Update() {
		// Checks the input
		InputManager.CheckInput();
	}

	private IEnumerator LoadCoroutine() {
		// Loads the room characters and items
		string room = RoomManager.GetCurrentRoom();
		CharacterManager.LoadRoomCharacters(room);
		ItemManager.LoadRoomItems(room);

		// Initializes the necessary modules
		InputManager.Initialize(pauseMenu);
		GUIManager.Initialize();
		yield return new WaitForSeconds(1); // TODO: debugging

		// Shows the background
		curtain.ShowBackground();

		// Sets the input manager play mode
		InputManager.SetMode(C.INPUT_MANAGER_MODE_PLAY);

		yield break;
	}
	
}
