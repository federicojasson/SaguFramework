using SaguFramework;

namespace EmergenciaQuimica {
	
	public class ErlenmeyerBehaviour : ItemBehaviour {
		
		public override void OnLook() {}
		
		public override void OnPickUp() {}
		
		public override void OnSpeak() {}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {}
		
		protected override string GetDescription() {
			return "Erlenmeyer";
		}
	
	}
	
}
