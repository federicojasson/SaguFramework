using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class LaboratoryMiddleBehaviour : RoomTriggerBehaviour {

		public override void OnCharacterEnter(Character character) {
			string characterId = Framework.GetPlayerCharacter();

			if (character.GetId() == characterId) {
				if (! Framework.HintExists("ScientistHasProtectionSuit")) {
					Framework.LockInput();
					Framework.StopActions(characterId);

					float x0 = character.GetPosition().x;
					float x1 = Geometry.GameToWorldX(0.6f);
					Speech speech0 = Framework.GetSpeech("NeedProtectionSuit");

					Framework.ExecuteActions("Supervisor", new CharacterAction[] {
						CharacterAction.Look(x0),
						CharacterAction.Walk(x1),
						CharacterAction.Say(speech0)
					}, () => {
						float x2 = Geometry.GameToWorldX(1.2f);

						Framework.ExecuteActions("Supervisor", new CharacterAction[] {
							CharacterAction.Look(x2),
							CharacterAction.Walk(x2)
						});

						float x3 = Geometry.GameToWorldX(0.2f);
						Speech speech1 = Framework.GetSpeech("NeedProtectionSuitResponse");

						Framework.ExecuteActions(characterId, new CharacterAction[] {
							CharacterAction.Look(x3),
							CharacterAction.Walk(x3),
							CharacterAction.Say(speech1)
						}, () => {
							Framework.UnlockInput();
						});
					});
				}
			}
		}

	}
	
}
