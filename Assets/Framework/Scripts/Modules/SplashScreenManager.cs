using System.Collections;
using UnityEngine;

namespace SaguFramework {

	/// Manages the splash screens.
	public static class SplashScreenManager {

		private static string currentGroup; // The current splash screen group

		/// Delays the execution to show the splash screen.
		public static IEnumerator Delay() {
			return Entities.GetSplashScreen().Delay();
		}

		/// Sets the current splash screen group.
		public static void SetCurrentGroup(string groupId) {
			currentGroup = groupId;
		}

		/// Shows the main splash screen.
		public static void ShowMainSplashScreen() {
			SplashScreenParameters parameters = Parameters.GetMainSplashScreenParameters();
			ShowSplashScreen(parameters);
		}

		/// Shows a random splash screen from the current group.
		public static void ShowSplashScreenFromCurrentGroup() {
			SplashScreenParameters[] group = Parameters.GetSplashScreenParametersGroup(currentGroup);

			// Gets a random index
			int randomIndex = Random.Range(0, group.Length);
			SplashScreenParameters parameters = group[randomIndex];
			
			ShowSplashScreen(parameters);
		}

		/// Shows a splash screen.
		private static void ShowSplashScreen(SplashScreenParameters splashScreenParameters) {
			Factory.CreateSplashScreen(splashScreenParameters);
		}

	}
	
}
