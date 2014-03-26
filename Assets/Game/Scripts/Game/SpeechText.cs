using UnityEngine;

public class SpeechText : MonoBehaviour {

	private Character character;

	public void SetCharacter(Character character) {
		this.character = character;
	}

	public void SetText(string text) {
		guiText.text = text;
	}

	public void Update() {
		// TODO
		transform.position = Utility.ToVector3(Utility.FromWorldToViewportPosition((Vector2) character.transform.position + new Vector2(0, character.GetComponent<BoxCollider2D>().size.y / 2) + P.OFFSET_SPEECH_TEXT), transform.position.z);
	}
	
}
