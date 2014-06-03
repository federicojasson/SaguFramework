public abstract class ItemBehaviour : InteractiveObject {

	public override void DoDefocus() {
		base.DoDefocus();
		//GUIManager.SetCursorLabel(GetLabelText());
	}

	public override void DoFocus() {
		base.DoFocus();
		//GUIManager.ClearCursorLabel();
	}

	//protected abstract string GetLabelText();

}
