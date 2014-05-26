using System.Collections;
using UnityEngine;

//
// RoomLoader - Behaviour class
//
// TODO: write class description
//
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
		InputManager.CheckInput();
	}

	private IEnumerator LoadCoroutine() {
		// Creates the room characters and items
		string currentRoom = RoomManager.GetCurrentRoom();
		CharacterManager.CreateRoomCharacters(currentRoom);
		ItemManager.CreateRoomItems(currentRoom);

		// Sets the pause menu
		GameManager.SetPauseMenu(pauseMenu);

		yield return new WaitForSeconds(1); // TODO: debugging

		// Shows the background
		curtain.ShowBackground();

		// Sets the input manager play mode
		InputManager.SetMode(C.INPUT_MANAGER_MODE_PLAY);

		yield break;
	}
	
}
