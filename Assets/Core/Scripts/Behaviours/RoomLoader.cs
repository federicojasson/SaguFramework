using System.Collections;
using UnityEngine;

public class RoomLoader : MonoBehaviour {

	public BackgroundObject backgroundObject;
	public Menu pauseMenu;

	public void Awake() {
		int spriteCount = backgroundObject.GetSpriteCount();
		if (spriteCount > 1)
			// Shows a random sprite (room splash screen)
			backgroundObject.SetSprite(Random.Range(0, spriteCount - 1));
		else
			// Shows the first sprite (room background)
			backgroundObject.SetSprite(0);
		
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
		GUIManager.Initialize();
		InputManager.Initialize(pauseMenu);
		yield return new WaitForSeconds(1); // TODO: debugging

		int spriteCount = backgroundObject.GetSpriteCount();
		if (spriteCount > 1)
			// Shows the last sprite (room background)
			backgroundObject.SetSprite(spriteCount - 1);

		yield break;
	}
	
}
