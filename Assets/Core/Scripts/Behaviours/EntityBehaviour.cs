using UnityEngine;

namespace SaguFramework {
	
	public abstract class EntityBehaviour : MonoBehaviour {
		
		public virtual void OnCharacterEnter(Character character) {}
		
		public virtual void OnClick() {}

		public virtual void OnDefocus() {}

		public virtual void OnFocus() {}

		public virtual void OnLook() {}
		
		public virtual void OnPickUp() {}

		public virtual void OnShowGui() {}

		public virtual void OnSpeak() {}
		
		public virtual void OnUseInventoryItem(InventoryItem inventoryItem) {}

		public virtual void OnWalk(Vector2 position) {}

	}
	
}
