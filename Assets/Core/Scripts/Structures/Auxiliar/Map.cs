﻿using System.Collections.Generic;

namespace SaguFramework {
	
	public class Map<K, V, E> where E : MapEntry<K, V> {
		
		public E[] Entries;
		
		private Dictionary<K, V> dictionary;
		
		public V this[K key] {
			get {
				if (dictionary == null)
					Initialize();
				
				// Delegates the query to the internal dictionary
				return dictionary[key];
			}
		}
		
		private void Initialize() {
			dictionary = new Dictionary<K, V>(Entries.Length);
			
			// Copies all the entries to the dictionary
			foreach (E entry in Entries)
				dictionary.Add(entry.Key, entry.Value);
		}
		
	}
	
}
