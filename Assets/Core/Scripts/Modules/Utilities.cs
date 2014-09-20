using System;
using System.Globalization;
using System.Text;
using UnityEngine;

namespace SaguFramework {
	
	public static partial class Utilities {

		static Utilities() {
			encoding = new UTF8Encoding(false); // UTF-8 without BOM
		}

		public static string BooleanToString(bool value) {
			return value.ToString(CultureInfo.InvariantCulture);
		}
		
		public static string FloatToString(float value) {
			return value.ToString(CultureInfo.InvariantCulture);
		}

		public static Color GetColor(Color color, float opacity) {
			return new Color(color.r, color.g, color.b, opacity);
		}

		public static T GetComponent<T>(Component component) where T : Component {
			return component.gameObject.GetComponent<T>();
		}

		public static int GetEnumCount<T>() {
			return Enum.GetNames(typeof(T)).Length;
		}

		public static T GetEnumValue<T>(string stringValue) {
			return (T) Enum.Parse(typeof(T), stringValue);
		}
		
		public static int[] GetIntegerPermutationFisherYates(int n) {
			int[] permutation = GetIntegerPermutationLinear(n);
			
			for (int i = n - 1; i > 0; i--) {
				int j = UnityEngine.Random.Range(0, i + 1);
				
				int auxiliar = permutation[i];
				permutation[i] = permutation[j];
				permutation[j] = auxiliar;
			}
			
			return permutation;
		}

		public static int[] GetIntegerPermutationLinear(int n) {
			int[] permutation = new int[n];
			
			for (int i = 0; i < n; i++)
				permutation[i] = i;
			
			return permutation;
		}

		public static Vector2 GetSize(Vector2 currentSize, float preferredHeight) {
			float aspectRatio = currentSize.x / currentSize.y;

			float sizeY = preferredHeight;
			float sizeX = sizeY * aspectRatio;

			return new Vector2(sizeX, sizeY);
		}

		public static Vector2 GetSize(Vector2 currentSize, Vector2 preferredSize) {
			float aspectRatio = currentSize.x / currentSize.y;
			float preferredAspectRatio = preferredSize.x / preferredSize.y;

			float sizeX;
			float sizeY;
			if (aspectRatio > preferredAspectRatio) {
				sizeX = preferredSize.x;
				sizeY = sizeX / aspectRatio;
			} else {
				sizeY = preferredSize.y;
				sizeX = sizeY * aspectRatio;
			}

			return new Vector2(sizeX, sizeY);
		}
		
		public static Vector3 GetVector3(Vector3 position, float z) {
			return new Vector3(position.x, position.y, z);
		}

		public static string IntegerToString(int value) {
			return value.ToString(CultureInfo.InvariantCulture);
		}

		public static void SetParent(Component child, Component parent) {
			child.transform.parent = parent.transform;
		}
		
		public static bool StringToBoolean(string value) {
			return Boolean.Parse(value);
		}
		
		public static float StringToFloat(string value) {
			return float.Parse(value, CultureInfo.InvariantCulture);
		}
		
		public static int StringToInteger(string value) {
			return int.Parse(value, CultureInfo.InvariantCulture);
		}

	}
	
}
