using UnityEngine;

namespace SaguFramework {
	
	public class TextHandler : Worker {
		
		private static TextHandler instance;
		
		public static TextHandler GetInstance() {
			return instance;
		}

		private string text;
		
		public override void Awake() {
			base.Awake();
			instance = this;

			// TODO: remove this
			text = "esto es una prueba texto muy muy muy largo 0123456789 0123456789 0123456789 0123456789 0123456789 0123456789 0123456789 0123456789 0123456789 0123456789 0123456789 0123456789 0123456789";
		}

		public void OnGUI() {
			GUI.skin = Parameters.GetSkin();

			// TODO
			GUIStyle style = new GUIStyle(GUI.skin.box);
			GUIContent content = new GUIContent(text);
			Rect rectangle = GUILayoutUtility.GetRect(content, style);

			rectangle.x = 0.5f * (Geometry.GetGameWidthInPixels() - rectangle.width);
			rectangle.y = Geometry.GetGameHeightInPixels() - rectangle.height;

			//GUILayout.BeginArea(rectangle);
			//GUILayout.Box(content, style);
			//if (Event.current.type == EventType.Repaint) {
			GUILayout.BeginArea(Geometry.GetGameRectangleInGui());
			GUILayout.Box(content);
			GUILayout.EndArea();
			//}
		}
		
		public void SetText(string text) {
			this.text = text;
		}
		
	}
	
}
