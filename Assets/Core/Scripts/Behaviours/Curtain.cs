using System.Collections.Generic;
using UnityEngine;

public class Curtain : MonoBehaviour {

	public Sprite background;
	public List<Sprite> splashScreens;

	public void ShowBackground() {
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = background;
		spriteRenderer.sortingLayerName = C.SORTING_LAYER_BACKGROUND;
	}

	public void ShowRandomSplashScreen() {
		int splashScreenCount = splashScreens.Count;

		if (splashScreenCount > 0) {
			// There is at least one splash screen
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = splashScreens[Random.Range(0, splashScreenCount)];
			spriteRenderer.sortingLayerName = C.SORTING_LAYER_SPLASH_SCREEN;
		}
	}
	
}
