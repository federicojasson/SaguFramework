using System;
using UnityEngine;

namespace SaguFramework {
	
	[Serializable]
	public sealed class SoundsParameters {
		
		public AudioClip MainEffect;
		public AudioClip MenuEffect;
		public AudioClip InventoryEffect;
		public AudioClip InventoryPageEffect;
		public AudioClip MainMenuSong;
		public bool ShuffleSongs;
		public float DelayBetweenSongs;
		public AudioClip[] Playlist;
		
	}
	
}
