/*using System.Collections;
using UnityEngine;

namespace SaguFramework {
	
	public class ScreenHandler : Worker {
		
		private static ScreenHandler instance;
		
		public static ScreenHandler GetInstance() {
			return instance;
		}

		private float fadeSpeed;
		private Texture2D fadeTexture;
		private float fadeTextureOpacity;
		private string tooltip;

		public override void Awake() {
			base.Awake();
			instance = this;
			fadeSpeed = 0;
			fadeTextureOpacity = 1;
			tooltip = "";
		}

		public void ClearTooltip() {
			tooltip = "";
		}

		public float GetFadeSpeed() {
			return fadeSpeed;
		}

		public float GetFadeTextureOpacity() {
			return fadeTextureOpacity;
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

		public void SetFadeSpeed(float speed) {
			fadeSpeed = speed;
		}

		public void SetFadeTexture(Texture2D texture) {
			fadeTexture = texture;
		}

		public void SetTooltip(string tooltip) {
			this.tooltip = tooltip;
		}

		private void Fade() {
			if (fadeTexture == null)
				fadeTexture = Parameters.GetFadeTexture();

			fadeTextureOpacity += fadeSpeed * Time.deltaTime;
			float clampedFadeTextureOpacity = Mathf.Clamp01(fadeTextureOpacity);

			Rect gameRectangle = Geometry.GetGameRectangleInGui();

			GUI.color = Utilities.GetColor(GUI.color, clampedFadeTextureOpacity);
			GUI.DrawTexture(gameRectangle, fadeTexture);
		}

		private void Tooltip() {
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

		private void Windowbox() {
			Texture2D windowboxTexture = Parameters.GetWindowboxTexture();
			Rect[] windowboxRectangles = Geometry.GetWindowboxRectanglesInGui();

			GUI.color = Utilities.GetColor(GUI.color, 1);
			foreach (Rect windowboxingRectangle in windowboxRectangles)
				GUI.DrawTexture(windowboxingRectangle, windowboxTexture);
		}

	}
	
}*/
