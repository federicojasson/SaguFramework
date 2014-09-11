using System;
using System.Text;
using UnityEngine;

namespace SaguFramework {
	
	public static partial class Utilities {

		static Utilities() {
			encoding = new UTF8Encoding(false); // UTF-8 without BOM
		}

		public static Color GetColor(Color color, float opacity) {
			return new Color(color.r, color.g, color.b, opacity);
		}

		public static T GetComponent<T>(Component component) where T : Component {
			return component.gameObject.GetComponent<T>();
		}

		public static int GetEnumCount(Type type) {
			return Enum.GetNames(type).Length;
		}

		public static int[] GetIntegerPermutationLinear(int n) {
			int[] permutation = new int[n];
			
			for (int i = 0; i < n; i++)
				permutation[i] = i;
			
			return permutation;
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

		public static Vector3 GetPosition(Vector3 position, float z) {
			return new Vector3(position.x, position.y, z);
		}

		public static Vector2 GetSize(Vector2 currentSize, float height) {
			float aspectRatio = currentSize.x / currentSize.y;

			float sizeY = Geometry.GameToWorldHeight(height);
			float sizeX = sizeY * aspectRatio;

			return new Vector2(sizeX, sizeY);
		}

		public static int SearchArray<T>(T[] array, T value) {
			return Array.IndexOf<T>(array, value);
		}

		public static void SetParent(Component child, Component parent) {
			child.transform.parent = parent.transform;
		}

	}
	
}
