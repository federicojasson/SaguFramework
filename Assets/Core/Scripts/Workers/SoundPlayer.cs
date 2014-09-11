using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {
	
	public class SoundPlayer : Worker {
		
		private static AudioSource effectPlayer;
		private static SoundPlayer instance;
		private static AudioSource songPlayer;
		private static Dictionary<string, AudioSource> voicePlayers;
		private static float voiceVolume;

		static SoundPlayer() {
			voicePlayers = new Dictionary<string, AudioSource>();
		}

		public static void PlayMainEffect() {
			AudioClip mainEffect = Parameters.GetMainEffect();
			PlayEffect(mainEffect);
		}

		public static void PlayMainMenuSong() {
			StopPlaylist();
			AudioClip mainMenuSong = Parameters.GetMainMenuSong();
			PlaySong(mainMenuSong);
		}

		public static void PlayPlaylist() {
			StopPlaylist();
			AudioClip[] playlist = Parameters.GetPlaylist();
			instance.StartCoroutine(PlayPlaylistCoroutine(playlist));
		}

		public static void PlayVoice(string voicePlayerId, AudioClip voice) {
			AudioSource voicePlayer;
			
			if (! voicePlayers.TryGetValue(voicePlayerId, out voicePlayer)) {
				voicePlayer = instance.gameObject.AddComponent<AudioSource>();
				voicePlayer.volume = voiceVolume;
				voicePlayers.Add(voicePlayerId, voicePlayer);
			}
			
			PlaySound(voicePlayer, voice);
		}

		public static void SetEffectVolume(float volume) {
			effectPlayer.volume = volume;
		}

		public static void SetMasterVolume(float volume) {
			AudioListener.volume = volume;
		}

		public static void SetSongVolume(float volume) {
			songPlayer.volume = volume;
		}

		public static void SetVoiceVolume(float volume) {
			voiceVolume = volume;
			
			foreach (AudioSource voicePlayer in voicePlayers.Values)
				voicePlayer.volume = volume;
		}

		public static void StopAllSounds() {
			StopEffect();
			StopPlaylist();
			StopSong();
			StopVoice();
		}

		public static void StopEffect() {
			effectPlayer.Stop();
		}

		public static void StopPlaylist() {
			instance.StopAllCoroutines();
		}
		
		public static void StopSong() {
			songPlayer.Stop();
		}
		
		public static void StopVoice() {
			foreach (AudioSource voicePlayer in voicePlayers.Values)
				voicePlayer.Stop();
		}

		private static void PlayEffect(AudioClip effect) {
			PlaySound(effectPlayer, effect);
		}

		private static IEnumerator PlayPlaylistCoroutine(AudioClip[] playlist) {
			if (playlist.Length > 0) {
				float delayBetweenSongs = Parameters.GetDelayBetweenSongs();
				bool shuffleSongs = Parameters.ShuffleSongs();
				
				while (true) {
					int[] permutation;
					if (shuffleSongs)
						permutation = Utilities.GetIntegerPermutationFisherYates(playlist.Length);
					else
						permutation = Utilities.GetIntegerPermutationLinear(playlist.Length);
					
					for (int i = 0; i < permutation.Length; i++) {
						AudioClip song = playlist[permutation[i]];
						PlaySong(song);
						yield return new WaitForSeconds(song.length + delayBetweenSongs);
					}
				}
			}
		}

		private static void PlaySong(AudioClip song) {
			PlaySound(songPlayer, song);
		}
		
		private static void PlaySound(AudioSource soundPlayer, AudioClip sound) {
			soundPlayer.clip = sound;
			soundPlayer.Play();
		}
		
		public override void Awake() {
			base.Awake();
			instance = this;
			gameObject.AddComponent<AudioListener>();
			effectPlayer = gameObject.AddComponent<AudioSource>();
			songPlayer = gameObject.AddComponent<AudioSource>();
		}

		public override void OnSceneChange() {
			foreach (AudioSource voicePlayer in voicePlayers.Values)
				Destroy(voicePlayer);

			voicePlayers.Clear();
		}
		
	}
	
}
