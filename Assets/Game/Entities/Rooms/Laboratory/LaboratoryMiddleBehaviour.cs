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

					Vector2 characterPosition = character.GetPosition();
					string text = Language.GetText(""); // TODO: Antes de comenzar a trabajar debes ponerte el traje de proteccion
					AudioClip voice = Language.GetVoice(""); // TODO
					Game.ExecuteActions("Supervisor", new CharacterAction[] {
						CharacterAction.Look(characterPosition),
						CharacterAction.Say(text, voice)
					}, () => {
						string scientistText = Language.GetText(""); // TODO: Tendre que encontrar el traje de proteccion
						AudioClip scientistVoice = Language.GetVoice(""); // TODO
						Game.ExecuteActions("Scientist", new CharacterAction[] {
							CharacterAction.Say(scientistText, scientistVoice)
						});
					});
				}
			}
		}

	}
	
}
