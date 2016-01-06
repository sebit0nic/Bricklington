using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

	public Image[] disableImages;
	private Button thisButton;

	private void Start() {
		thisButton = GetComponent<Button> ();
	}

	private void Update() {
		if (Input.GetMouseButtonDown (0)) {
			Time.timeScale = 1;
			thisButton.interactable = true;
			for (int i = 0; i < disableImages.Length; i++) {
				disableImages[i].enabled = false;
			}
		}
	}

	public void PauseGame() {
		Time.timeScale = 0;
		for (int i = 0; i < disableImages.Length; i++) {
			disableImages[i].enabled = true;
		}
	}
}
