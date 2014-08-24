﻿using UnityEngine;

public partial class Fader : MonoBehaviour {
	
	private GameImage fadeImage;
	private float fadeSpeed;

	public void Awake() {
		fadeImage = GetComponentInChildren<GameImage>();
		fadeSpeed = 0;
		instance = this;

		fadeImage.SetOpacity(1);
		fadeImage.SetRelativeSize(1);
		fadeImage.SetSortingLayer(Parameters.FadeImageSortingLayer);
	}

	public void Update() {
		// Calculates the opacity
		float opacity = fadeImage.GetOpacity() + fadeSpeed * Time.deltaTime;
		float clampedOpacity = Mathf.Clamp01(opacity);

		// Changes the image opacity
		fadeImage.SetOpacity(clampedOpacity);
	}
	
}
