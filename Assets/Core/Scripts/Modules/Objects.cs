using System.Collections.Generic;

namespace SaguFramework {
	
	public static class Objects {

		private static List<Item> items;
		private static Loader loader;

		static Objects() {
			items = new List<Item>();
		}

		public static Loader GetLoader() {
			return loader;
		}

		public static void RegisterItem(Item item) {
			items.Add(item);
		}

		public static void RegisterLoader(Loader loader) {
			Objects.loader = loader;
		}

		public static void UnregisterItem(Item item) {
			items.Remove(item);
		}

		public static void UnregisterLoader() {
			Objects.loader = null;
		}

	}
	
}
