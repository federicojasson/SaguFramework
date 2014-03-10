using UnityEngine;

public static class CursorManager {
	
	public static void UpdateCursor() {
		switch (Game.instance.GetCurrentAction()) {
			case P.ACTION_LOOK : {
				SetCursor(Game.instance.lookCursorTexture);
				break;
			}

			case P.ACTION_WALK : {
				SetCursor(Game.instance.walkCursorTexture);
				break;
			}

			case P.SPECIAL_ACTION_TELEPORT : {
				SetCursor(Game.instance.teleportCursorTexture);
				break;
			}
		}
	}

	private static void SetCursor(Texture2D texture) {
		Cursor.SetCursor(texture, new Vector2(texture.width / 2, texture.height / 2), CursorMode.ForceSoftware);
	}
	
}
