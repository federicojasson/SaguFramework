using System.Collections.Generic;

public static class CharacterManager {

	private static Dictionary<string, Location> characterLocations;

	static CharacterManager() {
		characterLocations = new Dictionary<string, Location>();
	}

	public static void CreateCharacters(string roomId) {
		foreach (KeyValuePair<string, Location> entry in characterLocations) {
			Location location = entry.Value;
			
			if (location.RoomId == roomId)
				GameAssets.CreateCharacter(entry.Key, location.Position);
		}
	}

	public static void Reset() {
		// Clears the manager's data structures
		characterLocations.Clear();
	}

}
