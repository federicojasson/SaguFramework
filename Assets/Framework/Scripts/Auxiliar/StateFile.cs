using System;

namespace SaguFramework {

	/// Represents an state file.
	public sealed class StateFile {

		private string id; // The ID
		private DateTime modificationTime; // The modification time

		/// Initializes a state file.
		/// Receives its ID and modification time.
		public StateFile(string id, DateTime modificationTime) {
			this.id = id;
			this.modificationTime = modificationTime;
		}

		/// Determines whether this state file is equal to another.
		public bool Equals(StateFile stateFile) {
			return id == stateFile.GetId() && modificationTime == stateFile.GetModificationTime();
		}

		/// Returns the state file's ID.
		public string GetId() {
			return id;
		}

		/// Returns the state file's modification time.
		public DateTime GetModificationTime() {
			return modificationTime;
		}

	}
	
}
