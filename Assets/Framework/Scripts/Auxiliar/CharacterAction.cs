namespace SaguFramework {

	/// Represents a character action.
	/// An action can receive any number of parameters.
	/// There are 4 predefined actions: Look, PickUp, Say and Walk.
	public sealed class CharacterAction {

		/// Creates and returns a Look action.
		/// Receives the X value in world space towards the character will look.
		public static CharacterAction Look(float x) {
			return new CharacterAction(CharacterActionId.Look, x);
		}

		/// Creates and returns a PickUp action.
		public static CharacterAction PickUp() {
			return new CharacterAction(CharacterActionId.PickUp);
		}

		/// Creates and returns a Say action.
		/// Receives the speech that the character will say.
		public static CharacterAction Say(Speech speech) {
			return new CharacterAction(CharacterActionId.Say, speech);
		}

		/// Creates and returns a Walk action.
		/// Receives the X value in world space towards the character will walk to.
		public static CharacterAction Walk(float x) {
			return new CharacterAction(CharacterActionId.Walk, x);
		}

		private CharacterActionId id; // The action's ID
		private object[] parameters; // The action's parameters

		/// Initializes a character action.
		/// Receives its ID and a variable number of parameters.
		private CharacterAction(CharacterActionId id, params object[] parameters) {
			this.id = id;
			this.parameters = parameters;
		}

		/// Returns the action's ID.
		public CharacterActionId GetId() {
			return id;
		}

		/// Returns the action's parameters.
		public object[] GetParameters() {
			return parameters;
		}

	}
	
}
