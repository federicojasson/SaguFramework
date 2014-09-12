namespace SaguFramework {
	
	public class Character : Entity {

		private string id;

		public Direction GetDirection() {
			// TODO: GetDirection
			return Direction.Right;
		}

		public string GetId() {
			return id;
		}

		public void SetId(string id) {
			this.id = id;
		}

	}
	
}
