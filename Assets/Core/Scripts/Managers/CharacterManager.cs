using System.Collections.Generic;
using UnityEngine;

public static class CharacterManager {

	private static List<Character> activeCharacters;
	private static Dictionary<string, Location> characterLocations;
	private static CharacterManagerWorker worker;

	static CharacterManager() {
		activeCharacters = new List<Character>();
		characterLocations = new Dictionary<string, Location>();
	}

	public static void CreateRoomCharacters(string room) {
		activeCharacters.Clear();

		foreach (KeyValuePair<string, Location> entry in characterLocations)
			if (entry.Value.Room == room)
				activeCharacters.Add(CreateCharacter(entry.Key));
	}

	public static void RegisterCharacterLocation(string id, Location location) {
		characterLocations.Add(id, location);
	}

	public static void SetWorker(CharacterManagerWorker worker) {
		CharacterManager.worker = worker;
	}
	
	private static Character CreateCharacter(string id) {
		Character characterModel = worker.CharacterModels[id];
		return (Character) Object.Instantiate(characterModel);
	}

}
