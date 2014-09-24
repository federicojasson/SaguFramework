using UnityEngine;

namespace SaguFramework {

	/// A game entity.
	/// An entity has a collider and a rigid body to interact with its environment.
	/// Also, it has an EntityBehaviour to serve the different events.
	public abstract class Entity : MonoBehaviour {
		
		private EntityBehaviour behaviour; // The entity's behaviour
		private new BoxCollider2D collider; // The entity's collider
		private new Rigidbody2D rigidbody; // The entity's rigid body

		/// Activates the entity.
		public void Activate() {
			gameObject.SetActive(true);
		}

		public virtual void Awake() {
			// Adds a collider
			collider = gameObject.AddComponent<BoxCollider2D>();

			// Adds a rigid body (kinematic)
			rigidbody = gameObject.AddComponent<Rigidbody2D>();
			rigidbody.isKinematic = true;

			// Deactivates the entity by default
			Deactivate();
		}

		/// Deactivates the entity.
		public void Deactivate() {
			gameObject.SetActive(false);
		}

		/// Destroys the entity.
		public virtual void Destroy() {
			Destroy(gameObject);
		}

		/// Returns the entity's behaviour.
		public EntityBehaviour GetBehaviour() {
			return behaviour;
		}

		/// Returns the entity's position in world space.
		public Vector2 GetPosition() {
			return transform.position;
		}

		/// Returns the entity's size in world space.
		/// This is actually the collider's size.
		public Vector2 GetSize() {
			return collider.size;
		}

		/// Determines whether the entity is activated.
		public bool IsActivated() {
			return gameObject.activeInHierarchy;
		}

		public void OnDestroy() {
			// Unregisters the entity
			Entities.UnregisterEntity(this);
		}

		public void OnGUI() {
			// Notifies the InputReader that the OnGUI method has been invoked
			InputReader.NotifyOnGUI(this);
		}
		
		public void OnMouseEnter() {
			// Notifies the InputReader that the OnMouseEnter method has been invoked
			InputReader.NotifyOnMouseEnter(this);
		}
		
		public void OnMouseExit() {
			// Notifies the InputReader that the OnMouseExit method has been invoked
			InputReader.NotifyOnMouseExit(this);
		}
		
		public void OnMouseUpAsButton() {
			// Notifies the InputReader that the OnMouseUpAsButton method has been invoked
			InputReader.NotifyOnMouseUpAsButton(this);
		}
		
		public void OnTriggerEnter2D(Collider2D collider) {
			// Notifies the InputReader that the OnTriggerEnter2D method has been invoked
			InputReader.NotifyOnTriggerEnter2D(this, collider);
		}

		/// Registers the entity with the Entities module.
		/// This method must be called after the entity is fully initialized.
		public void Register() {
			Entities.RegisterEntity(this);
		}

		/// Sets the entity's behaviour.
		public void SetBehaviour(EntityBehaviour behaviour) {
			this.behaviour = behaviour;
		}

		/// Sets the entity's depth (Z value).
		/// The depth determines which collider's mouse events gets triggered when there are several in the same
		/// position.
		public void SetDepth(float depth) {
			transform.position = Utilities.GetVector3(transform.position, depth);
		}

		/// Sets the entity's position in world space.
		public void SetPosition(Vector2 position) {
			transform.position = Utilities.GetVector3(position, transform.position.z);
		}

		/// Sets the entity's size in world space.
		public void SetSize(Vector2 size) {
			collider.size = size;
		}

		/// Returns the entity's collider.
		protected BoxCollider2D GetCollider() {
			return collider;
		}

		/// Returns the entity's rigid body.
		protected Rigidbody2D GetRigidbody() {
			return rigidbody;
		}

	}
	
}
