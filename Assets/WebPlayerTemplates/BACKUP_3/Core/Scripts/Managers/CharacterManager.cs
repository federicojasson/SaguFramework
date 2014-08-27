using System.Collections.Generic;

namespace FrameworkNamespace {

	public static class CharacterManager {

		private static Dictionary<string, Location> characterLocations;
		private static string playerCharacterId;

		static CharacterManager() {
			characterLocations = new Dictionary<string, Location>();
		}
		
		public static void ClearCharacterLocations() {
			characterLocations.Clear();
		}

		public static void CreateRoomCharacters(string roomId, float scaleFactor) {
			foreach (KeyValuePair<string, Location> entry in characterLocations) {
				Location location = entry.Value;
				
				if (location.RoomId == roomId)
					GameAssets.CreateCharacter(entry.Key, location.PositionInGame, scaleFactor);
			}
		}

		public static string GetPlayerCharacterId() {
			return playerCharacterId;
		}
		
		public static void SetCharacterLocation(string id, Location location) {
			characterLocations[id] = location;
		}

		public static void SetPlayerCharacterId(string id) {
			playerCharacterId = id;
		}

	}

}