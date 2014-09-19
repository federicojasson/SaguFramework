﻿namespace SaguFramework {
	
	public abstract class RoomTriggerBehaviour : EntityBehaviour {
		
		public override sealed void OnClick() {}
		
		public override sealed void OnDefocus() {
			Drawer.ClearTooltip();
		}
		
		public override sealed void OnFocus() {
			Drawer.SetTooltip(GetTooltip());
		}
		
		public override sealed void OnShowGui() {}
		
		public override sealed void OnWalk(float x) {
			string characterId = State.GetPlayerCharacter(); // TODO: CAREFUL
			Character character = Objects.GetCharacters()[characterId];
			character.ExecuteActions(new CharacterAction[] {
				CharacterAction.Look(x),
				CharacterAction.Walk(x)
			});
		}
		
		protected virtual string GetTooltip() {
			return string.Empty;
		}
		
	}
	
}
