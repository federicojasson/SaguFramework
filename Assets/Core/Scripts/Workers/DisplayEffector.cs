using UnityEngine;

public partial class DisplayEffector : MonoBehaviour {

	private float fadeSpeed;
	private SpriteRenderer spriteRenderer;

	public void Awake() {
		fadeSpeed = 0;
		instance = this;
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = UtilityManager.GetColor(spriteRenderer.color, 1);
	}

	public void Update() {
		// Calculates the opacity
		float opacity = spriteRenderer.color.a + fadeSpeed * Time.deltaTime;
		float clampedOpacity = Mathf.Clamp01(opacity);

		// Changes the sprite renderer opacity
		spriteRenderer.color = UtilityManager.GetColor(spriteRenderer.color, clampedOpacity);
	}
	
}
