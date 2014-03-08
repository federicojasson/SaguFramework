using UnityEngine;

public class Player : MonoBehaviour {

	public float maxSpeed = 3;
	
	private Animator animator;
	private Vector2 velocity;

	public void Awake() {
		animator = GetComponent<Animator>();
	}

	public void FixedUpdate() {
		rigidbody2D.velocity = velocity;
	}

	public void Update() {
		float input = Input.GetAxis("Horizontal");
		float speed = maxSpeed * input;

		velocity = new Vector2(speed, 0);
		animator.SetFloat("Speed", speed);
	}

}
