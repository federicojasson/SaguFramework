using UnityEngine;

namespace SaguFramework {
	
	public class Character : MonoBehaviour {

		private string id;
		
		public void Awake() {
			Objects.RegisterCharacter(this);
		}

		public string GetId() {
			return id;
		}
		
		public void OnDestroy() {
			Objects.UnregisterCharacter(this);
		}

		public void SetId(string id) {
			this.id = id;
		}

		public void SetPosition(Vector2 position) {
			transform.position = Utilities.GetPosition(position, transform.position.z);
		}

		private Animator GetAnimator() {
			return GetComponent<Animator>();
		}

		private CharacterBehaviour GetBehaviour() {
			return GetComponentInChildren<CharacterBehaviour>();
		}

		// TODO: temporal
		public void Update() {
			/*if (new Rect(0, Screen.height / 2f, Screen.width, Screen.height / 2f).Contains(Input.mousePosition))
				Debug.Log("arriba");

			if (new Rect(0, 0, Screen.width, Screen.height / 2f).Contains(Input.mousePosition))
				Debug.Log("abajo");*/

			//transform.position += new Vector3(1, 0, 0);
		}

	}
	
}
