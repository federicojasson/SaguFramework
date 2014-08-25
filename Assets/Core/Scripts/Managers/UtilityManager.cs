using System.Text;
using UnityEngine;

public static partial class UtilityManager {

	static UtilityManager() {
		encoding = new UTF8Encoding(false); // UTF-8 without BOM
	}

	public static GameImage CreateGameImage() {
		return FrameworkAssets.CreateGameImage();
	}

	public static Timer CreateTimer() {
		return FrameworkAssets.CreateTimer();
	}

	public static Color GetColor(Color color, float opacity) {
		return new Color(color.r, color.g, color.b, opacity);
	}

	public static Vector3 GetPosition(Vector3 position, float z) {
		return new Vector3(position.x, position.y, z);
	}

	public static T Instantiate<T>(T prefab) where T : Object {
		return (T) Object.Instantiate(prefab);
	}

	public static T LoadResource<T>(string resourcePath) where T : Object {
		return (T) Resources.Load<T>(resourcePath);
	}

}
