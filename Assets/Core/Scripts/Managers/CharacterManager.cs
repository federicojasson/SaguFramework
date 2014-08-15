using System.Collections.Generic;
using UnityEngine;

public static class CharacterManager {

	private static List<Character> activeCharacters;
	private static Dictionary<string, Location> characterLocations;
	private static string playerCharacterId;
	private static CharacterManagerWorker worker;

	static CharacterManager() {
		activeCharacters = new List<Character>();
		characterLocations = new Dictionary<string, Location>();
	}

	public static void ClearState() {
		characterLocations.Clear();
		playerCharacterId = null;
	}

	public static void CreateRoomCharacters(string room) {
		activeCharacters.Clear();

		foreach (KeyValuePair<string, Location> entry in characterLocations) {
			Location location = entry.Value;

			if (location.Room == room)
				activeCharacters.Add(CreateCharacter(entry.Key, location.Position));
		}
	}

	public static void SetCharacterLocation(string id, Location location) {
		characterLocations.Add(id, location);
	}

	public static void SetPlayerCharacterId(string id) {
		playerCharacterId = id;
	}

	public static void SetWorker(CharacterManagerWorker worker) {
		CharacterManager.worker = worker;
	}
	
	private static Character CreateCharacter(string id, Vector2 position) {
		// TODO: a change of position's coordinates might be necessary

		Character characterModel = worker.CharacterModels[id];
		Character character = (Character) Object.Instantiate(characterModel, position, Quaternion.identity);

		if (id == playerCharacterId)
			character.gameObject.AddComponent(ConfigurationManager.PlayerCharacterClass);
		
		return character;
	}

}
