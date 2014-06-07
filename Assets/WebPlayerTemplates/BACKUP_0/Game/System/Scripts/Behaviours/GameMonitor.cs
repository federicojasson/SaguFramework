using UnityEngine;

public class GameMonitor : MonoBehaviour {
	
	public void OnApplicationQuit() {
		SavegameManager.SaveGame();
	}

	public void Update() {
		InputManager.CheckInput();
	}

}
