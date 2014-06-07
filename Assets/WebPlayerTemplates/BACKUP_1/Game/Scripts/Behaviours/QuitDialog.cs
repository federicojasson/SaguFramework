//
// QuitDialog - Behaviour class
//
// This class implements the quit dialog. This dialog shows up everytime the user attempts to quit the game.
//
// TODO: adjust sizes and positions to improve this dialog
//
public class QuitDialog : Dialog {
	
	protected override float GetHeight() {
		return G.QUIT_DIALOG_HEIGHT;
	}
	
	protected override string GetTitle() {
		return LanguageManager.GetText(G.TEXT_ID_QUIT_DIALOG_TITLE);
	}
	
	protected override float GetWidth() {
		return G.QUIT_DIALOG_WIDTH;
	}
	
	protected override float GetX() {
		return 0.5f;
	}
	
	protected override float GetY() {
		return 0.5f;
	}
	
	protected override void OnGUIDialog(int id) {
		string labelText = LanguageManager.GetText(G.TEXT_ID_QUIT_DIALOG_LABEL);
		float horizontalPadding = (GetWidth() - 2 * G.DIALOG_BUTTON_WIDTH) / 3;
		GUIManager.DrawLabel(labelText, horizontalPadding, 1 - G.QUIT_DIALOG_PADDING_VERTICAL, GetWidth() - 2 * horizontalPadding);

		string confirmButtonText = LanguageManager.GetText(G.TEXT_ID_QUIT_DIALOG_CONFIRMATION_BUTTON);
		if (GUIManager.DrawButton(confirmButtonText, (2 * GetWidth() - G.DIALOG_BUTTON_WIDTH) / 6, 0.75f * GetHeight(), G.DIALOG_BUTTON_WIDTH, G.DIALOG_BUTTON_HEIGHT))
			OnConfirmButtonActuated();
		
		string cancelButtonText = LanguageManager.GetText(G.TEXT_ID_QUIT_DIALOG_CANCEL_BUTTON);
		if (GUIManager.DrawButton(cancelButtonText, (4 * GetWidth() + G.DIALOG_BUTTON_WIDTH) / 6, 0.75f * GetHeight(), G.DIALOG_BUTTON_WIDTH, G.DIALOG_BUTTON_HEIGHT))
			OnCancelButtonActuated();
	}

	private void OnCancelButtonActuated() {
		GUIManager.HideDialog();
	}

	private void OnConfirmButtonActuated() {
		GameManager.QuitGame();
	}
	
}
