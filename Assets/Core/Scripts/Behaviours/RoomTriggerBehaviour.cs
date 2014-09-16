using UnityEngine;

namespace SaguFramework {
	
	public abstract class RoomTriggerBehaviour : EntityBehaviour {
		
		public override void OnDefocus() {
			GraphicHandler.ClearTooltip();
		}
		
		public override void OnFocus() {
			GraphicHandler.SetTooltip(GetTooltip());
		}

		public override void OnWalk(float x) {
			string characterId = State.GetPlayerCharacterId();
			Game.ExecuteActions(characterId, new CharacterAction[] {
				CharacterAction.Look(x),
				CharacterAction.Walk(x)
			});
		}
		
		protected virtual string GetTooltip() {
			return string.Empty;
		}
		
	}
	
}
