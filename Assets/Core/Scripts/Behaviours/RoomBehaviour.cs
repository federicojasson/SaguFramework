using UnityEngine;

namespace SaguFramework {
	
	public class RoomBehaviour : EntityBehaviour {
		
		public override void OnWalk(float x) {
			string characterId = State.GetPlayerCharacterId();
			Game.ExecuteActions(characterId, new CharacterAction[] {
				CharacterAction.Look(x),
				CharacterAction.Walk(x)
			});
		}
		
	}
	
}
