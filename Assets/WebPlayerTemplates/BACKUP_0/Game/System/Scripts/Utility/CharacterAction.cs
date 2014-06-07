public class CharacterAction {
	
	private int id;
	private object[] parameters;

	public CharacterAction(int id, params object[] parameters) {
		this.id = id;
		this.parameters = Utility.PackParameters(parameters);
	}

	public int GetId() {
		return id;
	}

	public object[] GetParameters() {
		return parameters;
	}

}
