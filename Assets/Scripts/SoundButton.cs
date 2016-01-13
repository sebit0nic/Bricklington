using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour {

	private int volume = 0;
	public Image disabledIcon;
	public Color disabledColor;

	private void Start() {
		volume = PlayerPrefs.GetInt ("Soundeffects");
		CheckVolume ();
	}

	public void OnClick() {
		if (volume == 0) {
			volume = 1;
		} else {
			volume = 0;
		}
		PlayerPrefs.SetInt ("Soundeffects", volume);
		PlayerPrefs.Save ();
		CheckVolume ();
	}

	private void CheckVolume() {
		if (volume == 0) {
			AudioListener.volume = 1;
			disabledIcon.color = Color.clear;
		} else {
			AudioListener.volume = 0;
			disabledIcon.color = disabledColor;
		}
	}
}
