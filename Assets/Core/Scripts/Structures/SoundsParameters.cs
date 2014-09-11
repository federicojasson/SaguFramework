using System;
using UnityEngine;

namespace SaguFramework {
	
	[Serializable]
	public class SoundsParameters {
		
		public AudioClip MainEffect;
		public AudioClip MainMenuSong;
		public AudioClip[] Playlist;
		public bool ShuffleSongs;
		public float DelayBetweenSongs;
		
	}
	
}
