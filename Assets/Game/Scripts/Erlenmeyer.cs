public class Erlenmeyer : Item {

	public string onLookSpeechId;
	private Speech onLookSpeech;

	public override void OnLook() {
		Character playerCharacter = Game.GetPlayerCharacter();
		playerCharacter.CancelScheduledActions();
		playerCharacter.Look(transform.position);
		playerCharacter.Say(onLookSpeech);
	}

	public override void Start() {
		base.Start();
		onLookSpeech = LanguageManager.GetSpeech(onLookSpeechId);
	}

}
