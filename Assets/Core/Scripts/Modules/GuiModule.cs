using System.Collections;

public static class GuiModule {
	
	private static GuiModuleBehaviour behaviour;

	public static void SetBehaviour(GuiModuleBehaviour behaviour) {
		GuiModule.behaviour = behaviour;
	}
	
}
