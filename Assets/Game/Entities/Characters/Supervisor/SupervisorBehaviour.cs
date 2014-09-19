using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class SupervisorBehaviour : CharacterBehaviour {
		
		public override void OnLook() {
			Game.LookAndDescribe(GetEntity(), "SupervisorDescription");
		}
		
		public override void OnPickUp() {
			Game.LookAndNegate(GetEntity());
		}
		
		public override void OnSpeak() {
			string characterId = Framework.GetPlayerCharacter();
			Character character = Framework.GetCharacter(characterId);
			
			Game.ApproachToSpeak(GetEntity());
			
			// TODO
			float x = character.GetPosition().x;
			Speech speech = ;
			
			Framework.ExecuteActions("Supervisor", new CharacterAction[] {
				CharacterAction.Look(x),
				CharacterAction.Say(speech)
			});
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			// TODO
		}

		protected override string GetTooltip() {
			return Framework.GetText("SupervisorTooltip");
		}

	}
	
}
