namespace SaguFramework {
	
	public sealed class RoomBehaviour : EntityBehaviour {

		public override void OnWalk(float x) {
			string characterId = State.GetPlayerCharacter(); // TODO: CAREFUL
			Character character = Objects.GetCharacters()[characterId];
			character.ExecuteActions(new CharacterAction[] {
				CharacterAction.Look(x),
				CharacterAction.Walk(x)
			});
		}

	}
	
}
