using System.Collections;

public class MainSceneLoader : SceneLoader {

	public override void OnUnloadScene() {
		// TODO
	}
	
	protected override IEnumerator LoadSceneCoroutine() {
		SplashScreen splashScreen = GuiManager.ShowSplashScreen(Parameters.GetMainSplashScreenId());

		Timer timer = UtilityManager.CreateTimer();
		timer.RegisterStartTime();

		// TODO: fade in

		// TODO: load things
		OptionManager.LoadOptions();
		string languageId = OptionManager.GetString(Parameters.GetLanguageOptionId());
		LanguageManager.LoadLanguage(languageId);

		float minimumDelayTime = 2; // TODO: get somehow
		yield return StartCoroutine(timer.WaitForAtLeastSecondsCoroutine(minimumDelayTime));

		// TODO: fade out

		GameManager.LoadMainMenu();
	}

}
