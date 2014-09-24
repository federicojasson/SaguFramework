using UnityEngine;

namespace SaguFramework {

	/// Performs different framework's tasks.
	/// Each worker is initialized once at the beginning and it is never destroyed.
	/// Unlike modules, workers live as persistent objects in the world, because they must carry on certain tasks that
	/// require this.
	public abstract class Worker : MonoBehaviour {

		public virtual void Awake() {
			// Prevents this object from being destroyed
			DontDestroyOnLoad(this);
		}

	}
	
}
