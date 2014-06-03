using System.Collections;
using UnityEngine;

public partial class CharacterBehaviour : InteractiveObject {

	private void ExecuteLook(object[] parameters) {
		StartCoroutine("ExecuteLookCoroutine", parameters);
	}

	private IEnumerator ExecuteLookCoroutine(object[] parameters) {
		// Parses the parameters
		Vector2 gamePoint = (Vector2) parameters[0];

		bool facingLeft = CoordinatesManager.WorldToGamePoint(transform.position).x > gamePoint.x;
		GetComponent<Animator>().SetBool(C.CHARACTER_CONTROLLER_FACING_LEFT, facingLeft);
		
		OnScheduledActionFinished();

		yield break;
	}

	private void ExecuteSay(object[] parameters) {
		StartCoroutine("ExecuteSayCoroutine", parameters);
	}

	public IEnumerator ExecuteSayCoroutine(object[] parameters) {
		// Parses the parameters
		string text = (string) parameters[0]; // TODO: use text somehow
		AudioClip audio = (AudioClip) parameters[1];

		Animator animator = GetComponent<Animator>();
		animator.SetBool(C.CHARACTER_CONTROLLER_IS_SAYING, true);

		AudioManager.PlayAudio(audio);
		yield return new WaitForSeconds(AudioManager.GetAudioLength(audio));
		AudioManager.StopAudio(audio);

		animator.SetBool(C.CHARACTER_CONTROLLER_IS_SAYING, false);

		OnScheduledActionFinished();
		
		yield break;
	}

	private void ExecuteWalk(object[] parameters) {
		StartCoroutine("ExecuteWalkCoroutine", parameters);
	}
	
	public IEnumerator ExecuteWalkCoroutine(object[] parameters) {
		// Parses the parameters
		Vector2 gamePoint = (Vector2) parameters[0];

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
