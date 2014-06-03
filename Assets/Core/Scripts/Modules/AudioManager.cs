using UnityEngine;

public static class AudioManager {

	public static float GetAudioLength(AudioClip audio) {
		return audio.length;
	}

	public static void PlayAudio(AudioClip audio) {
		// TODO: solucion provisoria
		AudioSource.PlayClipAtPoint(audio, Vector3.zero);
	}

	public static void StopAudio(AudioClip audio) {
		//AudioSource. TODO
	}
	
}
