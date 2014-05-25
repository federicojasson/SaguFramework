using System.Collections.Generic;
using UnityEngine;

public static class CharacterManager {

	private static Dictionary<string, Character> characters;

	static CharacterManager() {
		characters = new Dictionary<string, Character>();
	}

	public static void AddCharacter(Character character) {
		characters.Add(character.GetId(), character);
		
		// TODO: check errors?
	}

	public static void LoadRoomCharacters(string room) {
		foreach (Character character in characters.Values)
			if (character.GetRoom().Equals(room)) {
				// The character is in the room
				
				// Creates the character game object and attaches it to the character
				GameObject gameObject = Factory.CreateCharacter(character);
				character.SetGameObject(gameObject);
			}
		
		// TODO: check errors?
	}

}
