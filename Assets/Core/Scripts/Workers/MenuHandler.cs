using System.Collections.Generic;

namespace SaguFramework {
	
	public class MenuHandler : Worker {

		private static MenuHandler instance;

		public static MenuHandler GetInstance() {
			return instance;
		}

		private Menu pauseMenu;
		
		public override void Awake() {
			base.Awake();
			instance = this;
		}

		public void CloseMenu() {
			if (Objects.GetMenuCount() == 1) {
				Menu currentMenu = Objects.GetCurrentMenu();
				if (currentMenu == pauseMenu) {
					currentMenu.Close();
					InputHandler.GetInstance().SetCurrentInputMode();
				}
			} else {
				Objects.GetCurrentMenu().Close();
				Objects.GetCurrentMenu().Show();
			}
		}

		public void OpenMainMenu() {
			MenuParameters parameters = Parameters.GetMainMenuParameters();
			OpenMenu(parameters);
		}

		public void OpenMenu(string id) {
			MenuParameters parameters = Parameters.GetMenuParameters(id);
			OpenMenu(parameters);
		}

		public void OpenPauseMenu() {
			InputHandler.GetInstance().SetInputMode(InputMode.PauseMenu);
			MenuParameters parameters = Parameters.GetPauseMenuParameters();
			pauseMenu = OpenMenu(parameters);
		}

		private Menu OpenMenu(MenuParameters parameters) {
			if (Objects.GetMenuCount() > 0)
				Objects.GetCurrentMenu().Hide();

			Menu menu = Factory.CreateMenu(parameters);
			menu.Show();

			return menu;
		}

	}
	
}
