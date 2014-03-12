using UnityEngine;

public class Factory : MonoBehaviour {

	private static Factory instance;
	public Texture2D lookCursorIcon;
	public Texture2D walkCursorIcon;
	public Texture2D teleportCursorIcon;
	public FollowerLabel cursorLabelModel;

	public static FollowerLabel CreateCursorLabel(Vector2 offset, string text) {
		// TODO position
		FollowerLabel label = (FollowerLabel) Instantiate(Factory.instance.cursorLabelModel, Vector3.zero, Quaternion.identity);
		label.SetOffset(offset);
		label.SetText(text);
		return label;
	}

	public static void DestroyCursorLabel(FollowerLabel cursorLabel) {
		Destroy(cursorLabel.gameObject);
	}

	public static Texture2D GetLookCursorIcon() {
		return Factory.instance.lookCursorIcon;
	}
	
	public static Texture2D GetTeleportCursorIcon() {
		return Factory.instance.teleportCursorIcon;
	}
	
	public static Texture2D GetWalkCursorIcon() {
		return Factory.instance.walkCursorIcon;
	}
	
	public void Awake() {
		instance = this;
	}

}
