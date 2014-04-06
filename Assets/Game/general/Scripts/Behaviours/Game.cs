using UnityEngine;

public class Game : MonoBehaviour {

	private static Game instance;

	public void Awake() {
		Game.instance = this;
		Invoke("InitializeInputManager", P.DELAY_INITIALIZE_INPUT_MANAGER);
	}

	public void OnApplicationQuit() {
		SavegameManager.SaveGame();
	}

	public void Update() {
		//InputManager.CheckInput();
	}

	private void InitializeInputManager() {
		//InputManager.Initialize();
	}

}
