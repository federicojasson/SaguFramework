using UnityEngine;

//
// Character - Utility class
//
// This class represents a character. Objects of this class are managed by the CharacterManager.
//
public abstract class Character {

	private string id;
	private string room;
	private float x;
	private float y;
	
	public Character(string id, string room, float x, float y) {
		this.id = id;
		this.room = room;
		this.x = x;
		this.y = y;
	}
	
	public string GetId() {
		return id;
	}
	
	public string GetRoom() {
		return room;
	}
	
	public float GetX() {
		return x;
	}
	
	public float GetY() {
		return y;
	}

	public void SetX(float x) {
		this.x = x;
	}
	
	public void SetY(float y) {
		this.y = y;
	}
	
}
