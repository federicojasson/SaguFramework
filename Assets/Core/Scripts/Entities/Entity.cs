using UnityEngine;

namespace SaguFramework {
	
	public abstract class Entity : MonoBehaviour {
		
		private EntityBehaviour behaviour;

		public void Awake() {
			Objects.RegisterEntity(this);
		}
		
		public EntityBehaviour GetBehaviour() {
			return behaviour;
		}

		public Vector2 GetPosition() {
			return transform.position;
		}

		public Vector2 GetSize() {
			// TODO
			return new Vector2();
		}

		public bool IsShowing() {
			return gameObject.activeInHierarchy;
		}

		public void OnDestroy() {
			Objects.UnregisterEntity(this);
		}

		public void OnGUI() {
			InputHandler.NotifyOnGUI(this);
		}
		
		public void OnMouseEnter() {
			InputHandler.NotifyOnMouseEnter(this);
		}
		
		public void OnMouseExit() {
			InputHandler.NotifyOnMouseExit(this);
		}
		
		public void OnMouseUpAsButton() {
			InputHandler.NotifyOnMouseUpAsButton(this);
		}
		
		public void OnTriggerEnter2D(Collider2D collider) {
			InputHandler.NotifyOnTriggerEnter2D(this, collider);
		}

		public void SetBehaviour(EntityBehaviour behaviour) {
			this.behaviour = behaviour;
		}

		public void SetPosition(Vector2 position) {
			// TODO
		}

		public void SetSize(Vector2 size) {
			// TODO
		}

	}
	
}
