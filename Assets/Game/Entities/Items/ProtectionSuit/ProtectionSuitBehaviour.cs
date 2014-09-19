using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class ProtectionSuitBehaviour : ItemBehaviour {
		
		public override void OnLook() {
			Game.LookAndDescribe(GetEntity(), "ProtectionSuitDescription");
		}

		public override void OnPickUp() {
			string characterId = Framework.GetPlayerCharacter();

			Game.ApproachToPickUp(GetEntity());
			Framework.LockInput();
			
			Framework.ExecuteActions(characterId, new CharacterAction[] {
				CharacterAction.PickUp()
			}, () => {
				Framework.RemoveItem("ProtectionSuit");
				Framework.AddInventoryItem("InventoryProtectionSuit");
				
				Framework.UnlockInput();
			});
		}
		
		public override void OnSpeak() {
			Game.LookAndNegate(GetEntity());
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			Game.LookAndNegate(GetEntity());
		}
		
		protected override string GetTooltip() {
			return Framework.GetText("ProtectionSuitTooltip");
		}

	}
	
}
