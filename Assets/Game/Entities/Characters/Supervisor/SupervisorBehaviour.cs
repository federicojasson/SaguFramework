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
			float characterWidth = character.GetSize().x;
			float characterX = character.GetPosition().x;
			Entity entity = GetEntity();
			float entityWidth = entity.GetSize().x;
			float entityX = entity.GetPosition().x;
			
			float x0;
			if (characterX > entityX)
				x0 = entityX + 0.5f * (entityWidth + characterWidth);
			else
				x0 = entityX - 0.5f * (entityWidth + characterWidth);
			
			float x1 = entityX;
			
			Framework.ExecuteActions(characterId, new CharacterAction[] {
				CharacterAction.Look(x0),
				CharacterAction.Walk(x0),
				CharacterAction.Look(x1)
			}, () => {
				float x2 = character.GetPosition().x;
				Speech speech = Game.GetSupervisorGreeting();
				
				Framework.ExecuteActions("Supervisor", new CharacterAction[] {
					CharacterAction.Look(x2),
					CharacterAction.Say(speech)
				});
			});
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			if (inventoryItem.GetId() == "InventoryErlenmeyer") {
				OnUseInventoryErlenmeyer();
				return;
			}

			Game.LookAndNegate(GetEntity());
		}

		protected override string GetTooltip() {
			return Framework.GetText("SupervisorTooltip");
		}

		private void OnUseInventoryErlenmeyer() {
			string characterId = Framework.GetPlayerCharacter();
			Character character = Framework.GetCharacter(characterId);
			float characterWidth = character.GetSize().x;
			float characterX = character.GetPosition().x;
			Entity entity = GetEntity();
			float entityWidth = entity.GetSize().x;
			float entityX = entity.GetPosition().x;
			
			float x0;
			if (characterX > entityX)
				x0 = entityX + 0.5f * (entityWidth + characterWidth);
			else
				x0 = entityX - 0.5f * (entityWidth + characterWidth);
			
			float x1 = entityX;
			
			Framework.ExecuteActions(characterId, new CharacterAction[] {
				CharacterAction.Look(x0),
				CharacterAction.Walk(x0),
				CharacterAction.Look(x1)
			}, () => {
				Framework.LockInput();
				Framework.UnselectInventoryItem();
				
				float x2 = character.GetPosition().x;
				
				Framework.ExecuteActions("Supervisor", new CharacterAction[] {
					CharacterAction.Look(x2)
				});
				
				Speech speech0 = Framework.GetSpeech("AskAcid");
				
				Framework.ExecuteActions(characterId, new CharacterAction[] {
					CharacterAction.Say(speech0)
				}, () => {
					Speech speech1 = Framework.GetSpeech("AskAcidResponse");
					
					Framework.ExecuteActions("Supervisor", new CharacterAction[] {
						CharacterAction.Say(speech1)
					}, () => {
						Framework.ExecuteActions("Supervisor", new CharacterAction[] {
							CharacterAction.PickUp()
						});
						
						Framework.ExecuteActions(characterId, new CharacterAction[] {
							CharacterAction.PickUp()
						}, () => {
							Framework.RemoveInventoryItem("InventoryErlenmeyer");
							Framework.AddInventoryItem("InventoryErlenmeyerWithAcid");
							Framework.UnlockInput();
						});
					});
				});
			});
		}

	}
	
}
