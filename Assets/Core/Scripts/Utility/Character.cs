using UnityEngine;

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
	
}
