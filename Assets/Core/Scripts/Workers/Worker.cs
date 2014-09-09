using UnityEngine;

namespace SaguFramework {
	
	public abstract class Worker : MonoBehaviour {

		public virtual void Awake() {
			DontDestroyOnLoad(this);
			Objects.RegisterWorker(this);
		}

		public virtual void OnGameModeChange() {}

		public virtual void OnOrderChange() {}

	}
	
}
