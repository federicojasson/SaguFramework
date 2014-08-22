using System.Collections;

public class MainSceneLoader : SceneLoader {

	public override void OnUnloadScene() {
		// TODO
	}
	
	protected override IEnumerator LoadSceneCoroutine() {
		SplashScreen splashScreen = GuiManager.ShowSplashScreen(Parameters.MainSplashScreenId);

		Timer timer = UtilityManager.CreateTimer();
		timer.RegisterStartTime();

		FadeParameters fadeInParameters = splashScreen.FadeInParameters;
		if (! fadeInParameters.Ignore)
			yield return StartCoroutine(GuiManager.FadeInCoroutine(fadeInParameters.Speed, fadeInParameters.Sprite));

		OptionManager.LoadOptions();
		string languageId = OptionManager.GetString(Parameters.LanguageOptionId);
		LanguageManager.LoadLanguage(languageId);

		float minimumDelayTime = 2; // TODO: get somehow
		yield return StartCoroutine(timer.WaitForAtLeastSecondsCoroutine(minimumDelayTime));

		FadeParameters fadeOutParameters = splashScreen.FadeOutParameters;
		if (! fadeOutParameters.Ignore)
			yield return StartCoroutine(GuiManager.FadeOutCoroutine(fadeOutParameters.Speed, fadeOutParameters.Sprite));

		GameManager.LoadMainMenu();
	}

}
