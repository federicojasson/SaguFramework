using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoader : MonoBehaviour {
	
	public void Awake() {
		// TODO: show loading splash
		Debug.Log("Show loading splash");

		StartCoroutine(LoadCoroutine());
	}

	private void InitializeInputManager() {
		InputManager.Initialize();
	}

	private IEnumerator LoadCoroutine() {
		string roomId = RoomManager.GetCurrentRoomId();

		// Creates the characters
		List<Character> characters = CharacterManager.GetCharacters(roomId);
		foreach (Character character in characters)
			Factory.CreateCharacter(character);
		
		// Creates the room items
		List<RoomItem> roomItems = ItemManager.GetRoomItems(roomId);
		foreach (RoomItem roomItem in roomItems)
			Factory.CreateRoomItem(roomItem);

		// TODO: quitar splash
		Debug.Log("Hide loading splash");
		
		// Initializes the input manager
		Invoke("InitializeInputManager", P.DELAY_INITIALIZE_INPUT_MANAGER);

		yield break;
	}
	
}
