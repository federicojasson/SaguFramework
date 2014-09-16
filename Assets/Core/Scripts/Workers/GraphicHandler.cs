using System.Collections;
using UnityEngine;

namespace SaguFramework {
	
	public class GraphicHandler : Worker {

		private static Texture2D cursorTexture;
		private static float fadeSpeed;
		private static Texture2D fadeTexture;
		private static float fadeTextureOpacity;
		private static string speechText;
		private static string tooltip;

		static GraphicHandler() {
			fadeSpeed = 0;
			fadeTextureOpacity = 1f;
			speechText = string.Empty;
			tooltip = string.Empty;
		}
		
		public static void ClearSpeechText() {
			speechText = string.Empty;
		}

		public static void ClearTooltip() {
			tooltip = string.Empty;
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
			return Geometry.GetGameRectangleInScreen().Contains(InputHandler.GetMousePositionInScreen());
		}

		public static void SetSpeechText(string speechText) {
			GraphicHandler.speechText = speechText;
		}

		public static void SetTooltip(string tooltip) {
			GraphicHandler.tooltip = tooltip;
		}

		private static void Cursor() {
			Screen.showCursor = false;

			if (cursorTexture != null) {
				Vector2 textureSize = new Vector2(cursorTexture.width, cursorTexture.height);
				Vector2 preferredCursorSize = Geometry.GameToWorldSize(Parameters.GetCursorPreferredSize());
				preferredCursorSize.x = Geometry.UnitsToPixels(preferredCursorSize.x);
				preferredCursorSize.y = Geometry.UnitsToPixels(preferredCursorSize.y);

				Vector2 cursorSize = Utilities.GetSize(textureSize, preferredCursorSize);
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
		
		private static void Fade() {
			if (Event.current.type == EventType.Repaint) {
				// Exactly one repaint event is sent every frame
				if (fadeTexture == null)
					fadeTexture = Parameters.GetDefaultFadeTexture();
				
				fadeTextureOpacity += fadeSpeed * Time.deltaTime;
				float clampedFadeTextureOpacity = Mathf.Clamp01(fadeTextureOpacity);
				
				Rect gameRectangle = Geometry.GetGameRectangleInGui();
				
				GUI.color = Utilities.GetColor(GUI.color, clampedFadeTextureOpacity);
				GUI.DrawTexture(gameRectangle, fadeTexture);
			}
		}

		private static void SetCursor(Order order) {
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
					InventoryItem inventoryItem = OrderHandler.GetSelectedInventoryItem();
					cursorTexture = inventoryItem.GetImage().GetTexture();
					return;
				}
					
				case Order.Walk : {
					cursorTexture = Parameters.GetWalkTexture();
					return;
				}
			}
		}

		private static void SpeechText() {
			if (speechText.Length > 0) {
				GUIStyle speechTextStyle = GUI.skin.GetStyle(Parameters.SkinStyleSpeechText);
				GUIStyle modifiedSpeechTextStyle = Utilities.GetRelativeStyle(speechTextStyle);
				GUIContent content = new GUIContent(speechText);
				
				RectOffset margin = modifiedSpeechTextStyle.margin;
				Rect area = Geometry.GetGameRectangleInGui();
				area.width -= margin.left + margin.right;
				area.height -= margin.bottom + margin.top;
				area.y += margin.top;
				
				float screenWidthInPixels = Geometry.GetScreenWidthInPixels();
				float minimumWidth;
				float maximumWidth;
				modifiedSpeechTextStyle.CalcMinMaxWidth(content, out minimumWidth, out maximumWidth);
				
				area.width = Mathf.Min(area.width, maximumWidth);
				area.x = 0.5f * (screenWidthInPixels - area.width);
				
				GUILayout.BeginArea(area); {
					GUILayout.Box(content, modifiedSpeechTextStyle);
					GUILayout.FlexibleSpace();
				} GUILayout.EndArea();
			}
		}
		
		private static void Tooltip() {
			if (tooltip.Length > 0) {
				GUIStyle tooltipStyle = GUI.skin.GetStyle(Parameters.SkinStyleTooltip);
				GUIStyle modifiedTooltipStyle = Utilities.GetRelativeStyle(tooltipStyle);
				GUIContent content = new GUIContent(tooltip);
				
				RectOffset margin = modifiedTooltipStyle.margin;
				Rect area = Geometry.GetGameRectangleInGui();
				area.width -= margin.left + margin.right;
				area.height -= margin.bottom + margin.top;
				area.y += margin.top;
				
				float screenWidthInPixels = Geometry.GetScreenWidthInPixels();
				float minimumWidth;
				float maximumWidth;
				modifiedTooltipStyle.CalcMinMaxWidth(content, out minimumWidth, out maximumWidth);
				
				area.width = Mathf.Min(area.width, maximumWidth);
				area.x = 0.5f * (screenWidthInPixels - area.width);
				
				GUILayout.BeginArea(area); {
					GUILayout.FlexibleSpace();
					GUILayout.Box(content, modifiedTooltipStyle);
				} GUILayout.EndArea();
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
			
			Cursor();
			SpeechText();
			Tooltip();
			Fade();
			Windowbox();
		}
		
		public override void OnGameModeChange() {
			ClearSpeechText();
			ClearTooltip();
		}

		public override void OnOrderChange() {
			SetCursor(OrderHandler.GetOrder());
		}

	}
	
}
