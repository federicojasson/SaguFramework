using System.Collections.Generic;

public class SerializableMap<K, V, E> where E : SerializableMapEntry<K, V> {

	public E[] Entries;

	private Dictionary<K, V> dictionary;

	public V this[K key] {
		get {
			if (dictionary == null)
				// The internal dictionary has not been initialized yet
				Initialize();

			// Delegates the query to the internal dictionary
			return dictionary[key];
		}
	}

	private void Initialize() {
		// Initializes the internal dictionary
		dictionary = new Dictionary<K, V>(Entries.Length);
		
		// Copies all the entries to the dictionary
		foreach (E entry in Entries)
			dictionary.Add(entry.Key, entry.Value);
	}
	
}
