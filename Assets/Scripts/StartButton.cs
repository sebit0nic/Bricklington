using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

	public Screen titlescreen;
	public GameObject ball;
	public GameObject explosion;
	private Blockspawner blockspawner;
	private Button thisButton;
	private Score score;

	private void Start() {
		blockspawner = GameObject.Find ("Blockspawner").GetComponent<Blockspawner>();
		thisButton = GetComponent<Button> ();
		score = GameObject.Find ("Main Camera").GetComponent<Score> ();
	}
	
	public void OnClick() {
		titlescreen.OnDisappear ();
		thisButton.enabled = false;
		score.ResetForGame ();
		
		blockspawner.SetPlaying (true);
		Instantiate (ball, new Vector3(0, 1, 0), Quaternion.identity);
	}

	public void OnDisableTitlescreen() {
		thisButton.enabled = true;
	}
}
