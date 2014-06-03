using UnityEngine;

public static class AudioManager {

	public static void Mute() {
		AudioListener.volume = 0;
	}

	public static void SetVolume(float volume) {
		AudioListener.volume = volume;
	}
	
}
