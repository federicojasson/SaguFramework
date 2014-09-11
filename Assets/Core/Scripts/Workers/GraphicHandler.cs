﻿using System.Collections;
using UnityEngine;

namespace SaguFramework {
	
	public class GraphicHandler : Worker {

		private static float fadeSpeed;
		private static Texture2D fadeTexture;
		private static float fadeTextureOpacity;
		private static string tooltip;

		static GraphicHandler() {
			fadeSpeed = 0;
			fadeTextureOpacity = 1f;
			tooltip = "";
		}

		public static void ClearTooltip() {
			tooltip = "";
		}

		public static IEnumerator FadeIn(FadeParameters fadeParameters) {
			if (fadeParameters.Ignore)
				yield break;
			
			fadeTexture = fadeParameters.Texture;
			fadeSpeed = - fadeParameters.Speed;
			
			while (fadeTextureOpacity > 0)
				if (fadeSpeed >= 0)
					yield break;
				else
					yield return null;
			
			fadeSpeed = 0f;
		}

		public static IEnumerator FadeOut(FadeParameters fadeParameters) {
			if (fadeParameters.Ignore)
				yield break;

			fadeTexture = fadeParameters.Texture;
			fadeSpeed = fadeParameters.Speed;
			
			while (fadeTextureOpacity < 1)
				if (fadeSpeed <= 0)
					yield break;
				else
					yield return null;
			
			fadeSpeed = 0f;
		}

		public static bool IsCursorInGame() {
			return Geometry.GetGameRectangleInScreen().Contains(Input.mousePosition);
		}

		public static void SetTooltip(string tooltip) {
			GraphicHandler.tooltip = tooltip;
		}
		
		private static void Fade() {
			if (fadeTexture == null)
				fadeTexture = Parameters.GetDefaultFadeTexture();
			
			fadeTextureOpacity += fadeSpeed * Time.deltaTime;
			float clampedFadeTextureOpacity = Mathf.Clamp01(fadeTextureOpacity);
			
			Rect gameRectangle = Geometry.GetGameRectangleInGui();
			
			GUI.color = Utilities.GetColor(GUI.color, clampedFadeTextureOpacity);
			GUI.DrawTexture(gameRectangle, fadeTexture);
		}
		
		private static void Tooltip() {
			if (tooltip.Length > 0) {
				GUIContent content = new GUIContent(tooltip);
				GUIStyle style = GUI.skin.GetStyle(Parameters.SkinStyleTooltip);
				
				RectOffset margin = style.margin;
				Rect area = Geometry.GetGameRectangleInGui();
				area.width -= margin.left + margin.right;
				area.height -= margin.bottom + margin.top;
				area.y += margin.top;
				
				float screenWidthInPixels = Geometry.GetScreenWidthInPixels();
				float minimumWidth;
				float maximumWidth;
				style.CalcMinMaxWidth(content, out minimumWidth, out maximumWidth);
				
				area.width = Mathf.Min(area.width, maximumWidth);
				area.x = 0.5f * (screenWidthInPixels - area.width);
				
				GUILayout.BeginArea(area); {
					GUILayout.BeginVertical(); {
						GUILayout.FlexibleSpace();
						GUILayout.Box(content, style);
					}
					GUILayout.EndVertical();
				}
				GUILayout.EndArea();
			}
		}
		
		private static void Windowbox() {
			Texture2D windowboxTexture = Parameters.GetWindowboxTexture();
			Rect[] windowboxRectangles = Geometry.GetWindowboxRectanglesInGui();
			
			GUI.color = Utilities.GetColor(GUI.color, 1f);
			foreach (Rect windowboxingRectangle in windowboxRectangles)
				GUI.DrawTexture(windowboxingRectangle, windowboxTexture);
		}

		public void OnGUI() {
			GUI.skin = Parameters.GetSkin();
			
			Tooltip();
			if (Event.current.type == EventType.Repaint) {
				// Exactly one repaint event is sent every frame
				Fade();
				Windowbox();
			}
		}

		public override void OnOrderChange() {
			// TODO: cambiar cursor de acuerdo a la orden

			Order order = OrderHandler.GetOrder();
			
			Screen.showCursor = false;

			// TODO
			switch (OrderHandler.GetOrder()) {
				case Order.Click : {
					break;
				}

				case Order.Look : {
					break;
				}

				case Order.None : {
					return;
				}

				case Order.PickUp : {
					break;
				}

				case Order.Speak : {
					break;
				}

				case Order.UseInventoryItem : {
					// TODO: setear el sprite del item del inventario
					break;
				}

				case Order.Walk : {
					break;
				}
			}

			// TODO: set the sprite

			Screen.showCursor = true;
		}

	}
	
}
