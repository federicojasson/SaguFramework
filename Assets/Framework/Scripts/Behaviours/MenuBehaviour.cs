namespace SaguFramework {

	/// The behaviour of a menu.
	/// All game's menus must inherit from this class.
	public abstract class MenuBehaviour : EntityBehaviour {
		
		public override sealed void OnCharacterEnter(Character character) {}
		
		public override sealed void OnClick() {}
		
		public override sealed void OnDefocus() {}
		
		public override sealed void OnFocus() {}
		
		public override sealed void OnLook() {}
		
		public override sealed void OnPickUp() {}
		
		public override sealed void OnSpeak() {}
		
		public override sealed void OnUseInventoryItem(InventoryItem inventoryItem) {}
		
		public override sealed void OnWalk(float x) {}
		
	}
	
}
