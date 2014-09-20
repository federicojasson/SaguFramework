using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public sealed class ScientistBehaviour : CharacterBehaviour {
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			if (inventoryItem.GetId() == "InventoryErlenmeyerWithAcid") {
				OnUseInventoryErlenmeyerWithAcid();
				return;
			}

			if (inventoryItem.GetId() == "InventoryProtectionSuit") {
				OnUseInventoryProtectionSuit();
				return;
			}
		}
		
		private void OnUseInventoryErlenmeyerWithAcid() {
			CharacterState characterState = Framework.GetPlayerCharacterState();
			
			Framework.LockInput();
			Framework.UnselectInventoryItem();
			Framework.RemoveInventoryItem("InventoryErlenmeyerWithAcid");
			Framework.AddCharacter("RedScientist", characterState);
			Framework.ChangePlayerCharacter("RedScientist");
			GetEntity().Deactivate();

			string characterId = Framework.GetPlayerCharacter();
			Speech speech = Framework.GetSpeech("OnUseErlenmeyerWithAcid");

			Framework.ExecuteActions(characterId, new CharacterAction[] {
				CharacterAction.Say(speech)
			}, () => {
				Framework.RemoveCharacter("Scientist");
				Framework.UnlockInput();
			});
		}

		private void OnUseInventoryProtectionSuit() {
			Framework.LockInput();
			Framework.UnselectInventoryItem();
			Framework.AddHint("ScientistHasProtectionSuit");
			Framework.RemoveInventoryItem("InventoryProtectionSuit");
			
			string characterId = Framework.GetPlayerCharacter();
			Speech speech = Framework.GetSpeech("OnUseProtectionSuit");
			
			Framework.ExecuteActions(characterId, new CharacterAction[] {
				CharacterAction.Say(speech)
			}, () => {
				Framework.UnlockInput();
			});
		}

	}
	
}
