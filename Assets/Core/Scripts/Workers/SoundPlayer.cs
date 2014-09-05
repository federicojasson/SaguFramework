using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {
	
	public class SoundPlayer : Worker {
		
		private static SoundPlayer instance;
		
		public static SoundPlayer GetInstance() {
			return instance;
		}

		private AudioSource effectPlayer;
		private AudioSource songPlayer;
		private Dictionary<string, AudioSource> voicePlayers;
		private float voiceVolume;

		public override void Awake() {
			base.Awake();
			instance = this;
			gameObject.AddComponent<AudioListener>();
			effectPlayer = gameObject.AddComponent<AudioSource>();
			songPlayer = gameObject.AddComponent<AudioSource>();
			voicePlayers = new Dictionary<string, AudioSource>();
		}

		public void PlayInventoryEffect() {
			AudioClip inventoryEffect = Parameters.GetInventoryEffect();
			PlayEffect(inventoryEffect);
		}

		public void PlayMainEffect() {
			AudioClip mainEffect = Parameters.GetMainEffect();
			PlayEffect(mainEffect);
		}
		
		public void PlayMainMenuSong() {
			StopAllCoroutines();
			AudioClip mainMenuSong = Parameters.GetMainMenuSong();
			PlaySong(mainMenuSong);
		}

		public void PlayPlaylist() {
			StopAllCoroutines();
			AudioClip[] playlist = Parameters.GetPlaylist();
			StartCoroutine(PlayPlaylistCoroutine(playlist));
		}

		public void PlayVoice(string channelId, AudioClip voice) {
			AudioSource voicePlayer;

			if (! voicePlayers.TryGetValue(channelId, out voicePlayer)) {
				voicePlayer = gameObject.AddComponent<AudioSource>();
				voicePlayer.volume = voiceVolume;
				voicePlayers.Add(channelId, voicePlayer);
			}

			PlaySound(voicePlayer, voice);
		}
		
		public void SetEffectVolume(float volume) {
			effectPlayer.volume = volume;
		}
		
		public void SetMasterVolume(float volume) {
			AudioListener.volume = volume;
		}
		
		public void SetSongVolume(float volume) {
			songPlayer.volume = volume;
		}
		
		public void SetVoiceVolume(float volume) {
			voiceVolume = volume;

			foreach (AudioSource voicePlayer in voicePlayers.Values)
				voicePlayer.volume = volume;
		}

		private void PlayEffect(AudioClip effect) {
			PlaySound(effectPlayer, effect);
		}

		private IEnumerator PlayPlaylistCoroutine(AudioClip[] playlist) {
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

		private void PlaySong(AudioClip song) {
			PlaySound(songPlayer, song);
		}

		private void PlaySound(AudioSource soundPlayer, AudioClip sound) {
			soundPlayer.clip = sound;
			soundPlayer.Play();
		}

	}
	
}
