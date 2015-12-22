using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameoverButton : MonoBehaviour {

	public Screen gameoverScreen, titleScreen;
	public Blockspawner blockspawner;
	public GameObject ball;

	private Score score;
	private Button thisButton;

	private void Start() {
		score = GameObject.Find ("Main Camera").GetComponent<Score> ();
		thisButton = GetComponent<Button> ();
	}

	public void OnRetry() {
		gameoverScreen.OnDisappear ();
		thisButton.enabled = false;
		
		blockspawner.SetPlaying (true);
		Instantiate (ball, Vector3.zero, Quaternion.identity);
		score.ResetForGame ();
	}

	public void OnHome() {
		gameoverScreen.OnDisappear ();
		thisButton.enabled = false;
		titleScreen.OnStart ();
		score.ResetForHome ();
	}

	public void OnDisableGameoverScreen() {
		thisButton.enabled = true;
	}
}
