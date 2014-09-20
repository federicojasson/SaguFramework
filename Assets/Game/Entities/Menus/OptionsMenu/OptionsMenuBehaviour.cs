using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public sealed class OptionsMenuBehaviour : MenuBehaviour {

		private float effectVolume;
		private float masterVolume;
		private float songVolume;
		private float voiceVolume;

		public void Awake() {
			effectVolume = Framework.GetEffectVolume();
			masterVolume = Framework.GetMasterVolume();
			songVolume = Framework.GetSongVolume();
			voiceVolume = Framework.GetVoiceVolume();
		}

		public override void OnShowGui() {
			GUIStyle horizontalSliderStyle = Framework.GetStyle(GUI.skin.horizontalSlider.name);
			GUIStyle horizontalSliderThumbStyle = Framework.GetStyle(GUI.skin.horizontalSliderThumb.name);
			GUIStyle menuButtonStyle = Framework.GetStyle("MenuButton");
			GUIStyle menuLabelStyle = Framework.GetStyle("MenuLabel");
			GUIStyle menuTitleStyle = Framework.GetStyle("MenuTitle");

			Framework.BeginArea(0.05f, 0.05f, 0.9f, 0.1f); {
				GUILayout.Label(Framework.GetText("OptionsMenuTitleLabel"), menuTitleStyle);
			} Framework.EndArea();

			Framework.BeginArea(0.1f, 0.25f, 0.8f, 0.7f); {
				Framework.BeginArea(0f, 0f, 1f, 0.75f); {
					Framework.BeginArea(0f, 0f, 1f, 0.25f); {
						Framework.BeginArea(0f, 0f, 0.35f, 1f); {
							GUILayout.Label(Framework.GetText("OptionsMenuMasterVolumeLabel"), menuLabelStyle);
						} Framework.EndArea();

						Framework.BeginArea(0.4f, 0.15f, 0.6f, 0.3f); {
							masterVolume = GUILayout.HorizontalSlider(masterVolume, 0f, 1f, horizontalSliderStyle, horizontalSliderThumbStyle, GUILayout.ExpandHeight(true));
						} Framework.EndArea();
					} Framework.EndArea();

					Framework.BeginArea(0f, 0.25f, 1f, 0.25f); {
						Framework.BeginArea(0f, 0f, 0.35f, 1f); {
							GUILayout.Label(Framework.GetText("OptionsMenuEffectVolumeLabel"), menuLabelStyle);
						} Framework.EndArea();

						Framework.BeginArea(0.4f, 0.15f, 0.6f, 0.3f); {
							effectVolume = GUILayout.HorizontalSlider(effectVolume, 0f, 1f, horizontalSliderStyle, horizontalSliderThumbStyle, GUILayout.ExpandHeight(true));
						} Framework.EndArea();
					} Framework.EndArea();

					Framework.BeginArea(0f, 0.5f, 1f, 0.25f); {
						Framework.BeginArea(0f, 0f, 0.35f, 1f); {
							GUILayout.Label(Framework.GetText("OptionsMenuSongVolumeLabel"), menuLabelStyle);
						} Framework.EndArea();

						Framework.BeginArea(0.4f, 0.15f, 0.6f, 0.3f); {
							songVolume = GUILayout.HorizontalSlider(songVolume, 0f, 1f, horizontalSliderStyle, horizontalSliderThumbStyle, GUILayout.ExpandHeight(true));
						} Framework.EndArea();
					} Framework.EndArea();

					Framework.BeginArea(0f, 0.75f, 1f, 0.25f); {
						Framework.BeginArea(0f, 0f, 0.35f, 1f); {
							GUILayout.Label(Framework.GetText("OptionsMenuVoiceVolumeLabel"), menuLabelStyle);
						} Framework.EndArea();

						Framework.BeginArea(0.4f, 0.15f, 0.6f, 0.3f); {
							voiceVolume = GUILayout.HorizontalSlider(voiceVolume, 0f, 1f, horizontalSliderStyle, horizontalSliderThumbStyle, GUILayout.ExpandHeight(true));
						} Framework.EndArea();
					} Framework.EndArea();
				} Framework.EndArea();

				Framework.BeginArea(0f, 0.8f, 0.45f, 0.2f); {
					if (GUILayout.Button(Framework.GetText("OptionsMenuCancelButton"), menuButtonStyle))
						OnCancel();
				} Framework.EndArea();

				Framework.BeginArea(0.51f, 0.8f, 0.49f, 0.2f); {
					if (GUILayout.Button(Framework.GetText("OptionsMenuApplyChangesButton"), menuButtonStyle))
						OnApplyChanges();
				} Framework.EndArea();
			} Framework.EndArea();
		}

		private void OnApplyChanges() {
			Framework.SetEffectVolume(effectVolume);
			Framework.SetMasterVolume(masterVolume);
			Framework.SetSongVolume(songVolume);
			Framework.SetVoiceVolume(voiceVolume);
			Framework.SaveOptions();
			Framework.CloseMenu();
		}
		
		private void OnCancel() {
			Framework.CloseMenu();
		}
		
	}
	
}
