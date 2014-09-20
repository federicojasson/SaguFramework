using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public static class Game {

		public static void Describe(string speechId) {
			string characterId = Framework.GetPlayerCharacter();
			Speech speech = Framework.GetSpeech(speechId);
			
			Framework.ExecuteActions(characterId, new CharacterAction[] {
				CharacterAction.Say(speech)
			});
		}

		public static Speech GetSupervisorGreeting() {
			Speech[] greetingSpeeches = new Speech[] {
				Framework.GetSpeech("SupervisorGreeting0"),
				Framework.GetSpeech("SupervisorGreeting1")
			};
			
			int randomIndex = Random.Range(0, greetingSpeeches.Length);
			
			return greetingSpeeches[randomIndex];
		}

		public static void LookAndDescribe(Entity entity, string speechId) {
			string characterId = Framework.GetPlayerCharacter();
			float x = entity.GetPosition().x;
			Speech speech = Framework.GetSpeech(speechId);

			Framework.ExecuteActions(characterId, new CharacterAction[] {
				CharacterAction.Look(x),
				CharacterAction.Say(speech)
			});
		}

		public static void LookAndNegate(Entity entity) {
			string characterId = Framework.GetPlayerCharacter();
			float x = entity.GetPosition().x;
			Speech speech = Game.GetNegationSpeech();
			
			Framework.ExecuteActions(characterId, new CharacterAction[] {
				CharacterAction.Look(x),
				CharacterAction.Say(speech)
			});
		}
		
		public static void Negate() {
			string characterId = Framework.GetPlayerCharacter();
			Speech speech = Game.GetNegationSpeech();
			
			Framework.ExecuteActions(characterId, new CharacterAction[] {
				CharacterAction.Say(speech)
			});
		}

		public static void PickUp(Entity entity, string itemId, string inventoryItemId) {
			string characterId = Framework.GetPlayerCharacter();
			Character character = Framework.GetCharacter(characterId);
			float characterWidth = character.GetSize().x;
			float characterX = character.GetPosition().x;
			float entityX = entity.GetPosition().x;
			
			float x0;
			if (characterX > entityX)
				x0 = entityX + 0.5f * characterWidth;
			else
				x0 = entityX - 0.5f * characterWidth;
			
			float x1 = entityX;
			
			Framework.ExecuteActions(characterId, new CharacterAction[] {
				CharacterAction.Look(x0),
				CharacterAction.Walk(x0),
				CharacterAction.Look(x1)
			}, () => {
				Framework.LockInput();
				
				Framework.ExecuteActions(characterId, new CharacterAction[] {
					CharacterAction.PickUp()
				}, () => {
					Framework.RemoveItem(itemId);
					Framework.AddInventoryItem(inventoryItemId);
					
					Framework.UnlockInput();
				});
			});
		}

		public static void TryChangeRoom(Character character, string roomId, string entryId) {
			if (character.GetId() == Framework.GetPlayerCharacter()) {
				Framework.LockInput();
				Framework.ChangeRoom(roomId, entryId, "Molecules");
			}
		}
		
		private static Speech GetNegationSpeech() {
			Speech[] negationSpeeches = new Speech[] {
				Framework.GetSpeech("NegationSpeech0"),
				Framework.GetSpeech("NegationSpeech1"),
				Framework.GetSpeech("NegationSpeech2")
			};
			
			int randomIndex = Random.Range(0, negationSpeeches.Length);
			
			return negationSpeeches[randomIndex];
		}

	}
	
}
