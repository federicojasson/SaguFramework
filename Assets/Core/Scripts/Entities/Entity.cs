using UnityEngine;

namespace SaguFramework {
	
	public abstract class Entity : MonoBehaviour {
		
		private EntityBehaviour behaviour;
		private new BoxCollider2D collider;

		public virtual void Awake() { // TODO: virtual?
			collider = gameObject.AddComponent<BoxCollider2D>();
			/*Rigidbody2D rigidbody = gameObject.AddComponent<Rigidbody2D>();
			rigidbody.isKinematic = true;*/
			Hide();
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
			GUILayout.BeginArea(Geometry.GetGameRectangleInGui()); {
				InputHandler.NotifyOnGUI(this);
			} GUILayout.EndArea();
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
			Debug.Log("TRIGGER ACTIVATED");
			//InputHandler.NotifyOnTriggerEnter2D(this, collider); TODO
		}

		public void Register() {
			Objects.RegisterEntity(this);
		}

		public void SetBehaviour(EntityBehaviour behaviour) {
			this.behaviour = behaviour;
		}
		
		public void SetDepth(float depth) {
			transform.position = Utilities.GetPosition(transform.position, depth);
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
