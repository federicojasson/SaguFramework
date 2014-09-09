using System;

namespace SaguFramework {

	[Serializable]
	public class EntitiesParameters {

		public InventoryParameters Inventory;
		public InventoryItemParametersMap InventoryItems;
		public RoomParametersMap Rooms;
		public CharacterParametersMap Characters;
		public ItemParametersMap Items;
		public MenusParameters Menus;
		public SplashScreensParameters SplashScreens;

	}
	
}
