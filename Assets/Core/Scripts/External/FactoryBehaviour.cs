using UnityEngine;

public class FactoryBehaviour : MonoBehaviour {

	public CharacterDictionary CharacterModels;
	public Texture2D FadeTexture;
	public ItemDictionary ItemModels;

	public void Awake() {
		Factory.SetBehaviour(this);

		CharacterModels.Initialize();
		ItemModels.Initialize();
	}
	
}
