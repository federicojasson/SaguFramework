using System.Collections;
using UnityEngine;

namespace SaguFramework {
	
	public class SplashScreenHandler : Worker {
		
		private static float creationTime;
		private static string currentGroupId;
		private static float minimumDelayTime;

		public static IEnumerator Delay() {
			float currentTime = Time.time;
			float elapsedTime = currentTime - creationTime;
			
			if (elapsedTime < minimumDelayTime)
				yield return new WaitForSeconds(minimumDelayTime - elapsedTime);
		}

		public static void SetCurrentGroupId(string groupId) {
			currentGroupId = groupId;
		}

		public static void ShowMainSplashScreen() {
			SplashScreenParameters parameters = Parameters.GetMainSplashScreenParameters();
			ShowSplashScreen(parameters);
		}

		public static void ShowSplashScreenFromCurrentGroup() {
			SplashScreenParameters[] group = Parameters.GetSplashScreenParametersGroup(currentGroupId);

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
