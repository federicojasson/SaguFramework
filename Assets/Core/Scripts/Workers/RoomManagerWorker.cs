using UnityEngine;

public class RoomManagerWorker : MonoBehaviour {
	
	public RoomDictionary RoomModels;
	
	public void Awake() {
		RoomManager.SetWorker(this);
	}
	
}
