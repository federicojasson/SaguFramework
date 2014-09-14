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
			GUIStyle horizontalSliderStyle = GUI.skin.horizontalSlider;
			GUIStyle modifiedHorizontalSliderStyle = Utilities.GetRelativeStyle(horizontalSliderStyle);

			GUIStyle menuButtonStyle = GUI.skin.GetStyle("MenuButton");
			GUIStyle modifiedMenuButtonStyle = Utilities.GetRelativeStyle(menuButtonStyle);

			GUIStyle menuHorizontalSliderThumbStyle = GUI.skin.horizontalSliderThumb;
			GUIStyle modifiedMenuHorizontalSliderThumbStyle = Utilities.GetRelativeStyle(menuHorizontalSliderThumbStyle);

			GUIStyle menuLabelStyle = GUI.skin.GetStyle("MenuLabel");
			GUIStyle modifiedMenuLabelStyle = Utilities.GetRelativeStyle(menuLabelStyle);

			GUIStyle menuTitleStyle = GUI.skin.GetStyle("MenuTitle");
			GUIStyle modifiedMenuTitleStyle = Utilities.GetRelativeStyle(menuTitleStyle);
			
			float gameWidth = Geometry.GetGameWidthInPixels();
			float gameHeight = Geometry.GetGameHeightInPixels();

			Rect area0 = new Rect(0.05f * gameWidth, 0.05f * gameHeight, 0.9f * gameWidth, 0.1f * gameHeight);
			GUILayout.BeginArea(area0); {
				GUILayout.Label(Language.GetText("OptionsMenuTitleLabel"), modifiedMenuTitleStyle);
			} GUILayout.EndArea();

			Rect area1 = new Rect(0.1f * gameWidth, 0.25f * gameHeight, 0.8f * gameWidth, 0.7f * gameHeight);
			GUILayout.BeginArea(area1); {
				Rect area10 = new Rect(0f, 0f, area1.width, 0.75f * area1.height);
				GUILayout.BeginArea(area10); {
					Rect area100 = new Rect(0f, 0f, area10.width, 0.25f * area10.height);
					GUILayout.BeginArea(area100); {
						Rect area1000 = new Rect(0f, 0f, 0.35f * area100.width, area100.height);
						GUILayout.BeginArea(area1000); {
							GUILayout.Label(Language.GetText("OptionsMenuMasterVolumeLabel"), modifiedMenuLabelStyle);
						} GUILayout.EndArea();

						Rect area1001 = new Rect(0.4f * area100.width, 0.15f * area100.height, 0.6f * area100.width, 0.3f * area100.height);
						GUILayout.BeginArea(area1001); {
							masterVolume = GUILayout.HorizontalSlider(masterVolume, 0f, 1f, modifiedHorizontalSliderStyle, modifiedMenuHorizontalSliderThumbStyle, GUILayout.ExpandHeight(true));
						} GUILayout.EndArea();
					} GUILayout.EndArea();

					Rect area101 = new Rect(0f, 0.25f * area10.height, area10.width, 0.25f * area10.height);
					GUILayout.BeginArea(area101); {
						Rect area1010 = new Rect(0f, 0f, 0.35f * area101.width, area101.height);
						GUILayout.BeginArea(area1010); {
							GUILayout.Label(Language.GetText("OptionsMenuEffectVolumeLabel"), modifiedMenuLabelStyle);
						} GUILayout.EndArea();
						
						Rect area1011 = new Rect(0.4f * area101.width, 0.15f * area101.height, 0.6f * area101.width, 0.3f * area101.height);
						GUILayout.BeginArea(area1011); {
							effectVolume = GUILayout.HorizontalSlider(effectVolume, 0f, 1f, modifiedHorizontalSliderStyle, modifiedMenuHorizontalSliderThumbStyle, GUILayout.ExpandHeight(true));
						} GUILayout.EndArea();
					} GUILayout.EndArea();

					Rect area102 = new Rect(0f, 0.5f * area10.height, area10.width, 0.25f * area10.height);
					GUILayout.BeginArea(area102); {
						Rect area1020 = new Rect(0f, 0f, 0.35f * area102.width, area102.height);
						GUILayout.BeginArea(area1020); {
							GUILayout.Label(Language.GetText("OptionsMenuSongVolumeLabel"), modifiedMenuLabelStyle);
						} GUILayout.EndArea();
						
						Rect area1021 = new Rect(0.4f * area102.width, 0.15f * area102.height, 0.6f * area102.width, 0.3f * area102.height);
						GUILayout.BeginArea(area1021); {
							songVolume = GUILayout.HorizontalSlider(songVolume, 0f, 1f, modifiedHorizontalSliderStyle, modifiedMenuHorizontalSliderThumbStyle, GUILayout.ExpandHeight(true));
						} GUILayout.EndArea();
					} GUILayout.EndArea();

					Rect area103 = new Rect(0f, 0.75f * area10.height, area10.width, 0.25f * area10.height);
					GUILayout.BeginArea(area103); {
						Rect area1030 = new Rect(0f, 0f, 0.35f * area103.width, area103.height);
						GUILayout.BeginArea(area1030); {
							GUILayout.Label(Language.GetText("OptionsMenuVoiceVolumeLabel"), modifiedMenuLabelStyle);
						} GUILayout.EndArea();
						
						Rect area1031 = new Rect(0.4f * area103.width, 0.15f * area103.height, 0.6f * area103.width, 0.3f * area103.height);
						GUILayout.BeginArea(area1031); {
							voiceVolume = GUILayout.HorizontalSlider(voiceVolume, 0f, 1f, modifiedHorizontalSliderStyle, modifiedMenuHorizontalSliderThumbStyle, GUILayout.ExpandHeight(true));
						} GUILayout.EndArea();
					} GUILayout.EndArea();
				} GUILayout.EndArea();
				
				Rect area11 = new Rect(0f, 0.8f * area1.height, 0.45f * area1.width, 0.2f * area1.height);
				GUILayout.BeginArea(area11); {
					if (GUILayout.Button(Language.GetText("OptionsMenuCancelButton"), modifiedMenuButtonStyle))
						OnCancel();
				} GUILayout.EndArea();
				
				Rect area12 = new Rect(0.51f * area1.width, 0.8f * area1.height, 0.49f * area1.width, 0.2f * area1.height);
				GUILayout.BeginArea(area12); {
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
