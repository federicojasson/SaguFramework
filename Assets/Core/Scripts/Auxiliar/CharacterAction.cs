﻿namespace SaguFramework {
	
	public sealed class CharacterAction {

		public static CharacterAction Look(float x) {
			return new CharacterAction(CharacterActionId.Look, x);
		}
		
		public static CharacterAction LookAndPickUp(float x) {
			return new CharacterAction(CharacterActionId.LookAndPickUp, x);
		}
		
		public static CharacterAction LookAndSay(float x, Speech speech) {
			return new CharacterAction(CharacterActionId.LookAndSay, x, speech);
		}
		
		public static CharacterAction LookAndWalk(float x) {
			return new CharacterAction(CharacterActionId.LookAndWalk, x);
		}

		public static CharacterAction PickUp() {
			return new CharacterAction(CharacterActionId.PickUp);
		}

		public static CharacterAction Say(Speech speech) {
			return new CharacterAction(CharacterActionId.Say, speech);
		}

		public static CharacterAction Walk(float x) {
			return new CharacterAction(CharacterActionId.Walk, x);
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
