namespace SaguFramework {
	
	/// The behaviour of a room trigger.
	/// All game's room triggers must inherit from this class.
	public abstract class RoomTriggerBehaviour : EntityBehaviour {
		
		public override sealed void OnClick() {}
		
		public override sealed void OnDefocus() {
			// Clears the tooltip
			Drawer.ClearTooltip();
		}
		
		public override sealed void OnFocus() {
			// Sets the tooltip
			Drawer.SetTooltip(GetTooltip());
		}
		
		public override sealed void OnShowGui() {}
		
		public override sealed void OnWalk(float x) {
			// Gets the player character
			string characterId = State.GetPlayerCharacter();
			Character character = Entities.GetCharacters()[characterId];

			// Orders the player character to walk
			character.ExecuteActions(new CharacterAction[] {
				CharacterAction.Look(x),
				CharacterAction.Walk(x)
			});
		}
		
		/// Returns the room's tooltip.
		protected virtual string GetTooltip() {
			// By default, the tooltip is empty (so it won't show)
			return string.Empty;
		}
		
	}
	
}
