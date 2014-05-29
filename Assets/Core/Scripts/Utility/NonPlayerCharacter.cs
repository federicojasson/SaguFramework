//
// NonPlayerCharacter - Utility class
//
// TODO: write description
//
public class NonPlayerCharacter : Character {

	private NonPlayerCharacterBehaviour behaviour;
	
	public NonPlayerCharacter(string id, string room, float x, float y) : base(id, room, x, y) {}

	public NonPlayerCharacterBehaviour GetBehaviour() {
		return behaviour;
	}
	
	public void SetBehaviour(NonPlayerCharacterBehaviour behaviour) {
		this.behaviour = behaviour;
	}

}
