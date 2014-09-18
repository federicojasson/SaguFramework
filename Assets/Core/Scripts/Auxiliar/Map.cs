using System.Collections.Generic;

namespace SaguFramework {
	
	public abstract class Map<K, V, E> where E : MapEntry<K, V> {
		
		public E[] Entries;
		
		private Dictionary<K, V> dictionary;
		
		public V this[K key] {
			get {
				if (dictionary == null)
					Initialize();

				return dictionary[key];
			}
		}
		
		private void Initialize() {
			dictionary = new Dictionary<K, V>(Entries.Length);

			foreach (E entry in Entries)
				dictionary.Add(entry.Key, entry.Value);
		}
		
	}
	
}
