using FrameworkNamespace;
using UnityEngine;

public class LoadGameMenu : Menu {

	private string[] stateIds;

	public override void Awake() {
		base.Awake();
		stateIds = StateManager.GetStateIds();
	}

	public void OnGUI() {
		// TODO
	}
	
}
