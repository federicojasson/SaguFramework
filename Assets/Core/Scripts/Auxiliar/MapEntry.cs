namespace SaguFramework {

	/// Represents a map entry.
	/// Subclasses of this class are meant to be used from the Unity Editor.
	public abstract class MapEntry<K, V>  {
		
		public K Key; // The key (public so that it can be modified from the Editor)
		public V Value; // The value (public so that it can be modified from the Editor)
		
	}
	
}
