using UnityEngine;

namespace SaguFramework {
	
	public abstract class Entity : MonoBehaviour {
		
		private EntityBehaviour behaviour;
		private new BoxCollider2D collider;
		private new Rigidbody2D rigidbody;
		
		public void Activate() {
			gameObject.SetActive(true);
		}

		public virtual void Awake() {
			collider = gameObject.AddComponent<BoxCollider2D>();
			rigidbody = gameObject.AddComponent<Rigidbody2D>();
			rigidbody.isKinematic = true;
			Deactivate();
		}
		
		public void Deactivate() {
			gameObject.SetActive(false);
		}

		public void Destroy() {
			DestroyImmediate(gameObject);
		}
		
		public EntityBehaviour GetBehaviour() {
			return behaviour;
		}

		public Vector2 GetPosition() {
			return transform.position;
		}

		public Vector2 GetSize() {
			return collider.size;
		}

		public bool IsActivated() {
			return gameObject.activeInHierarchy;
		}

		public void OnDestroy() {
			Objects.UnregisterEntity(this);
		}

		public void OnGUI() {
			InputReader.NotifyOnGUI(this);
		}
		
		public void OnMouseEnter() {
			InputReader.NotifyOnMouseEnter(this);
		}
		
		public void OnMouseExit() {
			InputReader.NotifyOnMouseExit(this);
		}
		
		public void OnMouseUpAsButton() {
			InputReader.NotifyOnMouseUpAsButton(this);
		}
		
		public void OnTriggerEnter2D(Collider2D collider) {
			InputReader.NotifyOnTriggerEnter2D(this, collider);
		}

		public void Register() {
			Objects.RegisterEntity(this);
		}

		public void SetBehaviour(EntityBehaviour behaviour) {
			this.behaviour = behaviour;
		}
		
		public void SetDepth(float depth) {
			transform.position = Utilities.GetVector3(transform.position, depth);
		}

		public void SetPosition(Vector2 position) {
			transform.position = Utilities.GetVector3(position, transform.position.z);
		}

		public void SetSize(Vector2 size) {
			collider.size = size;
		}
		
		protected BoxCollider2D GetCollider() {
			return collider;
		}

		protected Rigidbody2D GetRigidbody() {
			return rigidbody;
		}

	}
	
}
