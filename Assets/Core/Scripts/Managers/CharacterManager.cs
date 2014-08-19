using System.Collections.Generic;

public static class CharacterManager {

	private static Dictionary<string, Location> characterLocations;
	private static List<Character> roomCharacters;

	static CharacterManager() {
		characterLocations = new Dictionary<string, Location>();
		roomCharacters = new List<Character>();
	}

	/*public static void CreateCharacters(string roomId) {
		// TODO
	}*/

	public static void Reset() {
		// Clears the manager's data structures
		characterLocations.Clear();
		roomCharacters.Clear();
	}

	/*public static void SetCharacterLocation(string id, Location location) {
		// Sets the character's location (it overrides it if there's already a location registered)
		characterLocations[id] = location;
	}*/

}
