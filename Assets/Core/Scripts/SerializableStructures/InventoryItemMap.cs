using System;

namespace FrameworkNamespace {

	[Serializable]
	public class InventoryItemMap : SerializableMap<string, InventoryItem, InventoryItemMapEntry> {}

}
