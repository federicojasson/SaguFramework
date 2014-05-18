using System.Collections;
using UnityEngine;

public class RoomLoader : MonoBehaviour {

	public BackgroundObject backgroundObject;
	public Menu pauseMenu;

	public void Awake() {
		int spriteCount = backgroundObject.GetSpriteCount();
		if (spriteCount > 1)
			// Shows a random splash screen
			backgroundObject.SetSprite(Random.Range(0, spriteCount - 1));
		else
			// Shows the first sprite
			backgroundObject.SetSprite(0);
		
		// Loads configurations and resources asynchronously
		StartCoroutine(LoadCoroutine());
	}

	private IEnumerator LoadCoroutine() {
		// TODO: load resources
		Debug.Log("TODO: load resources");
		yield return new WaitForSeconds(1); // TODO: debugging

		int spriteCount = backgroundObject.GetSpriteCount();
		if (spriteCount > 1)
			// Shows the last sprite
			backgroundObject.SetSprite(spriteCount - 1);

		yield break;
	}
	
}
