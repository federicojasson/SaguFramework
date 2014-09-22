namespace SaguFramework {

	// TODO: comentar

	public sealed class RoomBehaviour : EntityBehaviour {

		public override void OnWalk(float x) {
			string characterId = State.GetPlayerCharacter();
			Character character = Objects.GetCharacters()[characterId];
			character.ExecuteActions(new CharacterAction[] {
				CharacterAction.Look(x),
				CharacterAction.Walk(x)
			});
		}

	}
	
}
