public class Item {

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

}
