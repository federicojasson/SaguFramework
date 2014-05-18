using System.Collections.Generic;
using UnityEngine;

public class BackgroundObject : MonoBehaviour {
	
	public List<Sprite> sprites; // It must have at least one sprite
	private int index;

	public int GetSpriteCount() {
		return sprites.Count;
	}

	public void SetNextSprite() {
		index = (index + 1) % sprites.Count;
		GetComponent<SpriteRenderer>().sprite = sprites[index];
	}

	public void SetPreviousSprite() {
		index = (index - 1 + sprites.Count) % sprites.Count;
		GetComponent<SpriteRenderer>().sprite = sprites[index];
	}

	public void SetSprite(int index) {
		this.index = index;
		GetComponent<SpriteRenderer>().sprite = sprites[index];
	}
	
}
