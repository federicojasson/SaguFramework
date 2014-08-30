using System.Collections;
using UnityEngine;

namespace SaguFramework {
	
	public partial class AudioPlayer : MonoBehaviour {

		private AudioSource songAudioSource;
		private AudioSource voiceAudioSource;

		public void Awake() {
			// Sets itself as the singleton instance
			instance = this;

			// Assigns the audio sources
			AudioSource[] audioSources = GetComponents<AudioSource>();
			songAudioSource = audioSources[0];
			voiceAudioSource = audioSources[1];
		}

		public void PlaySong(AudioClip song) {
			if (song != null) {
				// Plays the song
				songAudioSource.clip = song;
				songAudioSource.Play();
			}
		}

		public void PlaySongs(AudioClip[] songs) {
			// Starts a coroutine to play the songs indefinitely
			StartCoroutine(PlaySongsCoroutine(songs));
		}

		public void StopSongs() {
			// Stops the play-songs coroutine (if it is executing)
			StopAllCoroutines();

			// Stops the currently playing song (if any)
			songAudioSource.Stop();
		}

		private IEnumerator PlaySongsCoroutine(AudioClip[] songs) {
			if (songs.Length > 0) {
				// There is at least one song to play

				// Gets the delay between songs
				float delayBetweenSongs = ParameterManager.GetDelayBetweenSongs();

				// Determines if the songs should be shuffled
				bool shuffleSongs = ParameterManager.ShuffleSongs();

				while (true) {
					int[] permutation;

					// Computes an integer permutation
					if (shuffleSongs)
						permutation = UtilityManager.GetIntegerPermutationFisherYates(songs.Length);
					else
						permutation = UtilityManager.GetIntegerPermutationLinear(songs.Length);

					// Plays the songs in the order established by the permutation
					for (int i = 0; i < permutation.Length; i++) {
						// Gets the next song
						AudioClip song = songs[permutation[i]];

						// Plays the song
						PlaySong(song);
						
						// Waits until the song finishes and an extra delay
						yield return new WaitForSeconds(song.length + delayBetweenSongs);
					}
				}
			}
		}
		
	}
	
}
