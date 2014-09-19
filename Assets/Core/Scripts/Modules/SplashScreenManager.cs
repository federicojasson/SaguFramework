using System.Collections;
using UnityEngine;

namespace SaguFramework {
	
	public static class SplashScreenManager {

		private static float creationTime;
		private static string currentGroup;
		private static float minimumDelayTime;

		public static IEnumerator Delay() {
			float currentTime = Time.time;
			float elapsedTime = currentTime - creationTime;
			
			if (elapsedTime < minimumDelayTime)
				yield return new WaitForSeconds(minimumDelayTime - elapsedTime);
		}
		
		public static void SetCurrentGroup(string groupId) {
			currentGroup = groupId;
		}

		public static void ShowMainSplashScreen() {
			SplashScreenParameters parameters = Parameters.GetMainSplashScreenParameters();
			ShowSplashScreen(parameters);
		}

		public static void ShowSplashScreenFromCurrentGroup() {
			SplashScreenParameters[] group = Parameters.GetSplashScreenParametersGroup(currentGroup);
			
			int randomIndex = Random.Range(0, group.Length);
			SplashScreenParameters parameters = group[randomIndex];
			
			ShowSplashScreen(parameters);
		}
		
		private static void ShowSplashScreen(SplashScreenParameters splashScreenParameters) {
			creationTime = Time.time;
			minimumDelayTime = splashScreenParameters.MinimumDelayTime;
			Factory.CreateSplashScreen(splashScreenParameters);
		}

	}
	
}
