using System.IO;
using UnityEngine;

public class LoadMenu : Menu {

	private string[] stateFileIds;

	public void Awake() {
		FileInfo[] stateFiles = StateManager.GetStateFiles();
		stateFileIds = new string[stateFiles.Length];

		for (int i = 0; i < stateFiles.Length; ++i)
			stateFileIds[i] = Path.GetFileNameWithoutExtension(stateFiles[i].Name);
	}

	public void OnGUI() {
		base.OnGUI();

		GuiManager.BeginArea(GuiManager.Center, GuiManager.Middle, 0.8f, 0.8f);
			GuiManager.BeginArea(GuiManager.Left, GuiManager.Middle, 0.45f, 1f);
				GuiManager.BeginArea(GuiManager.Center, GuiManager.Top, 1f, 0.25f);
					GuiManager.BeginArea(GuiManager.Center, GuiManager.Top, 1f, 0.4f);
						if (GuiManager.Button("Cargar partida")) // TODO: use LanguageManager
							OnGoBackButtonActuated();
					GuiManager.EndArea();
					GuiManager.BeginArea(GuiManager.Center, GuiManager.Bottom, 1f, 0.4f);
						if (GuiManager.Button("Eliminar partida")) // TODO: use LanguageManager
							OnGoBackButtonActuated();
					GuiManager.EndArea();
				GuiManager.EndArea();
				GuiManager.BeginArea(GuiManager.Center, GuiManager.Bottom, 1f, 0.1f);
				if (GuiManager.Button("Volver")) // TODO: use LanguageManager
					OnGoBackButtonActuated();
				GuiManager.EndArea();
			GuiManager.EndArea();
			GuiManager.BeginArea(GuiManager.Right, GuiManager.Middle, 0.45f, 1f);
				GuiManager.BeginScrollView(new Vector2(0, 0)); // TODO: not working!
					for (int i = 0; i < stateFileIds.Length; ++i) {
						GuiManager.BeginArea(0.5f, i * 0.15f + 0.05f, 1f, 0.1f);
						if (GuiManager.Button(stateFileIds[i]))
							OnStateFileIdSelected(i);
						GuiManager.EndArea();
					}
				GuiManager.EndScrollView();
			GuiManager.EndArea();
		GuiManager.EndArea();
	}

	private void OnGoBackButtonActuated() {
		MenuManager.CloseCurrentMenu();
	}

	private void OnStateFileIdSelected(int index) {
		// TODO
		Debug.Log(stateFileIds[index]);
	}
	
}
