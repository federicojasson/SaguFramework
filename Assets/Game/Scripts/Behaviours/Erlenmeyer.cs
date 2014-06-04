using UnityEngine;

public class Erlenmeyer : ItemBehaviour {

	// TODO: initialize
	private AudioClip onLookAudio;
	private string onLookText;

	public override void DoLook() {
		ActionManager.Look(this, onLookText, onLookAudio);
	}

	public void Start() {
		onLookAudio = LanguageManager.GetAudio(G.ERLENMEYER_ON_LOOK);
		onLookText = LanguageManager.GetText(G.ERLENMEYER_ON_LOOK);
	}

	protected override string GetLabelText() {
		return LanguageManager.GetText(G.ERLENMEYER_LABEL);
	}

}
