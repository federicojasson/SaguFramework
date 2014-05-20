using UnityEngine;

public class QuitDialog : Dialog {
	
	protected override float GetHeight() {
		return G.CONFIRMATION_DIALOG_HEIGHT;
	}
	
	protected override string GetTitle() {
		return LanguageManager.GetText(G.TEXT_ID_QUIT_DIALOG_TITLE);
	}
	
	protected override float GetWidth() {
		return G.CONFIRMATION_DIALOG_WIDTH;
	}
	
	protected override float GetX() {
		return 0.5f * Screen.width;
	}
	
	protected override float GetY() {
		return 0.5f * Screen.height;
	}
	
	protected override void OnGUIDialog(int id) {
		string labelText = LanguageManager.GetText(G.TEXT_ID_QUIT_DIALOG_LABEL);
		GUIManager.DrawLabel(labelText, G.CONFIRMATION_DIALOG_PADDING, G.CONFIRMATION_DIALOG_PADDING, GetWidth() - 3 * G.CONFIRMATION_DIALOG_PADDING);

		string confirmaButtonText = LanguageManager.GetText(G.TEXT_ID_QUIT_DIALOG_CONFIRMATION_BUTTON);
		if (GUIManager.DrawButton(confirmaButtonText, 0.25f * GetWidth(), 0.75f * GetHeight(), G.CONFIRMATION_DIALOG_BUTTON_WIDTH, G.CONFIRMATION_DIALOG_BUTTON_HEIGHT))
			OnConfirmButtonActuated();
		
		string cancelButtonText = LanguageManager.GetText(G.TEXT_ID_QUIT_DIALOG_CANCEL_BUTTON);
		if (GUIManager.DrawButton(cancelButtonText, 0.75f * GetWidth(), 0.75f * GetHeight(), G.CONFIRMATION_DIALOG_BUTTON_WIDTH, G.CONFIRMATION_DIALOG_BUTTON_HEIGHT))
			OnCancelButtonActuated();
	}

	private void OnCancelButtonActuated() {
		// Hides the dialog
		GUIManager.HideDialog();
	}

	private void OnConfirmButtonActuated() {
		// Quits the application
		Application.Quit();
	}
	
}
