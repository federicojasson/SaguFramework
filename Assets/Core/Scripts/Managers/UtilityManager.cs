using System.Text;
using UnityEngine;

namespace SaguFramework {
	
	public static partial class UtilityManager {

		static UtilityManager() {
			encoding = new UTF8Encoding(false); // UTF-8 without BOM
		}

		public static Color GetColor(Color color, float opacity) {
			// Returns the received color with the corresponding alpha value
			return new Color(color.r, color.g, color.b, opacity);
		}

		public static Vector3 GetPosition(Vector2 position, float z) {
			// Returns the received position with the corresponding Z value
			return new Vector3(position.x, position.y, z);
		}

	}

}
