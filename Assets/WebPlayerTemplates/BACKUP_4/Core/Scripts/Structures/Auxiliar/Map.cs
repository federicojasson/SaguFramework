using System.Collections.Generic;

namespace SaguFramework {

	public class Map<K, V, E> where E : MapEntry<K, V> {

		public E[] Entries;
		
		private Dictionary<K, V> dictionary;
		
		public V this[K key] {
			get {
				if (dictionary == null)
					// The internal data structure has not been initialized yet
					Initialize();
				
				// Delegates the query to the internal data structure
				return dictionary[key];
			}
		}
		
		private void Initialize() {
			// Initializes the internal data structure
			dictionary = new Dictionary<K, V>(Entries.Length);
			
			// Copies all the entries to the internal data structure
			foreach (E entry in Entries)
				dictionary.Add(entry.Key, entry.Value);
		}
		
	}

}
