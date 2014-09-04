using System;
using UnityEngine;

namespace SaguFramework {
	
	[Serializable]
	public class SoundsParameters {

		public AudioClip MainEffect;
		public AudioClip InventoryEffect;
		public AudioClip MainMenuSong;
		public AudioClip[] Songs;
		public bool ShuffleSongs;
		public float DelayBetweenSongs;
		
	}
	
}
