using UnityEngine;

namespace SaguFramework {

	/// The behaviour of an entity.
	/// Behaviours offer an interface to handle the different game events.
	/// They are meant to be overridden to actually implement the logic of the game.
	/// By default, all the methods are empty and are defined as virtual.
	/// This allows the developers to override only the methods they need.
	public abstract class EntityBehaviour : MonoBehaviour {

		private Entity entity; // The entity

		/// Returns the entity associated with this behaviour.
		public Entity GetEntity() {
			return entity;
		}

		/// Method invoked when a character enters the entity's collider.
		/// Receives the character that triggered the event.
		public virtual void OnCharacterEnter(Character character) {}

		/// Method invoked when the Click order is executed on this entity.
		public virtual void OnClick() {}

		/// Method invoked when the entity is defocused.
		public virtual void OnDefocus() {}

		/// Method invoked when the entity is focused.
		public virtual void OnFocus() {}
		
		/// Method invoked when the Look order is executed on this entity.
		public virtual void OnLook() {}

		/// Method invoked when the PickUp order is executed on this entity.
		public virtual void OnPickUp() {}
		
		/// Method invoked when the entity's OnGUI function is authorized to execute.
		public virtual void OnShowGui() {}

		/// Method invoked when the Speak order is executed on this entity.
		public virtual void OnSpeak() {}

		/// Method invoked when the UseInventoryItem order is executed on this entity.
		/// Receives the used inventory item.
		public virtual void OnUseInventoryItem(InventoryItem inventoryItem) {}

		/// Method called when the Walk order is executed on this entity.
		/// Receives the X value in world space.
		public virtual void OnWalk(float x) {}

		/// Sets the entity associated with this behaviour.
		public void SetEntity(Entity entity) {
			this.entity = entity;
		}

	}
	
}
