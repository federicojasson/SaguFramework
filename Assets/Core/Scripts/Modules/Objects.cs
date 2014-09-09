using System.Collections.Generic;

namespace SaguFramework {
	
	public static class Objects {

		private static Inventory inventory;
		private static List<Worker> workers;

		static Objects() {
			workers = new List<Worker>();
		}

		public static Inventory GetInventory() {
			return inventory;
		}
		
		public static List<Worker> GetWorkers() {
			return workers;
		}

		public static void RegisterEntity(Entity entity) {
			if (entity is Inventory) {
				inventory = (Inventory) entity;
				return;
			}
		}

		public static void RegisterWorker(Worker module) {
			workers.Add(module);
		}

		public static void UnregisterEntity(Entity entity) {
			if (entity is Inventory) {
				inventory = null;
				return;
			}
		}

	}
	
}
