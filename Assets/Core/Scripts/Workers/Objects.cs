using System.Collections.Generic;

namespace SaguFramework {
	
	public class Objects : Worker {

		private static List<Entity> entities;
		private static List<Worker> workers;

		static Objects() {
			entities = new List<Entity>();
			workers = new List<Worker>();
		}

		public static Character GetPlayerCharacter() {
			// TODO
			return null;
		}
		
		public static List<Worker> GetWorkers() {
			return workers;
		}

		public static void RegisterEntity(Entity entity) {
			entities.Add(entity);
		}

		public static void RegisterWorker(Worker module) {
			workers.Add(module);
		}

		public static void UnregisterEntity(Entity entity) {
			entities.Remove(entity);
		}

	}
	
}
