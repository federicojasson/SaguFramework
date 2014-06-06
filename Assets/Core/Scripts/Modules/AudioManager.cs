using UnityEngine;

public static class AudioManager {

	public static void Mute() {
		AudioListener.volume = 0;
	}

	public static void Pause() {
		AudioListener.pause = true;
	}
	
	public static void Resume() {
		AudioListener.pause = false;
	}

	public static void SetVolume(float volume) {
		AudioListener.volume = volume;
	}
	
}
