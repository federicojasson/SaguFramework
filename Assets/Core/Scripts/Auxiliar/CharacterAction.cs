using UnityEngine;

namespace SaguFramework {
	
	public class CharacterAction {

		public static CharacterAction Look(Vector2 position) {
			return new CharacterAction(CharacterActionId.Look, position);
		}

		public static CharacterAction PickUp() {
			return new CharacterAction(CharacterActionId.PickUp);
		}

		public static CharacterAction Say(string text, AudioClip voice) {
			return new CharacterAction(CharacterActionId.Say, text, voice);
		}

		public static CharacterAction Walk(Vector2 position) {
			return new CharacterAction(CharacterActionId.Walk, position);
		}
		
		private CharacterActionId id;
		private object[] parameters;

		private CharacterAction(CharacterActionId id, params object[] parameters) {
			this.id = id;
			this.parameters = parameters;
		}

		public CharacterActionId GetId() {
			return id;
		}

		public object[] GetParameters() {
			return parameters;
		}

	}
	
}
