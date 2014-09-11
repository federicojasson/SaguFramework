using SaguFramework;

namespace EmergenciaQuimica {
	
	public class ScientistBehaviour : CharacterBehaviour {

		public override void OnLook() {}

		public override void OnSpeak() {}

		public override void OnUseInventoryItem(InventoryItem inventoryItem) {}

		protected override string GetTooltip() {
			return "";
		}
		
	}
	
}
