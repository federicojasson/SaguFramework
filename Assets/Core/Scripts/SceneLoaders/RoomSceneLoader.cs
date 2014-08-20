using System.Collections;

public class RoomSceneLoader : SceneLoader {

	public override void OnUnloadScene() {
		// TODO
	}
	
	protected override IEnumerator LoadSceneCoroutine() {
		Room room = GameManager.CreateCurrentRoom();

		//room.FadeParameters; TODO

		// TODO
		yield break;
	}

}
