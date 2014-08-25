using System.Collections;

public class RoomSceneLoader : SceneLoader {

	public override void OnUnloadScene() {
		// TODO
	}
	
	protected override IEnumerator LoadSceneCoroutine() {
		Room room = GameManager.CreateCurrentRoom();

		// TODO: manager?
		//GameCamera.SetTarget(room.transform); TODO: target = player character

		// TODO: fade in

		// TODO
		yield break;
	}

}
