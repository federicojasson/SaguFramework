using System.Collections.Generic;

namespace SaguFramework {
	
	public static partial class State {

		private static string currentRoomId;
		private static List<string> hints;
		private static Dictionary<string, ItemState> itemStates;

		static State() {
			hints = new List<string>();
			itemStates = new Dictionary<string, ItemState>();
		}

		public static string GetCurrentRoomId() {
			return currentRoomId;
		}

		public static ItemState GetItemState(string id) {
			return itemStates[id];
		}
		
		public static List<string> GetRoomItemIds(string roomId) {
			List<string> itemIds = new List<string>();

			foreach (KeyValuePair<string, ItemState> entry in itemStates)
				if (roomId == entry.Value.GetLocation().GetRoomId())
					itemIds.Add(entry.Key);
			
			return itemIds;
		}

		public static bool HintExists(string searchedHint) {
			foreach (string hint in hints)
				if (hint == searchedHint)
					return true;

			return false;
		}

	}
	
}
