using UnityEngine;

namespace SaguFramework {
	
	public class RoomBehaviour : EntityBehaviour {
		
		public override void OnWalk(Vector2 position) {
			string characterId = State.GetPlayerCharacterId();
			Character character = Objects.GetCharacters()[characterId];
			character.ExecuteActions(new CharacterAction[] {
				CharacterAction.Walk(position)
			});
		}
		
	}
	
}
