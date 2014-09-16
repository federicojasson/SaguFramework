using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class ProtectionSuitBehaviour : ItemBehaviour {
		
		public override void OnLook() {
			string text = Language.GetText("ProtectionSuitDescription");
			AudioClip voice = Language.GetVoice("ProtectionSuitDescription");
			Game.ExecuteActions("Scientist", new CharacterAction[] {
				CharacterAction.Look(GetEntity().GetPosition().x),
				CharacterAction.Say(text, voice)
			});
		}

		public override void OnPickUp() {
			Character scientist = Objects.GetCharacters()["Scientist"];
			Vector2 scientistPosition = scientist.GetPosition();
			Vector2 scientistSize = scientist.GetSize();
			Vector2 protectionSuitPosition = GetEntity().GetPosition();

			Vector2 pickUpPosition;
			if (scientistPosition.x > protectionSuitPosition.x)
				pickUpPosition = new Vector2(protectionSuitPosition.x + 0.5f * scientistSize.x, scientistPosition.y);
			else
				pickUpPosition = new Vector2(protectionSuitPosition.x - 0.5f * scientistSize.x, scientistPosition.y);

			Game.ExecuteActions("Scientist", new CharacterAction[] {
				CharacterAction.Look(protectionSuitPosition.x),
				CharacterAction.Walk(pickUpPosition.x),
				CharacterAction.PickUp()
			}, () => {
				Game.RemoveItem("ProtectionSuit");
				Game.AddToInventory("InventoryProtectionSuit");
			});
		}
		
		protected override string GetTooltip() {
			return Language.GetText("ProtectionSuitTooltip");
		}

	}
	
}
