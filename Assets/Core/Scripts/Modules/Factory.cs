using UnityEngine;

namespace SaguFramework {
	
	public static class Factory {

		public static void CreateItem(string id, Vector2 position, float scaleFactor) {
			ItemParameters itemParameters = Parameters.GetItemParameters(id);
			ImageParameters imageParameters = itemParameters.Image;

			Image image = CreateImage(imageParameters, Parameters.SortingLayerItem);
			
			InteractiveBehaviour interactiveBehaviour = (InteractiveBehaviour) Object.Instantiate(itemParameters.InteractiveBehaviour);
			Interactive interactive = Instantiate<Interactive>(Parameters.GetInteractive());
			
			ItemBehaviour itemBehaviour = (ItemBehaviour) Object.Instantiate(itemParameters.ItemBehaviour);
			Item item = Instantiate<Item>(Parameters.GetItem());
			item.SetHeight(scaleFactor * itemParameters.Height);
			item.SetPosition(position);
			
			SetParent(image, item);
			SetParent(interactiveBehaviour, item);
			SetParent(interactive, item);
			SetParent(itemBehaviour, item);
		}

		public static void CreateRoom(string id) {
			RoomParameters roomParameters = Parameters.GetRoomParameters(id);
			ImageParameters backgroundImageParameters = roomParameters.BackgroundImage;
			ImageParameters foregroundImageParameters = roomParameters.ForegroundImage;

			Image backgroundImage = CreateImage(backgroundImageParameters, Parameters.SortingLayerRoomBackground);
			Image foregroundImage = CreateImage(foregroundImageParameters, Parameters.SortingLayerRoomForeground);

			Room room = Instantiate<Room>(Parameters.GetRoom());
			room.SetHeight(roomParameters.Height);

			SetParent(backgroundImage, room);
			SetParent(foregroundImage, room);
		}
		
		private static Image CreateImage(ImageParameters parameters, string defaultSortingLayer) {
			string sortingLayer = parameters.SortingLayer;
			if (sortingLayer.Length == 0)
				sortingLayer = defaultSortingLayer;

			Image image = Instantiate<Image>(Parameters.GetImage());
			image.SetOpacity(parameters.Opacity);
			image.SetSortingLayer(sortingLayer);
			image.SetSprite(parameters.Sprite);

			return image;
		}

		private static T Instantiate<T>(T model) where T : Object {
			return (T) Object.Instantiate(model);
		}

		private static void SetParent(Component child, Component parent) {
			child.transform.parent = parent.transform;
		}

	}
	
}
