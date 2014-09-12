using UnityEngine;

namespace SaguFramework {
	
	public class RoomBehaviour : EntityBehaviour {
		
		public override void OnWalk(Vector2 position) {
			string characterId = State.GetPlayerCharacterId();
			Game.Walk(characterId, position);
		}
		
	}
	
}
