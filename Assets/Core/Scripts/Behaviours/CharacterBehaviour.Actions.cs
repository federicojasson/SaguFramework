using System.Collections;
using UnityEngine;

public partial class CharacterBehaviour : InteractiveObject {

	private void ExecuteLook(object[] parameters) {
		// Parses the parameters
		Vector2 gamePoint = (Vector2) parameters[0];

		StartCoroutine("ExecuteLookCoroutine", gamePoint);
	}

	private IEnumerator ExecuteLookCoroutine(Vector2 gamePoint) {
		bool facingLeft = CoordinatesManager.WorldToGamePoint(transform.position).x > gamePoint.x;
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
		Vector2 gamePoint = (Vector2) parameters[0];

		StartCoroutine("ExecuteWalkCoroutine", gamePoint);
	}
	
	private IEnumerator ExecuteWalkCoroutine(Vector2 gamePoint) {
		Animator animator = GetComponent<Animator>();
		animator.SetBool(C.CHARACTER_CONTROLLER_IS_WALKING, true);

		float walkingSpeed = Parser.StringToFloat(ConfigurationManager.GetConfiguration(C.CONFIGURATION_ID_WALKING_SPEED));
		
		float gamePointX = gamePoint.x;
		float currentX = CoordinatesManager.WorldToGamePoint(transform.position).x;

		while ( Mathf.Abs(currentX - gamePointX) > C.DELTA_WALK) {
			transform.position += (Vector3) CoordinatesManager.GameToWorldDimensions(new Vector2(Mathf.Sign(gamePointX - currentX) * walkingSpeed, 0));
			yield return new WaitForFixedUpdate();
			
			float previousX = currentX;
			currentX = CoordinatesManager.WorldToGamePoint(transform.position).x;

			if (Mathf.Abs(previousX - currentX) < C.DELTA_EQUAL) {
				// The character stopped walking for some reason
				break;
			}
		}

		animator.SetBool(C.CHARACTER_CONTROLLER_IS_WALKING, false);
		
		OnScheduledActionFinished();
		
		yield break;
	}

}
