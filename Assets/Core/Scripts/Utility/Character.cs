using UnityEngine;

//
// Character - Utility class
//
// This class represents a character. Objects of this class are managed by the CharacterManager. A link with its game
// object is created when the latter is instantiated.
//
public class Character {
	
	private GameObject gameObject;
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
	
	public GameObject GetGameObject() {
		return gameObject;
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
	
	public void SetGameObject(GameObject gameObject) {
		this.gameObject = gameObject;
	}

	public void SetX(float x) {
		this.x = x;
	}
	
	public void SetY(float y) {
		this.y = y;
	}
	
}
