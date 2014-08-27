using UnityEngine;

namespace FrameworkNamespace {

	public partial class GameAssets : MonoBehaviour {

		public CharacterMap CharacterPrefabs;
		public InventoryItemMap InventoryItemPrefabs;
		public ItemMap ItemPrefabs;
		public RoomMap RoomPrefabs;

		public void Awake() {
			instance = this;
		}
		
	}

}
