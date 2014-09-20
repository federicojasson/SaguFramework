using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {
	
	public sealed class Drawer : Worker {
		
		private static Stack<Rect> areas;
		private static Vector2 cursorPreferredSize;
		private static Texture2D cursorTexture;
		private static float fadeOpacity;
		private static float fadeSpeed;
		private static Texture2D fadeTexture;
		private static string speech;
		private static string tooltip;

		static Drawer() {
			areas = new Stack<Rect>();
			fadeOpacity = 1f;
			fadeSpeed = 0f;
			speech = string.Empty;
			tooltip = string.Empty;
		}
		
		public static void BeginArea(float x, float y, float width, float height) {
			Rect previousArea;
			if (areas.Count == 0)
				previousArea = Geometry.GetGameRectangleInGui();
			else
				previousArea = areas.Peek();

			Rect area = new Rect(x * previousArea.width, y * previousArea.height, width * previousArea.width, height * previousArea.height);
			areas.Push(area);
			GUILayout.BeginArea(area);
		}

		public static void ClearSpeech() {
			speech = string.Empty;
		}

		public static void ClearTooltip() {
			tooltip = string.Empty;
		}
		
		public static void DrawEntity(Entity entity) {
			GUI.skin = Parameters.GetSkin();

			BeginArea(0f, 0f, 1f, 1f); {
				entity.GetBehaviour().OnShowGui();
			} EndArea();
		}
		
		public static void EndArea() {
			areas.Pop();
			GUILayout.EndArea();
		}

		public static IEnumerator FadeIn(FadeParameters fadeParameters) {
			if (fadeParameters.Ignore)
				yield break;
			
			fadeSpeed = - fadeParameters.Speed;
			fadeTexture = fadeParameters.Texture;
			
			while (fadeOpacity > 0f) {
				if (fadeSpeed >= 0f)
					yield break;

				yield return null;
			}
			
			fadeSpeed = 0f;
		}
		
		public static IEnumerator FadeOut(FadeParameters fadeParameters) {
			if (fadeParameters.Ignore)
				yield break;
			
			fadeSpeed = fadeParameters.Speed;
			fadeTexture = fadeParameters.Texture;
			
			while (fadeOpacity < 1f) {
				if (fadeSpeed <= 0f)
					yield break;
				
				yield return null;
			}
			
			fadeSpeed = 0f;
		}
		
		public static GUIStyle GetStyle(string styleId) {
			GUIStyle style = GUI.skin.GetStyle(styleId);
			
			float gamePreferredWidthInPixels = Geometry.GetGamePreferredWidthInPixels();
			float gameWidthInPixels = Geometry.GetGameWidthInPixels();
			float scaleFactor = gameWidthInPixels / gamePreferredWidthInPixels;
			
			GUIStyle relativeStyle = new GUIStyle(style);
			
			relativeStyle.fontSize = (int) (style.fontSize * scaleFactor);
			
			relativeStyle.margin.left = (int) (style.margin.left * scaleFactor);
			relativeStyle.margin.right = (int) (style.margin.right * scaleFactor);
			relativeStyle.margin.top = (int) (style.margin.top * scaleFactor);
			relativeStyle.margin.bottom = (int) (style.margin.bottom * scaleFactor);
			
			relativeStyle.padding.left = (int) (style.padding.left * scaleFactor);
			relativeStyle.padding.right = (int) (style.padding.right * scaleFactor);
			relativeStyle.padding.top = (int) (style.padding.top * scaleFactor);
			relativeStyle.padding.bottom = (int) (style.padding.bottom * scaleFactor);
			
			return relativeStyle;
		}

		public static void SetCursor(Order order) {
			if (order == Order.UseInventoryItem)
				cursorPreferredSize = Parameters.GetUsedInventoryItemPreferredSize();
			else
				cursorPreferredSize = Parameters.GetCursorPreferredSize();

			cursorPreferredSize = Geometry.GameToWorldSize(cursorPreferredSize);
			cursorPreferredSize.x = Geometry.UnitsToPixels(cursorPreferredSize.x);
			cursorPreferredSize.y = Geometry.UnitsToPixels(cursorPreferredSize.y);

			switch (order) {
				case Order.Click : {
					cursorTexture = Parameters.GetClickTexture();
					return;
				}
					
				case Order.Look : {
					cursorTexture = Parameters.GetLookTexture();
					return;
				}
					
				case Order.None : {
					cursorTexture = null;
					return;
				}
					
				case Order.PickUp : {
					cursorTexture = Parameters.GetPickUpTexture();
					return;
				}
					
				case Order.Speak : {
					cursorTexture = Parameters.GetSpeakTexture();
					return;
				}
					
				case Order.UseInventoryItem : {
					InventoryItem inventoryItem = InputReader.GetSelectedInventoryItem();
					cursorTexture = inventoryItem.GetImage().GetTexture();
					return;
				}
					
				case Order.Walk : {
					cursorTexture = Parameters.GetWalkTexture();
					return;
				}
			}
		}
		
		public static void SetSpeech(string speech) {
			Drawer.speech = speech;
		}

		public static void SetTooltip(string tooltip) {
			Drawer.tooltip = tooltip;
		}

		private static void DrawCursor() {
			Screen.showCursor = false;

			if (cursorTexture != null) {
				Vector2 textureSize = new Vector2(cursorTexture.width, cursorTexture.height);
				Vector2 cursorSize = Utilities.GetSize(textureSize, cursorPreferredSize);
				Vector2 cursorPosition = Event.current.mousePosition;
				
				float width = cursorSize.x;
				float height = cursorSize.y;
				float x = cursorPosition.x - 0.5f * width;
				float y = cursorPosition.y - 0.5f * height;
				Rect cursorRectangle = new Rect(x, y, width, height);
				
				GUI.color = Utilities.GetColor(GUI.color, 1f);
				GUI.DrawTexture(cursorRectangle, cursorTexture);
			}
		}
		
		private static void DrawFade() {
			if (Event.current.type == EventType.Repaint) {
				// Exactly one repaint event is sent every frame
				if (fadeTexture == null)
					fadeTexture = Parameters.GetDefaultFadeTexture();
				
				fadeOpacity += fadeSpeed * Time.deltaTime;
				float clampedFadeOpacity = Mathf.Clamp01(fadeOpacity);
				
				Rect gameRectangle = Geometry.GetGameRectangleInGui();
				
				GUI.color = Utilities.GetColor(GUI.color, clampedFadeOpacity);
				GUI.DrawTexture(gameRectangle, fadeTexture);
			}
		}
		
		private static void DrawSpeech() {
			if (speech.Length > 0) {
				GUIStyle speechTextStyle = GetStyle(Parameters.StyleSpeech);
				GUIContent content = new GUIContent(speech);
				
				RectOffset margin = speechTextStyle.margin;
				Rect area = Geometry.GetGameRectangleInGui();
				area.width -= margin.left + margin.right;
				area.height -= margin.bottom + margin.top;
				area.y += margin.top;
				
				float screenWidthInPixels = Geometry.GetScreenWidthInPixels();
				float minimumWidth;
				float maximumWidth;
				speechTextStyle.CalcMinMaxWidth(content, out minimumWidth, out maximumWidth);
				
				area.width = Mathf.Min(area.width, maximumWidth);
				area.x = 0.5f * (screenWidthInPixels - area.width);
				
				GUILayout.BeginArea(area); {
					GUILayout.Box(content, speechTextStyle);
					GUILayout.FlexibleSpace();
				} GUILayout.EndArea();
			}
		}
		
		private static void DrawTooltip() {
			if (tooltip.Length > 0) {
				GUIStyle tooltipStyle = GetStyle(Parameters.StyleTooltip);
				GUIContent content = new GUIContent(tooltip);
				
				RectOffset margin = tooltipStyle.margin;
				Rect area = Geometry.GetGameRectangleInGui();
				area.width -= margin.left + margin.right;
				area.height -= margin.bottom + margin.top;
				area.y += margin.top;
				
				float screenWidthInPixels = Geometry.GetScreenWidthInPixels();
				float minimumWidth;
				float maximumWidth;
				tooltipStyle.CalcMinMaxWidth(content, out minimumWidth, out maximumWidth);
				
				area.width = Mathf.Min(area.width, maximumWidth);
				area.x = 0.5f * (screenWidthInPixels - area.width);
				
				GUILayout.BeginArea(area); {
					GUILayout.FlexibleSpace();
					GUILayout.Box(content, tooltipStyle);
				} GUILayout.EndArea();
			}
		}
		
		private static void DrawWindowbox() {
			Texture2D windowboxTexture = Parameters.GetWindowboxTexture();
			Rect[] windowboxRectangles = Geometry.GetWindowboxRectanglesInGui();
			
			GUI.color = Utilities.GetColor(GUI.color, 1f);
			foreach (Rect windowboxingRectangle in windowboxRectangles)
				GUI.DrawTexture(windowboxingRectangle, windowboxTexture);
		}
		
		public void OnGUI() {
			GUI.skin = Parameters.GetSkin();
			
			DrawCursor();
			DrawSpeech();
			DrawTooltip();
			DrawFade();
			DrawWindowbox();
		}

	}
	
}
