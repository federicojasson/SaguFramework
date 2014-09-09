using UnityEngine;

namespace SaguFramework {
	
	public abstract class Worker : MonoBehaviour {

		public virtual void Awake() {
			DontDestroyOnLoad(this);
			Objects.RegisterWorker(this);
			Debug.Log(GetType());
		}

		public virtual void OnGameModeChange() {}

		public virtual void OnOrderChange() {}

	}
	
}
