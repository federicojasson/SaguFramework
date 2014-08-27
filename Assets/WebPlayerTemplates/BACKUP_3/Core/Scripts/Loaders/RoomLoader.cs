using System.Collections;

namespace FrameworkNamespace {

	public class RoomLoader : Loader {

		protected override IEnumerator LoadSceneCoroutine() {
			RoomManager.CreateCurrentRoom();

			Room room = RoomManager.GetCurrentRoom();

			// TODO: manager?
			//GameCamera.SetTarget(room.transform); TODO: target = player character

			yield return StartCoroutine(GuiManager.FadeInCoroutine(room.FadeInParameters));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			Room room = RoomManager.GetCurrentRoom();
			yield return StartCoroutine(GuiManager.FadeOutCoroutine(room.FadeOutParameters));
		}

	}

}
