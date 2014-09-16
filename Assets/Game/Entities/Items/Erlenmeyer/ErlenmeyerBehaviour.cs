using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class ErlenmeyerBehaviour : ItemBehaviour {

		public override void OnLook() {
			string text = Language.GetText("ErlenmeyerDescription");
			AudioClip voice = Language.GetVoice("ErlenmeyerDescription");
			Game.ExecuteActions("Scientist", new CharacterAction[] {
				CharacterAction.Look(GetEntity().GetPosition().x),
				CharacterAction.Say(text, voice)
			});
		}

		protected override string GetTooltip() {
			return Language.GetText("ErlenmeyerTooltip");
		}
		
	}
	
}
