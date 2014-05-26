using UnityEngine;

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
		return 0.5f * Screen.width;
	}
	
	protected override float GetY() {
		return 0.5f * Screen.height;
	}
	
	protected override void OnGUIDialog(int id) {
		string labelText = LanguageManager.GetText(G.TEXT_ID_QUIT_DIALOG_LABEL);
		GUIManager.DrawLabel(labelText, G.QUIT_DIALOG_PADDING, G.QUIT_DIALOG_PADDING, GetWidth() - 3 * G.QUIT_DIALOG_PADDING);

		string confirmButtonText = LanguageManager.GetText(G.TEXT_ID_QUIT_DIALOG_CONFIRMATION_BUTTON);
		if (GUIManager.DrawButton(confirmButtonText, 0.25f * GetWidth(), 0.75f * GetHeight(), G.DIALOG_BUTTON_WIDTH, G.DIALOG_BUTTON_HEIGHT))
			OnConfirmButtonActuated();
		
		string cancelButtonText = LanguageManager.GetText(G.TEXT_ID_QUIT_DIALOG_CANCEL_BUTTON);
		if (GUIManager.DrawButton(cancelButtonText, 0.75f * GetWidth(), 0.75f * GetHeight(), G.DIALOG_BUTTON_WIDTH, G.DIALOG_BUTTON_HEIGHT))
			OnCancelButtonActuated();
	}

	private void OnCancelButtonActuated() {
		GUIManager.HideDialog();
	}

	private void OnConfirmButtonActuated() {
		GameManager.QuitGame();
	}
	
}
