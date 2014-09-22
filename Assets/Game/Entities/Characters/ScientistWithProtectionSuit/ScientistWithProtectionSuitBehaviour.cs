using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class ScientistWithProtectionSuitBehaviour : CharacterBehaviour {

		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			if (inventoryItem.GetId() == "InventoryErlenmeyerWithAcid") {
				Character character = (Character) GetEntity();
				CharacterState characterState = Framework.GetPlayerCharacterState();
				
				Framework.LockInput();
				Framework.UnselectInventoryItem();
				Framework.RemoveInventoryItem("InventoryErlenmeyerWithAcid");
				Framework.AddCharacter("RedScientist", characterState);
				Framework.ChangePlayerCharacter("RedScientist");
				character.Deactivate();
				
				string characterId = Framework.GetPlayerCharacter();
				Speech speech = Framework.GetSpeech("OnUseErlenmeyerWithAcid");
				
				Framework.ExecuteActions(characterId, new CharacterAction[] {
					CharacterAction.Say(speech)
				}, () => {
					Framework.RemoveCharacter(character.GetId());
					Framework.UnlockInput();
				});
			}
		}

	}
	
}
