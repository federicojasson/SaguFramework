using System;
using System.Collections;
using UnityEngine;

namespace SaguFramework {

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

		/// Executes the character actions.
		/// Optionally, it can execute a final task at the end.
		private IEnumerator ExecuteActionsCoroutine(CharacterAction[] actions, Action furtherAction) {
			foreach (CharacterAction action in actions) {
				// Gets the action's parameters
				object[] parameters = action.GetParameters();

				switch (action.GetId()) {
					case CharacterActionId.Look : {
						// Gets the X value in world space towards the character will look
						float x = (float) parameters[0];

						yield return StartCoroutine(LookCoroutine(x));
						break;
					}

					case CharacterActionId.PickUp : {
						yield return StartCoroutine(PickUpCoroutine());
						break;
					}
						
					case CharacterActionId.Say : {
						// Gets the speech that the character will say
						Speech speech = (Speech) parameters[0];

						yield return StartCoroutine(SayCoroutine(speech));
						break;
					}
						
					case CharacterActionId.Walk : {
						// Gets the X value in world space towards the character will walk to
						float x = (float) parameters[0];
						
						yield return StartCoroutine(WalkCoroutine(x));
						break;
					}
				}
			}

			if (furtherAction != null)
				// Executes a final task
				furtherAction.Invoke();
		}

		/// Looks towards a position.
		/// Receives the X value in world space.
		private IEnumerator LookCoroutine(float x) {
			if (x > GetPosition().x)
				// The character is at the left of the position
				SetDirection(Direction.Right);
			else
				// The character is at the right of the position
				SetDirection(Direction.Left);

			yield break;
		}

		/// Picks up something.
		/// This is just an animation, it doesn't actually adds anything to the inventory.
		private IEnumerator PickUpCoroutine() {
			Animator animator = image.GetAnimator();

			// Triggers the animation
			animator.SetTrigger(Parameters.CharacterAnimatorControllerPickUp);

			yield break;
		}

		/// Says a speech.
		private IEnumerator SayCoroutine(Speech speech) {
			Animator animator = image.GetAnimator();

			// Gets the speech's text and voice
			string text = speech.GetText();
			AudioClip voice = speech.GetVoice();

			// Starts the animation
			animator.SetBool(Parameters.CharacterAnimatorControllerIsSaying, true);

			// Sets the speech
			Drawer.SetSpeech(text);

			// Plays the audio voice and waits until it is finished
			SoundPlayer.PlayVoice(id, voice);
			yield return new WaitForSeconds(voice.length);

			// Stops the animation
			animator.SetBool(Parameters.CharacterAnimatorControllerIsSaying, false);

			// Clears the speech
			Drawer.ClearSpeech();
		}
		
		/// Walks towards a position.
		/// Receives the X value in world space.
		private IEnumerator WalkCoroutine(float x) {
			Animator animator = image.GetAnimator();
			
			// Starts the animation
			animator.SetBool(Parameters.CharacterAnimatorControllerIsWalking, true);

			// Calculates a delta distance and a stop distance
			float deltaDistance = Geometry.GameToWorldWidth(Parameters.DeltaDistance);
			float stopDistance = Parameters.StopDistanceFactor * image.GetSize().x;

			// It approaches until reach a close enough position (when distance > stopDistance)
			Vector2 currentPosition = GetPosition();
			while (Mathf.Abs(currentPosition.x - x) > stopDistance) {
				// Calculates and applies an offset to move the character
				float offset = speed * Time.fixedDeltaTime * Mathf.Sign(x - currentPosition.x);
				SetPosition(currentPosition + new Vector2(offset, 0f));

				// Waits a frame
				yield return new WaitForFixedUpdate();

				// Saves the previous position's X value and obtains the current position
				float previousX = currentPosition.x;
				currentPosition = GetPosition();

				if (Mathf.Abs(previousX - currentPosition.x) < deltaDistance)
					// The character stopped walking for some reason (it got stuck)
					break;
			}
			
			// Stops the animation
			animator.SetBool(Parameters.CharacterAnimatorControllerIsWalking, false);
		}


	}
	
}
