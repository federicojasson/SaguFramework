using UnityEngine;

public static class Factory {

	public static Texture2D FadeTexture;

	private static FactoryBehaviour behaviour;

	public static Character CreateCharacter(string id) {
		Character characterModel = behaviour.CharacterModels[id];
		Character character = (Character) Object.Instantiate(characterModel);
		
		return character;
	}

	public static Item CreateItem(string id) {
		Item itemModel = behaviour.ItemModels[id];
		Item item = (Item) Object.Instantiate(itemModel);
		
		return item;
	}

	public static void SetBehaviour(FactoryBehaviour behaviour) {
		Factory.behaviour = behaviour;

		FadeTexture = behaviour.FadeTexture;
	}
	
}
