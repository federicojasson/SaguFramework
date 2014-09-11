using UnityEngine;

namespace SaguFramework {
	
	public abstract class Entity : MonoBehaviour {
		
		private EntityBehaviour behaviour;
		private new BoxCollider2D collider;

		public void Awake() {
			collider = gameObject.AddComponent<BoxCollider2D>();
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

		public void Hide() {
			gameObject.SetActive(false);
		}

		public bool IsShowing() {
			return gameObject.activeInHierarchy;
		}

		public void OnDestroy() {
			Objects.UnregisterEntity(this);
		}

		public void OnGUI() {
			GUI.skin = Parameters.GetSkin();
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

		public void Register() {
			Objects.RegisterEntity(this);
		}

		public void SetBehaviour(EntityBehaviour behaviour) {
			this.behaviour = behaviour;
		}

		public void SetPosition(Vector2 position) {
			transform.position = Utilities.GetPosition(position, transform.position.z);
		}

		public void SetSize(Vector2 size) {
			collider.size = size;
		}

		public void Show() {
			gameObject.SetActive(true);
		}

	}
	
}
