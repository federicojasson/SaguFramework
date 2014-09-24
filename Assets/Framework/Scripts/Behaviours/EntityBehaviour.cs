using UnityEngine;

namespace SaguFramework {

	/// An entity's behaviour.
	/// The behaviours offer an interface to handle the different game events.
	/// They are meant to be overridden to actually implement the logic of the game.
	/// By default, all the methods are empty and are defined as virtual.
	/// This allows the developers to override only the methods they need.
	public abstract class EntityBehaviour : MonoBehaviour {

		private Entity entity; // The entity

		/// Returns the entity associated to this behaviour.
		public Entity GetEntity() {
			return entity;
		}

		/// Method called when a character enters the entity's collider.
		/// Receives the character that entered the collider.
		public virtual void OnCharacterEnter(Character character) {}

		/// Method called when the user executes the Click order on this entity.
		public virtual void OnClick() {}

		/// Method called when the user defocuses this entity.
		public virtual void OnDefocus() {}

		/// Method called when the user focuses this entity.
		public virtual void OnFocus() {}
		
		/// Method called when the user executes the Look order on this entity.
		public virtual void OnLook() {}

		/// Method called when the user executes the PickUp order on this entity.
		public virtual void OnPickUp() {}
		
		/// Method called when the entity's OnGUI function is authorized to execute.
		public virtual void OnShowGui() {}

		/// Method called when the user executes the Speak order on this entity.
		public virtual void OnSpeak() {}

		/// Method called when the user executes the UseInventoryItem order on this entity.
		/// Receives the inventory item used.
		public virtual void OnUseInventoryItem(InventoryItem inventoryItem) {}

		/// Method called when the user executes the Walk order on this entity.
		/// Receives the position's X value.
		public virtual void OnWalk(float x) {}

		/// Sets the entity associated to this behaviour.
		public void SetEntity(Entity entity) {
			this.entity = entity;
		}

	}
	
}
