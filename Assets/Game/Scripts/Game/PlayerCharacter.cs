using System.Collections;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

	public float walkSpeed = 2;

	public void Say(Speech speech) {
		GetComponent<Animator>().SetBool("IsSaying", true);

		Vector2 position = Utility.FromWorldToViewportPosition((Vector2) transform.position + new Vector2(0, GetComponent<BoxCollider2D>().size.y / 2) + P.OFFSET_SPEECH_TEXT);
		Factory.GetSpeechText(speech.GetText(), position);

		audio.clip = speech.GetAudio();
		audio.Play();
		
		Invoke("SayCallback", audio.clip.length);
	}
	
	private void SayCallback() {
		Factory.DisposeSpeechText();
		audio.Stop();

		GetComponent<Animator>().SetBool("IsSaying", false);
	}

	public void Walk(Vector2 position) {
		StopCoroutine("WalkCoroutine");
		StartCoroutine("WalkCoroutine", position);
	}

	private IEnumerator WalkCoroutine(Vector2 position) {
		GetComponent<Animator>().SetBool("IsWalking", true);

		float positionX = position.x;
		float currentX = transform.position.x;

		while (! Utility.AreEqual(currentX, positionX, P.DELTA_WALK)) {
			rigidbody2D.velocity = new Vector2(Mathf.Sign(positionX - currentX) * walkSpeed, 0);
			yield return new WaitForFixedUpdate();
			
			float previousX = currentX;
			currentX = transform.position.x;
			
			if (Utility.AreEqual(previousX, currentX, P.DELTA_EQUAL))
				// The character stopped walking for some reason
				break;
		}
		
		GetComponent<Animator>().SetBool("IsWalking", false);
	}

}
