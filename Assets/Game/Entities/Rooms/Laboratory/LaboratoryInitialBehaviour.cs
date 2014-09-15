using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class LaboratoryInitialBehaviour : RoomTriggerBehaviour {
		
		public override void OnCharacterEnter(Character character) {
			if (character.GetId() == "Scientist") {
				if (! State.HintExists("InitialAnimationExecuted")) {
					State.AddHint("InitialAnimationExecuted");

					string text0 = Language.GetText("ScientistInitialSpeech0");
					AudioClip voice0 = Language.GetVoice("ScientistInitialSpeech0");
					string text1 = Language.GetText("ScientistInitialSpeech1");
					AudioClip voice1 = Language.GetVoice("ScientistInitialSpeech1");
					Game.ExecuteActions("Scientist", new CharacterAction[] {
						CharacterAction.Say(text0, voice0),
						CharacterAction.Say(text1, voice1)
					});
				}
			}
		}

	}
	
}
