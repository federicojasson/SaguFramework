public abstract class ItemBehaviour : InteractiveObject {

	public override void DoDefocus() {
		base.DoDefocus();
		GUIManager.ClearCursorLabel();
	}

	public override void DoFocus() {
		base.DoFocus();
		GUIManager.SetCursorLabel(GetLabelText());
	}

	protected abstract string GetLabelText();

}
