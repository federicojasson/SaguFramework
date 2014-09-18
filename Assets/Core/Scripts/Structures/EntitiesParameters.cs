using System;

namespace SaguFramework {

	[Serializable]
	public class EntitiesParameters {
		
		public RoomParametersMap Rooms;
		public InventoryParameters Inventory;
		public InventoryItemParametersMap InventoryItems;
		public CharacterParametersMap Characters;
		public ItemParametersMap Items;
		public MenusParameters Menus;
		public SplashScreensParameters SplashScreens;

	}
	
}
