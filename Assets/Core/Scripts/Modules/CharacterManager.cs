using System.Collections.Generic;
using UnityEngine;

//
// CharacterManager - Module class
//
// TODO: write class description
//
public static class CharacterManager {

	private static Dictionary<string, Character> characters;
	private static Character playerCharacter;

	static CharacterManager() {
		characters = new Dictionary<string, Character>();
	}

	public static void AddCharacter(Character character) {
		characters.Add(character.GetId(), character);
	}

	public static void AddPlayerCharacter(Character character) {
		AddCharacter(character);
		playerCharacter = character;
	}

	public static void CreateRoomCharacters(string room) {
		foreach (Character character in characters.Values)
			if (character.GetRoom().Equals(room)) {
				// The character is in the room
				
				// Creates the character game object and attaches it to the character
				GameObject gameObject = Factory.CreateCharacter(character);
				character.SetGameObject(gameObject);
			}
	}

	public static Character GetPlayerCharacter() {
		return playerCharacter;
	}

}
