using UnityEngine;

namespace SaguFramework {
	
	public class SplashScreenHandler : Worker {
		
		private static SplashScreenHandler instance;
		
		public static SplashScreenHandler GetInstance() {
			return instance;
		}

		private string currentGroupId;
		
		public override void Awake() {
			base.Awake();
			instance = this;
		}

		public void SetCurrentGroupId(string groupId) {
			currentGroupId = groupId;
		}
		
		public void ShowMainSplashScreen() {
			SplashScreenParameters parameters = Parameters.GetMainSplashScreenParameters();
			ShowSplashScreen(parameters);
		}
		
		public void ShowSplashScreenFromCurrentGroup() {
			SplashScreenParameters[] group = Parameters.GetSplashScreenParametersGroup(currentGroupId);
			int randomIndex = Random.Range(0, group.Length);
			SplashScreenParameters parameters = group[randomIndex];
			ShowSplashScreen(parameters);
		}

		private void ShowSplashScreen(SplashScreenParameters parameters) {
			SplashScreen splashScreen = Factory.CreateSplashScreen(parameters);
			splashScreen.SetMinimumDelayTime(parameters.MinimumDelayTime);
			splashScreen.Show();
		}
		
	}
	
}
