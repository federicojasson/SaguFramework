using UnityEngine;

namespace FrameworkNamespace {

	public class MainMenu : Menu {

		public FadeParameters FadeInParameters;
		public FadeParameters FadeOutParameters;
		
		public virtual void Awake() {
			base.Awake();

			if (FadeInParameters.Texture == null)
				FadeInParameters.Texture = GuiManager.GetDefaultFadeTexture();
			
			if (FadeOutParameters.Texture == null)
				FadeOutParameters.Texture = GuiManager.GetDefaultFadeTexture();
		}
		
	}

}
