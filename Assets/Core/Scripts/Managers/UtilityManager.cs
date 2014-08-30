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

		public static int[] GetIntegerPermutationLinear(int n) {
			// Computes a linear integer permutation
			int[] permutation = new int[n];

			for (int i = 0; i < n; i++)
				permutation[i] = i;

			return permutation;
		}

		public static int[] GetIntegerPermutationFisherYates(int n) {
			// Computes an integer permutation using the Fisher–Yates shuffle algorithm
			int[] permutation = GetIntegerPermutationLinear(n);

			for (int i = n - 1; i > 0; i--) {
				// Gets a random value j with 0 <= j <= i
				int j = Random.Range(0, i + 1);

				// Swaps the values of permutation[i] and permutation[j]
				int auxiliar = permutation[i];
				permutation[i] = permutation[j];
				permutation[j] = auxiliar;
			}

			return permutation;
		}

		public static Vector3 GetPosition(Vector2 position, float z) {
			// Returns the received position with the corresponding Z value
			return new Vector3(position.x, position.y, z);
		}

	}

}
