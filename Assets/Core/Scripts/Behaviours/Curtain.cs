using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Curtain - Behaviour class
//
// TODO: write class description
//
public class Curtain : MonoBehaviour {

	public Sprite background;
	public float fadeInSpeed;
	public float fadeOutSpeed;
	public Texture2D fadeTexture;
	public List<Sprite> splashScreens;
	private float alpha;
	private bool fadeIn;
	private bool fadeOut;

	public void Awake() {
		alpha = 1;
		fadeIn = false;
		fadeOut = false;
	}

	public void OnGUI() {
		if (fadeIn || fadeOut) {
			if (fadeIn)
				alpha -= fadeInSpeed * Time.deltaTime;
			else
				alpha += fadeOutSpeed * Time.deltaTime;

			alpha = Mathf.Clamp01(alpha);
			
			// TODO: use GUIManager?
			Color color = GUI.color;
			color.a = alpha;
			GUI.color = color;
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
		}
	}

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
		// Stops the currently executing coroutine (if there's any)
		StopAllCoroutines();

		fadeIn = false;
		fadeOut = false;

		object[] parameters = new object[] { sprite, sortingLayer };
		StartCoroutine("SetSpriteCoroutine", parameters);
	}
	
	private IEnumerator SetSpriteCoroutine(object[] parameters) {
		Sprite sprite = (Sprite) parameters[0];
		string sortingLayer = (string) parameters[1];

		// Fade out
		fadeOut = true;
		while (alpha < 1)
			yield return null;
		fadeOut = false;

		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = sprite;
		spriteRenderer.sortingLayerName = sortingLayer;

		// Fade in
		fadeIn = true;
		while (alpha > 0)
			yield return null;
		fadeIn = false;
	}

}
