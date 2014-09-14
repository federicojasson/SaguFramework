using UnityEngine;

namespace SaguFramework {
	
	public abstract class RoomTriggerBehaviour : EntityBehaviour {
		
		public override void OnDefocus() {
			GraphicHandler.ClearTooltip();
		}
		
		public override void OnFocus() {
			GraphicHandler.SetTooltip(GetTooltip());
		}

		public override void OnWalk(Vector2 position) {
			string characterId = State.GetPlayerCharacterId();
			Game.ExecuteActions(characterId, new CharacterAction[] {
				CharacterAction.Walk(position)
			});
		}
		
		protected virtual string GetTooltip() {
			return string.Empty;
		}
		
	}
	
}
