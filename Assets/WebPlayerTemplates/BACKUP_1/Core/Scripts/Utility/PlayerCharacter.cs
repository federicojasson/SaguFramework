//
// PlayerCharacter - Utility class
//
// TODO: write description
//
public class PlayerCharacter : Character {
	
	private PlayerCharacterBehaviour behaviour;

	public PlayerCharacter(string id, string room, float x, float y) : base(id, room, x, y) {}

	public PlayerCharacterBehaviour GetBehaviour() {
		return behaviour;
	}
	
	public void SetBehaviour(PlayerCharacterBehaviour behaviour) {
		this.behaviour = behaviour;
	}

}
