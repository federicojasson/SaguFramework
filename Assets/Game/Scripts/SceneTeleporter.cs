using UnityEngine;

public class SceneTeleporter : MonoBehaviour {

	public string targetScene;

	public void OnMouseEnter() {
		Game.instance.SetAction(P.SPECIAL_ACTION_TELEPORT);
	}
	
	public void OnMouseExit() {
		Game.instance.SetPreviousAction();
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		Application.LoadLevel(targetScene);
	}
	
}
