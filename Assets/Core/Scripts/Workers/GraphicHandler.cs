using UnityEngine;

namespace SaguFramework {
	
	public class GraphicHandler : Worker {

		public static void ClearTooltip() {
			// TODO
		}

		public static bool IsCursorInGame() {
			return Geometry.GetGameRectangleInScreen().Contains(Input.mousePosition);
		}

		public static void SetTooltip(string tooltip) {
			// TODO
		}

		public void OnGUI() {
			// TODO: fade y windowbox
		}

		public override void OnOrderChange() {
			// TODO: cambiar cursor de acuerdo a la orden

			Order order = OrderHandler.GetOrder();
			
			Screen.showCursor = false;

			// TODO
			switch (OrderHandler.GetOrder()) {
				case Order.Click : {
					break;
				}

				case Order.Look : {
					break;
				}

				case Order.None : {
					return;
				}

				case Order.PickUp : {
					break;
				}

				case Order.Speak : {
					break;
				}

				case Order.UseInventoryItem : {
					// TODO: setear el sprite del item del inventario
					break;
				}

				case Order.Walk : {
					break;
				}
			}

			// TODO: set the sprite

			Screen.showCursor = true;
		}

	}
	
}
