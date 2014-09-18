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

			Animator animator = image.GetAnimator();
			animator.SetBool(Parameters.CharacterAnimatorControllerIsSaying, false);
			animator.SetBool(Parameters.CharacterAnimatorControllerIsWalking, false);

			SoundPlayer.StopVoice(id);
		}

		private IEnumerator ExecuteActionsCoroutine(CharacterAction[] actions, Action furtherAction) {
			foreach (CharacterAction action in actions) {
				object[] parameters = action.GetParameters();

				switch (action.GetId()) {
					case CharacterActionId.Look : {
						float x = (float) parameters[0];
						yield return StartCoroutine(LookCoroutine(x));
						break;
					}
					
					case CharacterActionId.LookAndPickUp : {
						float x = (float) parameters[0];
						yield return StartCoroutine(LookCoroutine(x));
						yield return StartCoroutine(PickUpCoroutine());
						break;
					}
						
					case CharacterActionId.LookAndSay : {
						float x = (float) parameters[0];
						Speech speech = (Speech) parameters[1];
						yield return StartCoroutine(LookCoroutine(x));
						yield return StartCoroutine(SayCoroutine(speech));
						break;
					}
						
					case CharacterActionId.LookAndWalk : {
						float x = (float) parameters[0];
						yield return StartCoroutine(LookCoroutine(x));
						yield return StartCoroutine(WalkCoroutine(x));
						break;
					}

					case CharacterActionId.PickUp : {
						yield return StartCoroutine(PickUpCoroutine());
						break;
					}
						
					case CharacterActionId.Say : {
						Speech speech = (Speech) parameters[0];
						yield return StartCoroutine(SayCoroutine(speech));
						break;
					}
						
					case CharacterActionId.Walk : {
						float x = (float) parameters[0];
						yield return StartCoroutine(WalkCoroutine(x));
						break;
					}
				}
			}

			if (furtherAction != null)
				furtherAction.Invoke();
		}

		private IEnumerator LookCoroutine(float x) {
			if (x > GetPosition().x)
				SetDirection(Direction.Right);
			else
				SetDirection(Direction.Left);

			yield break;
		}

		private IEnumerator PickUpCoroutine() {
			image.GetAnimator().SetTrigger(Parameters.CharacterAnimatorControllerPickUp);
			yield break;
		}
		
		private IEnumerator SayCoroutine(Speech speech) {
			Animator animator = image.GetAnimator();

			string text = speech.GetText();
			AudioClip voice = speech.GetVoice();

			animator.SetBool(Parameters.CharacterAnimatorControllerIsSaying, true);
			GraphicHandler.SetSpeechText(text);
			SoundPlayer.PlayVoice(id, voice);
			yield return new WaitForSeconds(voice.length);
			GraphicHandler.ClearSpeechText();
			animator.SetBool(Parameters.CharacterAnimatorControllerIsSaying, false);
		}

		private IEnumerator WalkCoroutine(float x) {
			Animator animator = image.GetAnimator();

			animator.SetBool(Parameters.CharacterAnimatorControllerIsWalking, true);

			float deltaDistance = Geometry.GameToWorldWidth(Parameters.DeltaDistance);
			float stopDistance = Parameters.StopDistanceFactor * image.GetSize().x;
			Vector2 currentPosition = GetPosition();

			while (Mathf.Abs(currentPosition.x - x) > stopDistance) {
				float offset = speed * Time.fixedDeltaTime * Mathf.Sign(x - currentPosition.x);
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
