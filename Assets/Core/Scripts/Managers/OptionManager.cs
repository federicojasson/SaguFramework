using System.Collections.Generic;

namespace SaguFramework {

	public static partial class OptionManager {
		
		private static Dictionary<string, bool> booleans;
		private static Dictionary<string, float> floats;
		private static Dictionary<string, int> integers;
		private static Dictionary<string, string> strings;
		
		static OptionManager() {
			// Initializes the data structures
			booleans = new Dictionary<string, bool>();
			floats = new Dictionary<string, float>();
			integers = new Dictionary<string, int>();
			strings = new Dictionary<string, string>();
		}

		public static bool GetBoolean(string booleanId) {
			return booleans[booleanId];
		}
		
		public static float GetFloat(string floatId) {
			return floats[floatId];
		}
		
		public static int GetInteger(string integerId) {
			return integers[integerId];
		}
		
		public static string GetString(string stringId) {
			return strings[stringId];
		}
		
		public static void SetBoolean(string booleanId, bool booleanValue) {
			booleans[booleanId] = booleanValue;
		}
		
		public static void SetFloat(string floatId, float floatValue) {
			floats[floatId] = floatValue;
		}
		
		public static void SetInteger(string integerId, int integerValue) {
			integers[integerId] = integerValue;
		}
		
		public static void SetString(string stringId, string stringValue) {
			strings[stringId] = stringValue;
		}

	}

}
