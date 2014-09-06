﻿using UnityEngine;

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
			//transform.position += new Vector3(1, 0, 0);
		}

	}
	
}
