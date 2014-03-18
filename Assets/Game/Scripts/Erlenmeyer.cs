public class Erlenmeyer : InteractiveObject {

	public string onLookSpeechId;
	private Speech onLookSpeech;

	public override void OnLook() {
		Game.GetPlayerCharacter().Say(onLookSpeech);
	}

	public override void Start() {
		base.Start();
		onLookSpeech = LanguageManager.GetSpeech(onLookSpeechId);
	}

}
