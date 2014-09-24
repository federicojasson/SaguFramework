using System;
using System.Collections;
using UnityEngine;

namespace SaguFramework {

	// TODO: comentar

	/// A character.
	/// All characters must have a unique ID.
	/// Also, characters can be scheduled to execute actions.
	public sealed class Character : Entity {

		private string id; // The character's ID
		private Image image; // The character's image
		private float speed; // The character's speed

		/// Schedules character actions.
		public void ExecuteActions(CharacterAction[] actions) {
			ExecuteActions(actions, null);
		}
		
		/// Schedules character actions and a task to be executed at the end.
		public void ExecuteActions(CharacterAction[] actions, Action furtherAction) {
			// Stops the character actions (if any was being executed)
			StopActions();

			StartCoroutine(ExecuteActionsCoroutine(actions, furtherAction));
		}

		/// Returns the character's direction.
		public Direction GetDirection() {
			// Gets the animator
			Animator animator = image.GetAnimator();

			// Checks the character's direction
			if (animator.GetBool(Parameters.CharacterAnimatorControllerIsDirectionLeft))
				return Direction.Left;
			else
				return Direction.Right;
		}

		/// Returns the character's ID.
		public string GetId() {
			return id;
		}

		/// Sets the character's direction.
		public void SetDirection(Direction direction) {
			Animator animator = image.GetAnimator();
			animator.SetBool(Parameters.CharacterAnimatorControllerIsDirectionLeft, direction == Direction.Left);
		}
		
		/// Sets the character's ID.
		public void SetId(string id) {
			this.id = id;
		}

		/// Sets the character's image.
		public void SetImage(Image image) {
			this.image = image;
		}

		/// Sets the character's speed.
		public void SetSpeed(float speed) {
			this.speed = speed;
		}

		/// Stops the scheduled character actions.
		public void StopActions() {
			StopAllCoroutines();

			// Resets the animator
			Animator animator = image.GetAnimator();
			animator.SetBool(Parameters.CharacterAnimatorControllerIsSaying, false);
			animator.SetBool(Parameters.CharacterAnimatorControllerIsWalking, false);

			// Clears the speech
			Drawer.ClearSpeech();

			// Mutes the character
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
			Animator animator = image.GetAnimator();
			animator.SetTrigger(Parameters.CharacterAnimatorControllerPickUp);
			yield break;
		}
		
		private IEnumerator SayCoroutine(Speech speech) {
			Animator animator = image.GetAnimator();

			string text = speech.GetText();
			AudioClip voice = speech.GetVoice();

			animator.SetBool(Parameters.CharacterAnimatorControllerIsSaying, true);
			Drawer.SetSpeech(text);

			SoundPlayer.PlayVoice(id, voice);
			yield return new WaitForSeconds(voice.length);

			animator.SetBool(Parameters.CharacterAnimatorControllerIsSaying, false);
			Drawer.ClearSpeech();
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

				float previousX = currentPosition.x;
				currentPosition = GetPosition();

				if (Mathf.Abs(previousX - currentPosition.x) < deltaDistance)
					// The character stopped walking for some reason
					break;
			}

			animator.SetBool(Parameters.CharacterAnimatorControllerIsWalking, false);
		}


	}
	
}
