using System.Collections;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

	public float walkSpeed = 2;

	public void Walk(float x) {
		GetComponent<Animator>().SetBool("IsWalking", true);
		StopCoroutine("WalkCoroutine");
		StartCoroutine("WalkCoroutine", x);
	}

	private IEnumerator WalkCoroutine(float x) {
		while (! Utility.AreEqual(transform.position.x, x)) {
			rigidbody2D.velocity = new Vector2(Mathf.Sign(x - transform.position.x) * walkSpeed, 0);
			yield return null;
		}

		GetComponent<Animator>().SetBool("IsWalking", false);
	}

}
