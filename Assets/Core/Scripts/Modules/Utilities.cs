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

		public static GUIStyle GetRelativeStyle(GUIStyle style) {
			float gamePreferredWidthInPixels = Geometry.GetGamePreferredWidthInPixels();
			float gameWidthInPixels = Geometry.GetGameWidthInPixels();
			float scaleFactor = gameWidthInPixels / gamePreferredWidthInPixels;

			GUIStyle relativeStyle = new GUIStyle(style);

			relativeStyle.fontSize = (int) (style.fontSize * scaleFactor);

			relativeStyle.margin.left = (int) (style.margin.left * scaleFactor);
          	relativeStyle.margin.right = (int) (style.margin.right * scaleFactor);
			relativeStyle.margin.top = (int) (style.margin.top * scaleFactor);
			relativeStyle.margin.bottom = (int) (style.margin.bottom * scaleFactor);

			relativeStyle.padding.left = (int) (style.padding.left * scaleFactor);
			relativeStyle.padding.right = (int) (style.padding.right * scaleFactor);
			relativeStyle.padding.top = (int) (style.padding.top * scaleFactor);
			relativeStyle.padding.bottom = (int) (style.padding.bottom * scaleFactor);

			return relativeStyle;
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

		public static int SearchArray<T>(T[] array, T value) {
			return Array.IndexOf<T>(array, value);
		}

		public static void SetParent(Component child, Component parent) {
			child.transform.parent = parent.transform;
		}

	}
	
}
