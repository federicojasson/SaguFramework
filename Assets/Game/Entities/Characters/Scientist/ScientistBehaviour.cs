using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class ScientistBehaviour : CharacterBehaviour {
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			if (inventoryItem.GetId() == "InventoryProtectionSuit") {
				Character character = (Character) GetEntity();
				CharacterState characterState = Framework.GetPlayerCharacterState();

				Framework.LockInput();
				Framework.UnselectInventoryItem();
				Framework.AddHint("ScientistHasProtectionSuit");
				Framework.RemoveInventoryItem("InventoryProtectionSuit");
				Framework.AddCharacter("ScientistWithProtectionSuit", characterState);
				Framework.ChangePlayerCharacter("ScientistWithProtectionSuit");
				Framework.RemoveCharacter(character.GetId());
				
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
	
}
