using System.Collections.Generic;

namespace SaguFramework {
	
	public class MenuHandler : Worker {

		private static MenuHandler instance;

		public static MenuHandler GetInstance() {
			return instance;
		}

		private Menu mainMenu;
		
		public override void Awake() {
			base.Awake();
			instance = this;
		}

		public void CloseMenu() {
			if (Objects.GetMenuCount() == 1) {
				Menu currentMenu = Objects.GetCurrentMenu();
				if (currentMenu != mainMenu)
					currentMenu.Close();
			} else {
				Objects.GetCurrentMenu().Close();
				Objects.GetCurrentMenu().Show();
			}
		}

		public void OpenMainMenu() {
			MenuParameters parameters = Parameters.GetMainMenuParameters();
			mainMenu = OpenMenu(parameters);
		}

		public void OpenMenu(string id) {
			MenuParameters parameters = Parameters.GetMenuParameters(id);
			OpenMenu(parameters);
		}

		public void OpenPauseMenu() {
			MenuParameters parameters = Parameters.GetPauseMenuParameters();
			OpenMenu(parameters);
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
