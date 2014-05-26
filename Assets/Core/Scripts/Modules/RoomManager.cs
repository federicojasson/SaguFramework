using UnityEngine;

//
// RoomManager - Module class
//
// TODO: write class description
//
public static class RoomManager {

	public static string GetCurrentRoom() {
		// The current room is the level name
		return Application.loadedLevelName;
	}

	public static void LoadRoom(string room) {
		// Disables the input manager
		InputManager.SetMode(C.INPUT_MANAGER_MODE_DISABLED);

		// Hides all menus and dialogs
		GUIManager.HideAll();

		// Loads the room (homonym scene)
		Application.LoadLevel(room);
	}
	
}
