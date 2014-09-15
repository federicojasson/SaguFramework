using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class ErlenmeyerBehaviour : ItemBehaviour {

		public override void OnLook() {
			string text = Language.GetText("ErlenmeyerOnLook");
			AudioClip voice = Language.GetVoice("ErlenmeyerOnLook");
			Game.ExecuteActions("Scientist", new CharacterAction[] {
				CharacterAction.Say(text, voice)
			});
		}

		protected override string GetTooltip() {
			return Language.GetText("ErlenmeyerTooltip");
		}
		
	}
	
}
