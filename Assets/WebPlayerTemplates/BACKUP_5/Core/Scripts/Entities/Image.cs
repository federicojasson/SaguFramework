﻿using UnityEngine;

namespace SaguFramework {
	
	public class Image : MonoBehaviour {

		public Vector2 GetSize() {
			SpriteRenderer renderer = GetSpriteRenderer();
			
			float width = transform.localScale.x * renderer.sprite.bounds.size.x;
			float height = transform.localScale.y * renderer.sprite.bounds.size.y;

			return new Vector2(width, height);
		}

		public void SetOpacity(float opacity) {
			SpriteRenderer renderer = GetSpriteRenderer();
			renderer.color = Utilities.GetColor(renderer.color, opacity);
		}

		public void SetSize(Vector2 size) {
			SpriteRenderer renderer = GetSpriteRenderer();

			float scaleX = size.x / renderer.sprite.bounds.size.x;
			float scaleY = size.y / renderer.sprite.bounds.size.y;

			transform.localScale = new Vector3(scaleX, scaleY, transform.localScale.z);
		}

		public void SetSortingLayer(string sortingLayer) {
			GetSpriteRenderer().sortingLayerName = sortingLayer;
		}

		public void SetSprite(Sprite sprite) {
			GetSpriteRenderer().sprite = sprite;
		}
		
		private SpriteRenderer GetSpriteRenderer() {
			return GetComponent<SpriteRenderer>();
		}

	}
	
}