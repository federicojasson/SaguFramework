using UnityEngine;

public class QuitDialog : Dialog {
	
	protected override float GetHeight() {
		return 200;
	}
	
	protected override string GetTitle() {
		return LanguageManager.GetText(G.TEXT_ID_QUIT_DIALOG_TITLE);
	}
	
	protected override float GetWidth() {
		return 512;
	}
	
	protected override float GetX() {
		return 0.5f * Screen.width;
	}
	
	protected override float GetY() {
		return 0.5f * Screen.height;
	}
	
	protected override void OnGUIDialog(int id) {
		// TODO: label

		string confirmationButtonText = LanguageManager.GetText(G.TEXT_ID_QUIT_DIALOG_CONFIRMATION_BUTTON);
		if (GUIManager.DrawButton(confirmationButtonText, 0.2f * GetWidth(), 0.7f * GetHeight(), 120, 30))
			OnConfirmButtonClicked();
		
		string cancelButtonText = LanguageManager.GetText(G.TEXT_ID_QUIT_DIALOG_CANCEL_BUTTON);
		if (GUIManager.DrawButton(cancelButtonText, 0.8f * GetWidth(), 0.7f * GetHeight(), 120, 30))
			OnCancelButtonClicked();
	}

	private void OnCancelButtonClicked() {
		// Hides the dialog
		GUIManager.HideDialog();
	}

	private void OnConfirmButtonClicked() {
		// Quits the application
		Application.Quit();
	}
	
}
