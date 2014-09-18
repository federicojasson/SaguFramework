using SaguFramework;

namespace EmergenciaQuimica {
	
	public class LaboratoryInitialBehaviour : RoomTriggerBehaviour {
		
		public override void OnCharacterEnter(Character character) {
			// TODO: refactor
			/*if (character.GetId() == "Scientist") {
				if (! State.HintExists("InitialAnimationExecuted")) {
					State.AddHint("InitialAnimationExecuted");

					string text0 = Language.GetText("InitialSpeech0");
					AudioClip voice0 = Language.GetVoice("InitialSpeech0");
					string text1 = Language.GetText("InitialSpeech1");
					AudioClip voice1 = Language.GetVoice("InitialSpeech1");
					Game.ExecuteActions("Scientist", new CharacterAction[] {
						CharacterAction.Say(text0, voice0),
						CharacterAction.Say(text1, voice1)
					});
				}
			}*/
		}
		
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
			// TODO
		}

	}
	
}
