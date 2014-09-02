using UnityEngine;

namespace SaguFramework {
	
	public abstract class Worker : MonoBehaviour {
		
		public virtual void Awake() {
			DontDestroyOnLoad(this);
		}

	}
	
}
