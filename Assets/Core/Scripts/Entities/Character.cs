using UnityEngine;

public class Character : MonoBehaviour {
	
	public GameImageParameters ImageParameters;

	public void Awake() {
		if (ImageParameters.SortingLayer.Length == 0)
			ImageParameters.SortingLayer = Parameters.CharacterImageSortingLayer;
	}

}
