using System.Collections.Generic;

public static class CharacterManager {

	private static List<Character> characters;

	static CharacterManager() {
		characters = new List<Character>();
	}

	public static void AddCharacter(Character character) {
		characters.Add(character);
	}

	public static List<Character> GetCharacters(string roomId) {
		List<Character> characters = new List<Character>();
		
		foreach (Character character in CharacterManager.characters)
			if (character.GetRoomId().Equals(roomId))
				characters.Add(character);
		
		return characters;
	}

}
