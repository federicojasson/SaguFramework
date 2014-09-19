using SaguFramework;

namespace EmergenciaQuimica {
	
	public class SupervisorBehaviour : CharacterBehaviour {
		
		public override void OnLook() {
			// TODO: description
		}
		
		public override void OnPickUp() {
			// TODO: negation
		}
		
		public override void OnSpeak() {
			// TODO
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			// TODO
		}

		protected override string GetTooltip() {
			//return Language.GetText("SupervisorTooltip");
			return string.Empty;
		}

	}
	
}
