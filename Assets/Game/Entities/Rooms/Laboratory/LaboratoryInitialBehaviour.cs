using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class LaboratoryInitialBehaviour : RoomTriggerBehaviour {
		
		public override void OnCharacterEnter(Character character) {
			if (character.GetId() == "Scientist") {
				if (! State.HintExists("InitialAnimationExecuted")) {
					State.AddHint("InitialAnimationExecuted");

					string text = Language.GetText(""); // TODO
					AudioClip voice = Language.GetVoice(""); // TODO
					Game.ExecuteActions("Scientist", new CharacterAction[] {
						CharacterAction.Say(text, voice)
					});
				}
			}
		}

	}
	
}
