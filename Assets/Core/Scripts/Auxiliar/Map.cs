using System.Collections.Generic;

namespace SaguFramework {

	/// Represents a map.
	/// Subclasses of this class are meant to be used from the Unity Editor.
	public abstract class Map<K, V, E> where E : MapEntry<K, V> {
		
		public E[] Entries; // The entries (public so that it can be modified from the Editor)
		
		private Dictionary<K, V> dictionary; // Internal dictionary that implements the map's logic

		/// Defines the square brackets ([]) operator.
		/// This is syntactic sugar, so that an entry's value can be obtained writing map[key].
		public V this[K key] {
			get {
				if (dictionary == null)
					// Initializes on demand the internal dictionary
					Initialize();

				// Serves the request using the internal dictionary
				return dictionary[key];
			}
		}

		/// Initializes the internal dictionary with the entries.
		/// This method must be called once in the object's lifetime.
		private void Initialize() {
			dictionary = new Dictionary<K, V>(Entries.Length);

			foreach (E entry in Entries)
				dictionary.Add(entry.Key, entry.Value);
		}
		
	}
	
}
