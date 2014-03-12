using UnityEngine;

public class Game : MonoBehaviour {

	public static Game instance;
	public PlayerCharacter playerCharacter;

	public void Awake() {
		instance = this;
	}

	public void Update() {
		InputManager.CheckInput();
	}

}
