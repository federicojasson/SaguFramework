using SaguFramework;

namespace EmergenciaQuimica {
	
	public class ScientistBehaviour : CharacterBehaviour {
		
		public override void OnLook() {
			// TODO
		}
		
		public override void OnPickUp() {
			// TODO
		}
		
		public override void OnSpeak() {
			// TODO
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			// TODO: refactor
			/*string inventoryItemId = inventoryItem.GetId();

			if (inventoryItemId == "InventoryProtectionSuit") {
				// TODO: dejar de usar objeto

				State.AddHint("ScientistHasProtectionSuit");
				Game.RemoveFromInventory("InventoryProtectionSuit");

				string text = Language.GetText("OnUseProtectionSuit");
				AudioClip voice = Language.GetVoice("OnUseProtectionSuit");

				Game.LockGame();
				Game.ExecuteActions("Scientist", new CharacterAction[] {
					CharacterAction.Say(text, voice)
				}, () => {
					Game.UnlockGame();
				});
			}*/
		}

	}
	
}
