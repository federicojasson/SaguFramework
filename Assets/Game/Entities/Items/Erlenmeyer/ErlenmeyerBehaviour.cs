using SaguFramework;

namespace EmergenciaQuimica {
	
	public class ErlenmeyerBehaviour : ItemBehaviour {
		
		public override void OnLook() {
			// TODO: refactor
			/*string text = Language.GetText("ErlenmeyerDescription");
			AudioClip voice = Language.GetVoice("ErlenmeyerDescription");
			Game.ExecuteActions("Scientist", new CharacterAction[] {
				CharacterAction.Look(GetEntity().GetPosition().x),
				CharacterAction.Say(text, voice)
			});*/
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

		protected override string GetTooltip() {
			//return Language.GetText("ErlenmeyerTooltip");
			return string.Empty;
		}
		
	}
	
}
