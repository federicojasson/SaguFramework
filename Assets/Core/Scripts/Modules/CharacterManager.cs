using System.Collections.Generic;
using UnityEngine;

//
// CharacterManager - Module class
//
// TODO: write class description
//
public static class CharacterManager {

	private static Dictionary<string, NonPlayerCharacter> nonPlayerCharacters;
	private static PlayerCharacter playerCharacter;

	static CharacterManager() {
		nonPlayerCharacters = new Dictionary<string, NonPlayerCharacter>();
	}

	public static void AddNonPlayerCharacter(NonPlayerCharacter nonPlayerCharacter) {
		nonPlayerCharacters.Add(nonPlayerCharacter.GetId(), nonPlayerCharacter);
	}

	public static void AddPlayerCharacter(PlayerCharacter playerCharacter) {
		CharacterManager.playerCharacter = playerCharacter;
	}

	public static void CreateRoomCharacters(string room) {
		// Creates the room non-player characters
		foreach (NonPlayerCharacter nonPlayerCharacter in nonPlayerCharacters.Values)
			if (nonPlayerCharacter.GetRoom().Equals(room)) {
				// The character is in the room
				
				// Creates the character behaviour and links it to the character
				NonPlayerCharacterBehaviour behaviour = Factory.CreateNonPlayerCharacter(nonPlayerCharacter);
				nonPlayerCharacter.SetBehaviour(behaviour);
			}

		// Creates the player character (if it's in the room)
		if (playerCharacter.GetRoom().Equals(room)) {
			// The character is in the room

			// Creates the character behaviour and links it to the character
			PlayerCharacterBehaviour behaviour = Factory.CreatePlayerCharacter(playerCharacter);
			playerCharacter.SetBehaviour(behaviour);
		}
	}

	public static PlayerCharacter GetPlayerCharacter() {
		return playerCharacter;
	}

}
