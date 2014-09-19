using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class ErlenmeyerBehaviour : ItemBehaviour {
		
		public override void OnLook() {
			Game.LookAndDescribe(GetEntity(), "ErlenmeyerDescription");
		}
		
		public override void OnPickUp() {
			string characterId = Framework.GetPlayerCharacter();

			Game.ApproachToPickUp(GetEntity());
			Framework.LockInput();
			
			Framework.ExecuteActions(characterId, new CharacterAction[] {
				CharacterAction.PickUp()
			}, () => {
				Framework.RemoveItem("Erlenmeyer");
				Framework.AddInventoryItem("InventoryErlenmeyer");
				
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
			return Framework.GetText("ErlenmeyerTooltip");
		}
		
	}
	
}
