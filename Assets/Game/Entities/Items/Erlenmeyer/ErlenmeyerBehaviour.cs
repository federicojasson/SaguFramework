using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class ErlenmeyerBehaviour : ItemBehaviour {
		
		public override void OnLook() {
			Game.LookAndDescribe(GetEntity(), "ErlenmeyerDescription");
		}
		
		public override void OnPickUp() {
			Game.PickUp(GetEntity(), "Erlenmeyer", "InventoryErlenmeyer");
		}
		
		public override void OnSpeak() {
			Game.LookAndNegate(GetEntity());
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			Game.LookAndNegate(GetEntity());
		}

		protected override string GetTooltip() {
			return Framework.GetText("ErlenmeyerTooltip");
		}
		
	}
	
}
