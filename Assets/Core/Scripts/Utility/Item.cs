using UnityEngine;

//
// Item - Utility class
//
// This class represents an item. Objects of this class are managed by the ItemManager. A link with its behaviour is
// created when the latter is instantiated.
//
public class Item {

	private ItemBehaviour behaviour;
	private string id;
	private string room;
	private float x;
	private float y;

	public Item(string id, string room, float x, float y) {
		this.id = id;
		this.room = room;
		this.x = x;
		this.y = y;
	}

	public ItemBehaviour GetBehaviour() {
		return behaviour;
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

	public void SetBehaviour(ItemBehaviour behaviour) {
		this.behaviour = behaviour;
	}

}
