using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class OptionsMenuBehaviour : MenuBehaviour {

		private float effectVolume;
		private float masterVolume;
		private float songVolume;
		private float voiceVolume;

		public void Awake() {
			effectVolume = Options.GetFloat(Parameters.OptionIdEffectVolume);
			masterVolume = Options.GetFloat(Parameters.OptionIdMasterVolume);
			songVolume = Options.GetFloat(Parameters.OptionIdSongVolume);
			voiceVolume = Options.GetFloat(Parameters.OptionIdVoiceVolume);
		}

		public override void OnShowGui() {
			GUIStyle menuButtonStyle = GUI.skin.GetStyle("MenuButton");
			GUIStyle modifiedMenuButtonStyle = Utilities.GetRelativeStyle(menuButtonStyle);

			GUIStyle menuHorizontalSliderStyle = GUI.skin.GetStyle("MenuHorizontalSlider");
			GUIStyle modifiedMenuHorizontalSliderStyle = Utilities.GetRelativeStyle(menuHorizontalSliderStyle);

			GUIStyle menuHorizontalSliderThumbStyle = GUI.skin.GetStyle("MenuHorizontalSliderThumb");
			GUIStyle modifiedMenuHorizontalSliderThumbStyle = Utilities.GetRelativeStyle(menuHorizontalSliderThumbStyle);

			GUIStyle menuLabelStyle = GUI.skin.GetStyle("MenuLabel");
			GUIStyle modifiedMenuLabelStyle = Utilities.GetRelativeStyle(menuLabelStyle);
			
			float gameWidth = Geometry.GetGameWidthInPixels();
			float gameHeight = Geometry.GetGameHeightInPixels();

			Rect area0 = new Rect(0.1f * gameWidth, 0.1f * gameHeight, 0.8f * gameWidth, 0.8f * gameHeight);
			GUILayout.BeginArea(area0); {
				Rect area00 = new Rect(0f, 0f, area0.width, 0.5f * area0.height);
				GUILayout.BeginArea(area00); {
					Rect area000 = new Rect(0f, 0f, area00.width, 0.25f * area00.height);
					GUILayout.BeginArea(area000); {
						Rect area0000 = new Rect(0f, 0f, 0.49f * area000.width, area000.height);
						GUILayout.BeginArea(area0000); {
							GUILayout.Label(Language.GetText("OptionsMenuMasterVolumeLabel"), modifiedMenuLabelStyle);
						} GUILayout.EndArea();

						Rect area0001 = new Rect(0.51f * area000.width, 0f, 0.49f * area000.width, area000.height);
						GUILayout.BeginArea(area0001); {
							masterVolume = GUILayout.HorizontalSlider(masterVolume, 0f, 1f, modifiedMenuHorizontalSliderStyle, modifiedMenuHorizontalSliderThumbStyle);
						} GUILayout.EndArea();
					} GUILayout.EndArea();

					Rect area001 = new Rect(0f, 0.25f * area00.height, area00.width, 0.25f * area00.height);
					GUILayout.BeginArea(area001); {
						Rect area0010 = new Rect(0f, 0f, 0.49f * area000.width, area000.height);
						GUILayout.BeginArea(area0010); {
							GUILayout.Label(Language.GetText("OptionsMenuEffectVolumeLabel"), modifiedMenuLabelStyle);
						} GUILayout.EndArea();
						
						Rect area0011 = new Rect(0.51f * area000.width, 0f, 0.49f * area000.width, area000.height);
						GUILayout.BeginArea(area0011); {
							effectVolume = GUILayout.HorizontalSlider(effectVolume, 0f, 1f, modifiedMenuHorizontalSliderStyle, modifiedMenuHorizontalSliderThumbStyle);
						} GUILayout.EndArea();
					} GUILayout.EndArea();

					Rect area002 = new Rect(0f, 0.5f * area00.height, area00.width, 0.25f * area00.height);
					GUILayout.BeginArea(area002); {
						Rect area0020 = new Rect(0f, 0f, 0.49f * area000.width, area000.height);
						GUILayout.BeginArea(area0020); {
							GUILayout.Label(Language.GetText("OptionsMenuSongVolumeLabel"), modifiedMenuLabelStyle);
						} GUILayout.EndArea();
						
						Rect area0021 = new Rect(0.51f * area000.width, 0f, 0.49f * area000.width, area000.height);
						GUILayout.BeginArea(area0021); {
							songVolume = GUILayout.HorizontalSlider(songVolume, 0f, 1f, modifiedMenuHorizontalSliderStyle, modifiedMenuHorizontalSliderThumbStyle);
						} GUILayout.EndArea();
					} GUILayout.EndArea();

					Rect area003 = new Rect(0f, 0.75f * area00.height, area00.width, 0.25f * area00.height);
					GUILayout.BeginArea(area003); {
						Rect area0030 = new Rect(0f, 0f, 0.49f * area000.width, area000.height);
						GUILayout.BeginArea(area0030); {
							GUILayout.Label(Language.GetText("OptionsMenuVoiceVolumeLabel"), modifiedMenuLabelStyle);
						} GUILayout.EndArea();
						
						Rect area0031 = new Rect(0.51f * area000.width, 0f, 0.49f * area000.width, area000.height);
						GUILayout.BeginArea(area0031); {
							voiceVolume = GUILayout.HorizontalSlider(voiceVolume, 0f, 1f, modifiedMenuHorizontalSliderStyle, modifiedMenuHorizontalSliderThumbStyle);
						} GUILayout.EndArea();
					} GUILayout.EndArea();
				} GUILayout.EndArea();
				
				Rect area01 = new Rect(0f, 0.6f * area0.height, 0.45f * area0.width, 0.4f * area0.height);
				GUILayout.BeginArea(area01); {
					if (GUILayout.Button(Language.GetText("OptionsMenuCancelButton"), modifiedMenuButtonStyle))
						OnCancel();
				} GUILayout.EndArea();
				
				Rect area02 = new Rect(0.51f * area0.width, 0.6f * area0.height, 0.49f * area0.width, 0.4f * area0.height);
				GUILayout.BeginArea(area02); {
					if (GUILayout.Button(Language.GetText("OptionsMenuApplyChangesButton"), modifiedMenuButtonStyle))
						OnApplyChanges();
				} GUILayout.EndArea();
			} GUILayout.EndArea();
		}

		private void OnApplyChanges() {
			Options.SetFloat(Parameters.OptionIdEffectVolume, effectVolume);
			Options.SetFloat(Parameters.OptionIdMasterVolume, masterVolume);
			Options.SetFloat(Parameters.OptionIdSongVolume, songVolume);
			Options.SetFloat(Parameters.OptionIdVoiceVolume, voiceVolume);
			Game.ApplyOptions();
			Game.CloseMenu();
		}
		
		private void OnCancel() {
			Game.CloseMenu();
		}
		
	}
	
}
