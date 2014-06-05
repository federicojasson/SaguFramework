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
		float beginTime = Time.time;

		// Creates the room characters and items
		string currentRoom = RoomManager.GetCurrentRoom();
		CharacterManager.CreateRoomCharacters(currentRoom);
		ItemManager.CreateRoomItems(currentRoom);

		// Sets the pause menu
		GameManager.SetPauseMenu(pauseMenu);

		float endTime = Time.time;
		float loadTime = endTime - beginTime;
		float minimumLoadTime = 0.1f; // TODO: set somehow else
		
		if (loadTime < minimumLoadTime)
			yield return new WaitForSeconds(minimumLoadTime - loadTime);

		// Shows the background
		curtain.ShowBackground();

		// TODO: block somehow until fade out completed?

		// Sets the input manager play mode
		InputManager.SetMode(C.INPUT_MANAGER_MODE_PLAY);

		yield break;
	}
	
}
