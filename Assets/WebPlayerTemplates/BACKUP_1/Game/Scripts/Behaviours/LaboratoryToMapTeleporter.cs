public class LaboratoryToMapTeleporter : RoomTeleporter {
	
	protected override string GetLabelText() {
		return LanguageManager.GetText(G.LABORATORY_TO_MAP_TELEPORTER_LABEL);
	}
	
	protected override string GetTarget() {
		return G.ROOM_MAP;
	}
	
}
