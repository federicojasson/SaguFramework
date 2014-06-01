using System.Collections;
using UnityEngine;

public partial class CharacterBehaviour : InteractiveObject {

	private void ExecuteLook(object[] parameters) {
		// Parses the parameters
		Vector2 position = (Vector2) parameters[0];

		StartCoroutine("ExecuteLookCoroutine", position);
	}

	private IEnumerator ExecuteLookCoroutine(Vector2 position) {
		bool facingLeft = transform.position.x > position.x;
		GetComponent<Animator>().SetBool(C.CHARACTER_CONTROLLER_FACING_LEFT, facingLeft);
		
		OnScheduledActionFinished();

		yield break;
	}

	private void ExecuteSay(object[] parameters) {
		// Parses the parameters
		string text = (string) parameters[0];

		StartCoroutine("ExecuteSayCoroutine", text);
	}

	private IEnumerator ExecuteSayCoroutine(string text) {
		// TODO
		
		OnScheduledActionFinished();
		
		yield break;
	}

	private void ExecuteWalk(object[] parameters) {
		// Parses the parameters
		Vector2 position = (Vector2) parameters[0];

		StartCoroutine("ExecuteWalkCoroutine", position);
	}
	
	private IEnumerator ExecuteWalkCoroutine(Vector2 position) {
		Animator animator = GetComponent<Animator>();
		animator.SetBool(C.CHARACTER_CONTROLLER_IS_WALKING, true);

		float walkingSpeed = Parser.StringToFloat(ConfigurationManager.GetConfiguration(C.CONFIGURATION_ID_WALKING_SPEED));
		
		float positionX = position.x;
		float currentX = transform.position.x;

		while (! CoordinatesManager.AreEqualX(currentX, positionX, C.DELTA_WALK)) {
			rigidbody2D.velocity = new Vector2(Mathf.Sign(positionX - currentX) * walkingSpeed, 0);
			yield return new WaitForFixedUpdate();
			
			float previousX = currentX;
			currentX = transform.position.x;
			
			if (CoordinatesManager.AreEqualX(previousX, currentX, C.DELTA_EQUAL))
				// The character stopped walking for some reason
				break;
		}

		animator.SetBool(C.CHARACTER_CONTROLLER_IS_WALKING, false);
		
		OnScheduledActionFinished();
		
		yield break;
	}

}
