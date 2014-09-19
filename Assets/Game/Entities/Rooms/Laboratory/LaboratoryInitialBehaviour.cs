using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class LaboratoryInitialBehaviour : RoomTriggerBehaviour {
		
		public override void OnCharacterEnter(Character character) {
			string characterId = Framework.GetPlayerCharacter();

			if (character.GetId() == characterId)
				if (! Framework.HintExists("ScientistGaveInitialSpeech")) {
					Framework.LockInput();
					Framework.AddHint("ScientistGaveInitialSpeech");
					
					Speech speech0 = Framework.GetSpeech("InitialSpeech0");
					Speech speech1 = Framework.GetSpeech("InitialSpeech1");
					
					Framework.ExecuteActions(characterId, new CharacterAction[] {
						CharacterAction.Say(speech0),
						CharacterAction.Say(speech1)
					}, () => {
						Framework.UnlockInput();
					});
				}
		}

	}
	
}
