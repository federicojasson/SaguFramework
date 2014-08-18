using UnityEngine;

public class CharacterManagerWorker : MonoBehaviour {

	public CharacterDictionary CharacterModels;

	public void Awake() {
		CharacterManager.SetWorker(this);
	}
	
}
