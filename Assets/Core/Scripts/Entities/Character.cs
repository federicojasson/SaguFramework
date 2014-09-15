using System;
using System.Collections;
using UnityEngine;

namespace SaguFramework {
	
	public class Character : Entity {

		private string id;
		private Image image;
		private float speed;

		public void ExecuteActions(CharacterAction[] actions) {
			ExecuteActions(actions, null);
		}
		
		public void ExecuteActions(CharacterAction[] actions, Action furtherAction) {
			StopActions();
			StartCoroutine(ExecuteActionsCoroutine(actions, furtherAction));
		}

		public Direction GetDirection() {
			if (image.GetAnimator().GetBool(Parameters.CharacterAnimatorControllerIsDirectionLeft))
				return Direction.Left;
			else
				return Direction.Right;
		}

		public string GetId() {
			return id;
		}

		public void SetDirection(Direction direction) {
			image.GetAnimator().SetBool(Parameters.CharacterAnimatorControllerIsDirectionLeft, direction == Direction.Left);
		}

		public void SetId(string id) {
			this.id = id;
		}

		public void SetImage(Image image) {
			this.image = image;
		}

		public void SetSpeed(float speed) {
			this.speed = speed;
		}

		public void StopActions() {
			StopAllCoroutines();
			SoundPlayer.StopVoice(id);
		}

		private IEnumerator ExecuteActionsCoroutine(CharacterAction[] actions, Action furtherAction) {
			foreach (CharacterAction action in actions) {
				object[] parameters = action.GetParameters();

				switch (action.GetId()) {
					case CharacterActionId.Look : {
						yield return StartCoroutine(LookCoroutine((Vector2) parameters[0]));
						continue;
					}

					case CharacterActionId.PickUp : {
						yield return StartCoroutine(PickUpCoroutine());
						continue;
					}
						
					case CharacterActionId.Say : {
						yield return StartCoroutine(SayCoroutine((string) parameters[0], (AudioClip) parameters[1]));
						continue;
					}
						
					case CharacterActionId.Walk : {
						yield return StartCoroutine(WalkCoroutine((Vector2) parameters[0]));
						continue;
					}
				}
			}

			if (furtherAction != null)
				furtherAction.Invoke();
		}

		private IEnumerator LookCoroutine(Vector2 position) {
			if (position.x > GetPosition().x)
				SetDirection(Direction.Right);
			else
				SetDirection(Direction.Left);

			yield break;
		}

		private IEnumerator PickUpCoroutine() {
			// TODO: animation

			yield break;
		}
		
		private IEnumerator SayCoroutine(string text, AudioClip voice) {
			Animator animator = image.GetAnimator();

			animator.SetBool(Parameters.CharacterAnimatorControllerIsSaying, true);
			SoundPlayer.PlayVoice(id, voice);
			yield return new WaitForSeconds(voice.length);
			animator.SetBool(Parameters.CharacterAnimatorControllerIsSaying, false);
		}

		private IEnumerator WalkCoroutine(Vector2 position) {
			Animator animator = image.GetAnimator();

			animator.SetBool(Parameters.CharacterAnimatorControllerIsWalking, true);

			float deltaDistance = Geometry.GameToWorldWidth(Parameters.DeltaDistance);
			float stopDistance = Parameters.StopDistanceFactor * image.GetSize().x;
			Vector2 currentPosition = GetPosition();

			while (Mathf.Abs(currentPosition.x - position.x) > stopDistance) {
				float offset = speed * Time.fixedDeltaTime * Mathf.Sign(position.x - currentPosition.x);
				SetPosition(currentPosition + new Vector2(offset, 0f));

				yield return new WaitForFixedUpdate();

				Vector2 previousPosition = currentPosition;
				currentPosition = GetPosition();

				if (Mathf.Abs(previousPosition.x - currentPosition.x) < deltaDistance)
					// The character stopped walking for some reason
					break;
			}

			animator.SetBool(Parameters.CharacterAnimatorControllerIsWalking, false);
		}


	}
	
}
