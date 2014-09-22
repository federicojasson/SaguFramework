using UnityEngine;

namespace SaguFramework {

	// TODO: comentar

	public abstract class Worker : MonoBehaviour {

		public virtual void Awake() {
			DontDestroyOnLoad(this);
		}

	}
	
}
