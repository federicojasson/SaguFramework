using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

	public void Say(Speech speech) {
		// TODO
		Debug.Log("PlayerCharacter says: " + speech.GetText());
	}

	public void Walk(Vector2 position) {
		// TODO
		Debug.Log("PlayerCharacters walks: " + position);
	}

}

/*using System.Collections;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

	public float walkSpeed = 2;

	public void Say(Speech speech) {
		// TODO
		Debug.Log("PlayerCharacter says: " + speech.text);
		Factory.GetSpeechText(speech.text, Utility.ToVector2(Camera.main.WorldToViewportPoint(transform.position + new Vector3(0, GetComponent<BoxCollider2D>().size.y / 2, 0) + P.OFFSET_SPEECH_TEXT)));

		audio.clip = speech.audio;
		audio.Play();

		Invoke("Test", speech.text.Length * 0.053f); // TODO: constant
	}

	private void Test() {
		Debug.Log("invoked");
		Factory.DisposeSpeechText();
		audio.Stop();
	}

	public void Walk(Vector2 target) {
		StopCoroutine("WalkCoroutine");
		StartCoroutine("WalkCoroutine", target);
	}

	private IEnumerator WalkCoroutine(Vector2 target) {
		GetComponent<Animator>().SetBool("IsWalking", true);

		float targetX = target.x;
		float currentX = transform.position.x;
		while (! Utility.AreEqual(currentX, targetX, P.DELTA_WALK)) {
			rigidbody2D.velocity = new Vector2(Mathf.Sign(targetX - currentX) * walkSpeed, 0);
			yield return new WaitForFixedUpdate();

			float previousX = currentX;
			currentX = transform.position.x;

			if (Utility.AreEqual(previousX, currentX, P.DELTA_EQUAL))
				// The character stopped walking for some reason
				break;
		}

		GetComponent<Animator>().SetBool("IsWalking", false);
	}

}*/
