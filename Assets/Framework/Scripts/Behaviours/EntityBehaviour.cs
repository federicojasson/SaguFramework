using UnityEngine;

namespace SaguFramework {

	// TODO: comentar

	public abstract class EntityBehaviour : MonoBehaviour {

		private Entity entity;

		public Entity GetEntity() {
			return entity;
		}

		public virtual void OnCharacterEnter(Character character) {}
		
		public virtual void OnClick() {}

		public virtual void OnDefocus() {}

		public virtual void OnFocus() {}

		public virtual void OnLook() {}
		
		public virtual void OnPickUp() {}

		public virtual void OnShowGui() {}

		public virtual void OnSpeak() {}
		
		public virtual void OnUseInventoryItem(InventoryItem inventoryItem) {}

		public virtual void OnWalk(float x) {}

		public void SetEntity(Entity entity) {
			this.entity = entity;
		}

	}
	
}
