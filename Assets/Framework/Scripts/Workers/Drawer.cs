using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {

	/// Performs GUI tasks:
	/// - Handles the cursor's visualization.
	/// - Implements fade-in and fade-out effects.
	/// - Draws the tooltip and speech boxes in the screen.
	/// - Facilitates the drawing of the GUI, keeping track of GUILayout areas.
	public sealed class Drawer : Worker {
		
		private static Stack<Rect> areas; // The GUILayout areas
		private static Vector2 cursorPreferredSize; // The cursor's preferred size
		private static Texture2D cursorTexture; // The cursor's texture
		private static float fadeOpacity; // The fade texture's opacity
		private static float fadeSpeed; // The fade speed
		private static Texture2D fadeTexture; // The fade texture
		private static string speech; // The speech being shown
		private static string tooltip; // The tooltip being shown
		
		/// Performs class initialization tasks.
		static Drawer() {
			areas = new Stack<Rect>();

			fadeOpacity = 1f;
			fadeSpeed = 0f;

			speech = string.Empty;
			tooltip = string.Empty;
		}

		/// Registers and begins a GUILayout area.
		/// The new area is defined relatively to the previous one.
		public static void BeginArea(float x, float y, float width, float height) {
			// Gets the previous area
			Rect previousArea = areas.Peek();

			// Defines the new area
			Rect area = new Rect(x * previousArea.width, y * previousArea.height, width * previousArea.width, height * previousArea.height);

			BeginArea(area);
		}

		/// Clears the speech.
		public static void ClearSpeech() {
			speech = string.Empty;
		}

		/// Clears the tooltip.
		public static void ClearTooltip() {
			tooltip = string.Empty;
		}

		/// Calls the entity's behaviour OnShowGui event.
		/// Also, prepares the area where the GUI will be shown (that is, in the game's rectangle).
		public static void DrawEntity(Entity entity) {
			// Sets the game's skin
			GUI.skin = Parameters.GetSkin();

			// Stacks the game's rectangle
			BeginArea(Geometry.GetGameRectangleInGui()); {
				entity.GetBehaviour().OnShowGui();
			} EndArea();
		}

		/// Unregisters and ends a GUILayout area.
		public static void EndArea() {
			GUILayout.EndArea();
			areas.Pop();
		}

		/// Fade-in effect.
		public static IEnumerator FadeIn(FadeParameters fadeParameters) {
			if (fadeParameters.Ignore)
				// Ignores the fade-in
				yield break;

			// Sets the fade speed and texture
			fadeSpeed = - fadeParameters.Speed;
			fadeTexture = fadeParameters.Texture;
			
			while (fadeOpacity > 0f) {
				if (fadeSpeed >= 0f)
					// The speed has been reverted, so the coroutine has to end
					yield break;

				// Waits until the texture's opacity is lower than 0
				yield return null;
			}

			// Stops the fade-in
			fadeSpeed = 0f;
		}

		/// Fade-out effect.
		public static IEnumerator FadeOut(FadeParameters fadeParameters) {
			if (fadeParameters.Ignore)
				// Ignores the fade-out
				yield break;

			// Sets the fade speed and texture
			fadeSpeed = fadeParameters.Speed;
			fadeTexture = fadeParameters.Texture;
			
			while (fadeOpacity < 1f) {
				if (fadeSpeed <= 0f)
					// The speed has been reverted, so the coroutine has to end
					yield break;
				
				// Waits until the texture's opacity is greater than 1
				yield return null;
			}
			
			// Stops the fade-out
			fadeSpeed = 0f;
		}

		/// Returns a skin style with relative font, margin and padding.
		public static GUIStyle GetStyle(string styleId) {
			// Gets the original style
			GUIStyle style = GUI.skin.GetStyle(styleId);

			// Calculates a scale factor based on the game's preferred width and the actual width
			float gamePreferredWidthInPixels = Geometry.GetGamePreferredWidthInPixels();
			float gameWidthInPixels = Geometry.GetGameWidthInPixels();
			float scaleFactor = gameWidthInPixels / gamePreferredWidthInPixels;

			// Initialize a new style
			GUIStyle relativeStyle = new GUIStyle(style);

			// Sets the font size
			relativeStyle.fontSize = (int) (style.fontSize * scaleFactor);

			// Sets the margins
			relativeStyle.margin.left = (int) (style.margin.left * scaleFactor);
			relativeStyle.margin.right = (int) (style.margin.right * scaleFactor);
			relativeStyle.margin.top = (int) (style.margin.top * scaleFactor);
			relativeStyle.margin.bottom = (int) (style.margin.bottom * scaleFactor);

			// Sets the padding
			relativeStyle.padding.left = (int) (style.padding.left * scaleFactor);
			relativeStyle.padding.right = (int) (style.padding.right * scaleFactor);
			relativeStyle.padding.top = (int) (style.padding.top * scaleFactor);
			relativeStyle.padding.bottom = (int) (style.padding.bottom * scaleFactor);
			
			return relativeStyle;
		}

		// Given an order, it sets the cursor's texture.
		public static void SetCursor(Order order) {
			// The cursor's preferred size depends on whether the order is to use an inventory item
			// In the first case, the cursor can be displayed in an special size (usually higher)
			if (order == Order.UseInventoryItem)
				// The order is to use an inventory item
				cursorPreferredSize = Parameters.GetUsedInventoryItemPreferredSize();
			else
				// The order is another one
				cursorPreferredSize = Parameters.GetCursorPreferredSize();

			// Calculates the preferred size in pixels
			cursorPreferredSize = Geometry.GameToWorldSize(cursorPreferredSize);
			cursorPreferredSize.x = Geometry.UnitsToPixels(cursorPreferredSize.x);
			cursorPreferredSize.y = Geometry.UnitsToPixels(cursorPreferredSize.y);

			// Sets the appropriate cursor texture, according to the order
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
					// Gets the selected inventory item
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

		/// Sets the speech's text to display.
		public static void SetSpeech(string speech) {
			Drawer.speech = speech;
		}

		/// Sets the tooltip's text to display.
		public static void SetTooltip(string tooltip) {
			Drawer.tooltip = tooltip;
		}
		
		/// Registers and begins a GUILayout area.
		private static void BeginArea(Rect area) {
			areas.Push(area);
			GUILayout.BeginArea(area);
		}
		
		/// Draws the cursor in the appropriate position.
		/// This is done only if the cursor's texture is set.
		/// Also, this method hides the real system cursor.
		private static void DrawCursor() {
			Screen.showCursor = false;

			if (cursorTexture != null) {
				// The texture has been set

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

		/// Draws the fade texture.
		/// Also, updates the fade opacity according to the current speed.
		private static void DrawFade() {
			if (Event.current.type == EventType.Repaint) {
				// Exactly one repaint event is sent every frame
				// This is important to respect the fade speed

				if (fadeTexture == null)
					// If the fade texture is not set, it uses the default one
					fadeTexture = Parameters.GetDefaultFadeTexture();
				
				fadeOpacity += fadeSpeed * Time.deltaTime;
				float clampedFadeOpacity = Mathf.Clamp01(fadeOpacity);
				
				Rect gameRectangle = Geometry.GetGameRectangleInGui();
				
				GUI.color = Utilities.GetColor(GUI.color, clampedFadeOpacity);
				GUI.DrawTexture(gameRectangle, fadeTexture);
			}
		}

		/// Draws the speech box.
		/// Only shows the box if the speech's text is not empty.
		private static void DrawSpeech() {
			if (speech.Length > 0) {
				// The speech's text is not empty

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

		/// Draws the tooltip box.
		/// Only shows the box if the tooltip's text is not empty.
		private static void DrawTooltip() {
			if (tooltip.Length > 0) {
				// The tooltip's text is not empty

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

		/// Draws the windowbox.
		/// The windowbox prevents the game from being visualized outside the game's rectangle when the screen
		/// resolution is higher than expected.
		private static void DrawWindowbox() {
			Texture2D windowboxTexture = Parameters.GetWindowboxTexture();
			Rect[] windowboxRectangles = Geometry.GetWindowboxRectanglesInGui();
			
			GUI.color = Utilities.GetColor(GUI.color, 1f);
			foreach (Rect windowboxingRectangle in windowboxRectangles)
				GUI.DrawTexture(windowboxingRectangle, windowboxTexture);
		}
		
		public void OnGUI() {
			// Sets the game's skin
			GUI.skin = Parameters.GetSkin();

			DrawCursor();
			DrawSpeech();
			DrawTooltip();
			DrawFade();
			DrawWindowbox();
		}

	}
	
}
