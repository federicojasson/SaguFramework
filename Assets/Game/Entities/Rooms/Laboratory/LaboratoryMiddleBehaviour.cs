using SaguFramework;
using System;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class LaboratoryMiddleBehaviour : RoomTriggerBehaviour {

		public override void OnCharacterEnter(Character character) {
			if (character.GetId() == "Scientist") {
				if (! State.HintExists("ScientistHasProtectionSuit")) {
					// TODO: order

					// TODO: supervisor says something
					Game.StopActions("Scientist");
					
					Vector2 scientistPosition = Objects.GetCharacters()["Scientist"].GetPosition();
					Vector2 supervisorPosition = Objects.GetCharacters()["Supervisor"].GetPosition();
					string text = Language.GetText("ProtectionSuitSpeech");
					AudioClip voice = Language.GetVoice("ProtectionSuitSpeech");
					Game.ExecuteActions("Supervisor", new CharacterAction[] {
						CharacterAction.Look(scientistPosition),
						CharacterAction.Walk(new Vector2(Geometry.GameToWorldX(0.6f), supervisorPosition.y)),
						CharacterAction.Say(text, voice),
						CharacterAction.Look(supervisorPosition),
						CharacterAction.Walk(supervisorPosition)
					}, () => {
						string scientistText = Language.GetText("ProtectionSuitResponseSpeech");
						AudioClip scientistVoice = Language.GetVoice("ProtectionSuitResponseSpeech");
						Game.ExecuteActions("Scientist", new CharacterAction[] {
							CharacterAction.Look(new Vector2(Geometry.GameToWorldX(0.2f), scientistPosition.y)),
							CharacterAction.Walk(new Vector2(Geometry.GameToWorldX(0.2f), scientistPosition.y)),
							CharacterAction.Say(scientistText, scientistVoice)
						});
					});
				}
			}
		}

	}
	
}
