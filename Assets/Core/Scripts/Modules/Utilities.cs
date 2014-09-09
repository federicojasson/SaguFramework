using System;
using UnityEngine;

namespace SaguFramework {
	
	public static class Utilities {

		public static T GetComponent<T>(Component component) where T : Component {
			return component.gameObject.GetComponent<T>();
		}

		public static int GetEnumCount(Type type) {
			return Enum.GetNames(type).Length;
		}

		public static Vector3 GetPosition(Vector3 position, float z) {
			return new Vector3(position.x, position.y, z);
		}

		public static int SearchArray<T>(T[] array, T value) {
			return Array.IndexOf<T>(array, value);
		}

	}
	
}
