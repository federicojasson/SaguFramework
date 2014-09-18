using SaguFramework;

namespace EmergenciaQuimica {
	
	public class LaboratoryMiddleBehaviour : RoomTriggerBehaviour {

		public override void OnCharacterEnter(Character character) {
			// TODO: refactor
			/*if (character.GetId() == "Scientist") {
				if (! State.HintExists("ScientistHasProtectionSuit")) {
					Game.LockGame();

					// TODO: order

					// TODO: supervisor says something
					Game.StopActions("Scientist");
					
					Vector2 scientistPosition = Objects.GetCharacters()["Scientist"].GetPosition();
					Vector2 supervisorPosition = Objects.GetCharacters()["Supervisor"].GetPosition();
					string text = Language.GetText("NeedProtectionSuit");
					AudioClip voice = Language.GetVoice("NeedProtectionSuit");
					Game.ExecuteActions("Supervisor", new CharacterAction[] {
						CharacterAction.Look(scientistPosition.x),
						CharacterAction.Walk(Geometry.GameToWorldX(0.6f)),
						CharacterAction.Say(text, voice)
					}, () => {
						Game.ExecuteActions("Supervisor", new CharacterAction[] {
							CharacterAction.Look(supervisorPosition.x),
							CharacterAction.Walk(supervisorPosition.x)
						});

						string scientistText = Language.GetText("NeedProtectionSuitResponse");
						AudioClip scientistVoice = Language.GetVoice("NeedProtectionSuitResponse");
						Game.ExecuteActions("Scientist", new CharacterAction[] {
							CharacterAction.Look(Geometry.GameToWorldX(0.2f)),
							CharacterAction.Walk(Geometry.GameToWorldX(0.2f)),
							CharacterAction.Say(scientistText, scientistVoice)
						}, () => {
							Game.UnlockGame();
						});
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
