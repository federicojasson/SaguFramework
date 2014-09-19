using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class ScientistBehaviour : CharacterBehaviour {
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			if (inventoryItem.GetId() == "InventoryProtectionSuit") {
				string characterId = Framework.GetPlayerCharacter();

				Framework.LockInput();
				Framework.AddHint("ScientistHasProtectionSuit");
				Framework.RemoveInventoryItem("InventoryProtectionSuit");

				Speech speech = Framework.GetSpeech("OnUseProtectionSuit");

				Framework.ExecuteActions(characterId, new CharacterAction[] {
					CharacterAction.Say(speech)
				}, () => {
					Framework.UnlockInput();
				});
			}
		}

	}
	
}
