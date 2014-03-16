using UnityEngine;

public class Speech {
	
	private AudioClip audio;
	private string text;

	public Speech(string text, AudioClip audio) {
		this.text = text;
		this.audio = audio;
	}
	
	public AudioClip GetAudio() {
		return audio;
	}

	public string GetText() {
		return text;
	}

}
