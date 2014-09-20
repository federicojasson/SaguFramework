using SaguFramework;
using System.Collections.Generic;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public static class GameGui {

		private static Stack<Rect> areas;

		static GameGui() {
			areas = new Stack<Rect>();
			areas.Push(Geometry.GetGameRectangleInGui());
		}

		public static void BeginArea(float x, float y, float width, float height) {
			Rect area = areas.Peek();
			Rect newArea = new Rect(x * area.width, y * area.height, width * area.width, height * area.height);
			GUILayout.BeginArea(newArea);
			areas.Push(newArea);
		}

		public static void EndArea() {
			GUILayout.EndArea();
			areas.Pop();
		}

	}
	
}
