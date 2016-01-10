using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameoverButton : MonoBehaviour {

	public Screen gameoverScreen, titleScreen;
	public Blockspawner blockspawner;
	public GameObject ball;
	public GameObject paddle;

	private Score score;
	private Button thisButton;

	private void Start() {
		score = GameObject.Find ("Main Camera").GetComponent<Score> ();
		thisButton = GetComponent<Button> ();
	}

	public void OnRetry() {
		gameoverScreen.OnDisappear ();
		thisButton.enabled = false;
		paddle.GetComponent<Animator>().SetTrigger ("OnStart");
		paddle.transform.position = new Vector3 (0, -5.7f, 0);
		
		blockspawner.SetPlaying (true);
		Instantiate (ball, Vector3.zero, Quaternion.identity);
		score.ResetForGame (true);
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
