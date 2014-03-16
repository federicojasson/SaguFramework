public static class ConfigurationManager {

	private static string languageId;

	public static string GetLanguageId() {
		return languageId;
	}

	public static void LoadConfiguration() {
		// TODO: load from XML
		UnityEngine.Debug.Log("TODO: load configuration from XML: " + P.CONFIGURATION_FILE_PATH);

		languageId = "Spanish";
	}
	
}
