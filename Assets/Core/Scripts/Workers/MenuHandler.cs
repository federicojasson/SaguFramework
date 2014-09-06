using System.Collections.Generic;

namespace SaguFramework {
	
	public class MenuHandler : Worker {

		private static MenuHandler instance;

		public static MenuHandler GetInstance() {
			return instance;
		}
		
		public override void Awake() {
			base.Awake();
			instance = this;
		}

		public void CloseMenu() {
			Objects.GetCurrentMenu().Close();

			if (Objects.GetMenuCount() > 0)
				Objects.GetCurrentMenu().Show();
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
			MenuParameters parameters = Parameters.GetPauseMenuParameters();
			OpenMenu(parameters);
		}

		private void OpenMenu(MenuParameters parameters) {
			if (Objects.GetMenuCount() > 0)
				Objects.GetCurrentMenu().Hide();

			Menu menu = Factory.CreateMenu(parameters);
			menu.Show();
		}

	}
	
}
