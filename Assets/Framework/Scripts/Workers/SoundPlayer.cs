using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {

	/// Responsible of playing all the sounds in the game.
	/// There are three types of audios: effects, songs and voices.
	/// It offers different channels to play voices, since characters could, theoretically, speak at the same time.
	/// Also, it is possible to set the volume of the different types of sounds separately and the master volume.
	public sealed class SoundPlayer : Worker {

		private static AudioSource effectPlayer; // The audio source for the effects
		private static SoundPlayer instance; // The instance of this worker
		private static AudioSource songPlayer; // The audio source for the music
		private static Dictionary<string, AudioSource> voicePlayers; // The audio sources for the voices
		private static float voiceVolume; // The voice volume

		/// Performs class initialization tasks.
		static SoundPlayer() {
			voicePlayers = new Dictionary<string, AudioSource>();
		}

		/// Plays the inventory effect.
		public static void PlayInventoryEffect() {
			AudioClip inventoryEffect = Parameters.GetInventoryEffect();
			PlayEffect(inventoryEffect);
		}

		/// Plays the main effect.
		public static void PlayMainEffect() {
			AudioClip mainEffect = Parameters.GetMainEffect();
			PlayEffect(mainEffect);
		}

		/// Plays the menu effect.
		public static void PlayMenuEffect() {
			AudioClip menuEffect = Parameters.GetMenuEffect();
			PlayEffect(menuEffect);
		}

		/// Plays the main menu song.
		/// It also stops the playlist, if it is playing.
		public static void PlayMainMenuSong() {
			// Stops the playlist reproduction (if it was being played)
			StopPlaylist();

			AudioClip mainMenuSong = Parameters.GetMainMenuSong();
			PlaySong(mainMenuSong);
		}

		/// Plays the song playlist.
		/// If it is already playing, it resets it.
		public static void PlayPlaylist() {
			// Stops the playlist reproduction (if it was being played)
			StopPlaylist();

			AudioClip[] playlist = Parameters.GetPlaylist();
			instance.StartCoroutine(PlayPlaylistCoroutine(playlist));
		}
		
		/// Plays a voice in a certain channel.
		/// Receives the channel's ID and the audio voice.
		/// If there is not an audio source associated with the specified channel, it creates it.
		public static void PlayVoice(string channelId, AudioClip voice) {
			AudioSource voicePlayer;
			
			if (! voicePlayers.TryGetValue(channelId, out voicePlayer)) {
				// There is not an audio source associated with that voice channel

				// Adds an audio source for the voice channel
				voicePlayer = instance.gameObject.AddComponent<AudioSource>();

				// Sets the voice volume
				voicePlayer.volume = voiceVolume;

				// Registers the voice audio source
				voicePlayers.Add(channelId, voicePlayer);
			}
			
			PlaySound(voicePlayer, voice);
		}

		/// Sets the effect volume.
		/// The received volume must be a value between 0 and 1.
		public static void SetEffectVolume(float effectVolume) {
			effectPlayer.volume = effectVolume;
		}

		/// Sets the master volume.
		/// The received volume must be a value between 0 and 1.
		public static void SetMasterVolume(float masterVolume) {
			AudioListener.volume = masterVolume;
		}
		
		/// Sets the music volume.
		/// The received volume must be a value between 0 and 1.
		public static void SetSongVolume(float songVolume) {
			songPlayer.volume = songVolume;
		}

		/// Sets the voice volume.
		/// The received volume must be a value between 0 and 1.
		public static void SetVoiceVolume(float voiceVolume) {
			// Registers the current voice volume, to apply it if a new voice audio source is added
			SoundPlayer.voiceVolume = voiceVolume;

			// Sets the volume in the existing voice audio sources
			foreach (AudioSource voicePlayer in voicePlayers.Values)
				voicePlayer.volume = voiceVolume;
		}

		/// Stops any currently playing sound.
		/// It also stops the playlist, if it is playing.
		public static void StopAllSounds() {
			// Stops the playlist reproduction (if it was being played)
			StopPlaylist();

			// Stops the effect and current song reproduction
			effectPlayer.Stop();
			songPlayer.Stop();

			// Stops the voices reproduction
			foreach (AudioSource voicePlayer in voicePlayers.Values)
				voicePlayer.Stop();
		}

		/// Stops the reproduction of a certain voice channel.
		/// Receives the channel's ID.
		public static void StopVoice(string channelId) {
			AudioSource voicePlayer;

			// Before stopping the audio source, it checks if the channel actually exists
			// This is necessary because the game's characters call this method when StopActions is invoked and the
			// channel may have not been initialized yet
			if (voicePlayers.TryGetValue(channelId, out voicePlayer))
				voicePlayer.Stop();
		}

		/// Plays a certain effect.
		private static void PlayEffect(AudioClip effect) {
			PlaySound(effectPlayer, effect);
		}
		
		/// Plays the songs' playlist indefinitely.
		/// The songs are shuffled or not according to the game's parameters.
		/// If so, this is done in every playlist iteration, so that all songs get reproduced evenly.
		private static IEnumerator PlayPlaylistCoroutine(AudioClip[] playlist) {
			if (playlist.Length > 0) {
				// The playlist has at least one song
				
				// Gets the delay between songs and whether to shuffle them
				float delayBetweenSongs = Parameters.GetDelayBetweenSongs();
				bool shuffleSongs = Parameters.ShuffleSongs();
				
				while (true) {
					// Gets an integer permutation that determines the songs' playing order
					int[] permutation;
					if (shuffleSongs)
						permutation = Utilities.GetIntegerPermutationFisherYates(playlist.Length);
					else
						permutation = Utilities.GetIntegerPermutationLinear(playlist.Length);
					
					// Reproduces all the songs before shuffle them again
					for (int i = 0; i < permutation.Length; i++) {
						// Plays the current song
						AudioClip song = playlist[permutation[i]];
						PlaySong(song);
						
						// Waits until the song is finished and a certain extra time (the delay between songs)
						yield return new WaitForSeconds(song.length + delayBetweenSongs);
					}
				}
			}
		}

		/// Plays a certain song.
		private static void PlaySong(AudioClip song) {
			PlaySound(songPlayer, song);
		}

		/// Plays a sound in a certain audio source.
		/// This automatically stops any sound playing in that audio source.
		private static void PlaySound(AudioSource soundPlayer, AudioClip sound) {
			soundPlayer.clip = sound;
			soundPlayer.Play();
		}
		
		/// Stops the playlist coroutine.
		private static void StopPlaylist() {
			instance.StopAllCoroutines();
		}

		public override void Awake() {
			base.Awake();
			
			// Sets this object as the instance of this worker
			instance = this;

			// Adds an audio listener
			gameObject.AddComponent<AudioListener>();

			// Adds two audio sources: one for the effects and another one for the music
			// The voices' audio sources are added by channel demand
			effectPlayer = gameObject.AddComponent<AudioSource>();
			songPlayer = gameObject.AddComponent<AudioSource>();
		}
		
		public void OnLevelWasLoaded(int level) {
			// Destroys all the voices' audio sources when the scene changes
			// This avoids accumulating unused audio sources
			foreach (AudioSource voicePlayer in voicePlayers.Values)
				Destroy(voicePlayer);

			// Clears the audio sources references
			voicePlayers.Clear();
		}

	}
	
}
