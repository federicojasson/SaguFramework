using System;
using System.Collections;
using UnityEngine;

namespace SaguFramework {
	
	public class Character : Entity {

		private string id;

		public void ExecuteActions(CharacterAction[] actions) {
			ExecuteActions(actions, null);
		}
		
		public void ExecuteActions(CharacterAction[] actions, Action furtherAction) {
			StartCoroutine(ExecuteActionsCoroutine(actions, furtherAction));
		}

		public Direction GetDirection() {
			// TODO: GetDirection
			return Direction.Right;
		}

		public string GetId() {
			return id;
		}

		public void SetId(string id) {
			this.id = id;
		}

		public void StopActions() {
			StopAllCoroutines();
			SoundPlayer.StopVoice(id);
		}

		private IEnumerator ExecuteActionsCoroutine(CharacterAction[] actions, Action furtherAction) {
			StopActions();

			foreach (CharacterAction action in actions) {
				object[] parameters = action.GetParameters();

				switch (action.GetId()) {
					case CharacterActionId.Look : {
						yield return StartCoroutine(LookCoroutine((Vector2) parameters[0]));
						break;
					}

					case CharacterActionId.PickUp : {
						yield return StartCoroutine(PickUpCoroutine());
						break;
					}
						
					case CharacterActionId.Say : {
						yield return StartCoroutine(SayCoroutine((string) parameters[0], (AudioClip) parameters[1]));
						break;
					}
						
					case CharacterActionId.Walk : {
						yield return StartCoroutine(WalkCoroutine((Vector2) parameters[0]));
						break;
					}
				}
			}

			if (furtherAction != null)
				furtherAction.Invoke();
		}

		private IEnumerator LookCoroutine(Vector2 position) {
			// TODO: animation
			//bool facingLeft = CoordinatesManager.WorldToGamePoint(transform.position).x > gamePoint.x;
			//GetComponent<Animator>().SetBool(C.CHARACTER_CONTROLLER_FACING_LEFT, facingLeft);

			yield break;
		}

		private IEnumerator PickUpCoroutine() {
			// TODO: animation

			yield break;
		}
		
		private IEnumerator SayCoroutine(string text, AudioClip voice) {
			// TODO: animation
			Animator animator = GetComponentInChildren<Animator>();
			animator.SetBool("IsSaying", true);

			SoundPlayer.PlayVoice(id, voice);
			yield return new WaitForSeconds(voice.length);

			// TODO: animation
			GetComponentInChildren<Animator>().SetBool("IsSaying", false);
		}

		private IEnumerator WalkCoroutine(Vector2 position) {
			// TODO: animation
			Animator animator = GetComponentInChildren<Animator>();
			animator.SetBool("IsWalking", true);

			// TODO: Get speed
			float walkSpeed = Geometry.GameToWorldX(0.2f);

			Vector2 currentPosition = GetPosition();

			while (Mathf.Abs(currentPosition.x - position.x) > Parameters.DeltaWorld) {
				float offset = walkSpeed * Time.fixedDeltaTime * Mathf.Sign(position.x - currentPosition.x);
				SetPosition(currentPosition + new Vector2(offset, 0f));

				yield return new WaitForFixedUpdate();

				Vector2 previousPosition = currentPosition;
				currentPosition = GetPosition();

				if (Mathf.Abs(previousPosition.x - currentPosition.x) < Parameters.DeltaWorld)
					// The character stopped walking for some reason
					break;
			}

			// TODO: animation
			GetComponentInChildren<Animator>().SetBool("IsWalking", false);
		}


	}
	
}
