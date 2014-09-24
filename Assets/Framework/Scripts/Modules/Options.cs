using System.Collections.Generic;

namespace SaguFramework {

	/// Handles the options.
	/// Offers methods to load them automatically and to get them.
	public static partial class Options {
		
		private static Dictionary<string, bool> booleans; // The boolean options
		private static Dictionary<string, float> floats; // The float options
		private static Dictionary<string, int> integers; // The integer options
		private static Dictionary<string, string> strings; // The string options
		
		/// Performs class initialization tasks.
		static Options() {
			booleans = new Dictionary<string, bool>();
			floats = new Dictionary<string, float>();
			integers = new Dictionary<string, int>();
			strings = new Dictionary<string, string>();
		}

		/// Returns a boolean option.
		/// Receives the option's ID.
		public static bool GetBoolean(string booleanId) {
			return booleans[booleanId];
		}

		/// Returns a float option.
		/// Receives the option's ID.
		public static float GetFloat(string floatId) {
			return floats[floatId];
		}
		
		/// Returns an integer option.
		/// Receives the option's ID.
		public static int GetInteger(string integerId) {
			return integers[integerId];
		}
		
		/// Returns a string option.
		/// Receives the option's ID.
		public static string GetString(string stringId) {
			return strings[stringId];
		}
		
		/// Sets a boolean option.
		/// Receives the option's ID and the new value.
		public static void SetBoolean(string booleanId, bool booleanValue) {
			booleans[booleanId] = booleanValue;
		}

		/// Sets a float option.
		/// Receives the option's ID and the new value.
		public static void SetFloat(string floatId, float floatValue) {
			floats[floatId] = floatValue;
		}
		
		/// Sets an integer option.
		/// Receives the option's ID and the new value.
		public static void SetInteger(string integerId, int integerValue) {
			integers[integerId] = integerValue;
		}
		
		/// Sets a string option.
		/// Receives the option's ID and the new value.
		public static void SetString(string stringId, string stringValue) {
			strings[stringId] = stringValue;
		}

	}
	
}
