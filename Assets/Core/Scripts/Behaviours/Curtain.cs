using System.Collections.Generic;
using UnityEngine;

//
// Curtain - Behaviour class
//
// TODO: write class description
//
public class Curtain : MonoBehaviour {

	public Sprite background;
	public List<Sprite> splashScreens;

	public void ShowBackground() {
		SetSprite(background, C.SORTING_LAYER_BACKGROUND);
	}

	public void ShowRandomSplashScreen() {
		int splashScreenCount = splashScreens.Count;

		if (splashScreenCount > 0)
			// There is at least one splash screen
			SetSprite(splashScreens[Random.Range(0, splashScreenCount)], C.SORTING_LAYER_SPLASH_SCREEN);
	}

	private void SetSprite(Sprite sprite, string sortingLayer) {
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = sprite;
		spriteRenderer.sortingLayerName = sortingLayer;
	}
	
}
