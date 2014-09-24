namespace SaguFramework {

	/// The behaviour of a room.
	/// All game rooms must inherit from this class.
	public sealed class RoomBehaviour : EntityBehaviour {

		public override void OnWalk(float x) {
			// Gets the player character
			string characterId = State.GetPlayerCharacter();
			Character character = Entities.GetCharacters()[characterId];
			
			// Orders the player character to walk
			character.ExecuteActions(new CharacterAction[] {
				CharacterAction.Look(x),
				CharacterAction.Walk(x)
			});
		}

	}
	
}
