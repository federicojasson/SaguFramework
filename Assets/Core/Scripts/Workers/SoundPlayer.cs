using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {

	// TODO: comentar

	public sealed class SoundPlayer : Worker {

		private static AudioSource effectPlayer;
		private static SoundPlayer instance;
		private static AudioSource songPlayer;
		private static Dictionary<string, AudioSource> voicePlayers;
		private static float voiceVolume;

		static SoundPlayer() {
			voicePlayers = new Dictionary<string, AudioSource>();
		}
		
		public static void PlayInventoryEffect() {
			AudioClip inventoryEffect = Parameters.GetInventoryEffect();
			PlayEffect(inventoryEffect);
		}

		public static void PlayMainEffect() {
			AudioClip mainEffect = Parameters.GetMainEffect();
			PlayEffect(mainEffect);
		}
		
		public static void PlayMenuEffect() {
			AudioClip menuEffect = Parameters.GetMenuEffect();
			PlayEffect(menuEffect);
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

		public static void PlayVoice(string channelId, AudioClip voice) {
			AudioSource voicePlayer;
			
			if (! voicePlayers.TryGetValue(channelId, out voicePlayer)) {
				voicePlayer = instance.gameObject.AddComponent<AudioSource>();
				voicePlayer.volume = voiceVolume;
				voicePlayers.Add(channelId, voicePlayer);
			}
			
			PlaySound(voicePlayer, voice);
		}
		
		public static void SetEffectVolume(float effectVolume) {
			effectPlayer.volume = effectVolume;
		}
		
		public static void SetMasterVolume(float masterVolume) {
			AudioListener.volume = masterVolume;
		}
		
		public static void SetSongVolume(float songVolume) {
			songPlayer.volume = songVolume;
		}
		
		public static void SetVoiceVolume(float voiceVolume) {
			SoundPlayer.voiceVolume = voiceVolume;
			
			foreach (AudioSource voicePlayer in voicePlayers.Values)
				voicePlayer.volume = voiceVolume;
		}

		public static void StopAllSounds() {
			StopPlaylist();
			
			effectPlayer.Stop();
			songPlayer.Stop();
			
			foreach (AudioSource voicePlayer in voicePlayers.Values)
				voicePlayer.Stop();
		}

		public static void StopVoice(string channelId) {
			AudioSource voicePlayer;
			
			if (voicePlayers.TryGetValue(channelId, out voicePlayer))
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
		
		private static void StopPlaylist() {
			instance.StopAllCoroutines();
		}

		public override void Awake() {
			base.Awake();
			instance = this;
			gameObject.AddComponent<AudioListener>();
			effectPlayer = gameObject.AddComponent<AudioSource>();
			songPlayer = gameObject.AddComponent<AudioSource>();
		}
		
		public void OnLevelWasLoaded(int level) {
			foreach (AudioSource voicePlayer in voicePlayers.Values)
				Destroy(voicePlayer);
			
			voicePlayers.Clear();
		}

	}
	
}
