using System.Collections;
using UnityEngine;

public partial class CharacterBehaviour : InteractiveObject {

	private void ExecuteLook(object[] parameters) {
		// Parses the parameters
		Vector2 position = (Vector2) parameters[0];

		StartCoroutine("ExecuteLookCoroutine", position);
	}

	private IEnumerator ExecuteLookCoroutine(Vector2 position) {
		// TODO
		
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
		// TODO
		
		OnScheduledActionFinished();
		
		yield break;
	}

}
