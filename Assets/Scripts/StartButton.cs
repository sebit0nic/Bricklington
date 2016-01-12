using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

	public Screen titlescreen;
	public GameObject ball;
	public GameObject paddle;
	public GameObject instructionArrow1, instructionArrow2;
	private Blockspawner blockspawner;
	private Button thisButton;
	private Score score;
	private AudioSource audioSource;

	private void Start() {
		blockspawner = GameObject.Find ("Blockspawner").GetComponent<Blockspawner>();
		thisButton = GetComponent<Button> ();
		score = GameObject.Find ("Main Camera").GetComponent<Score> ();
		audioSource = GetComponent<AudioSource> ();
	}
	
	public void OnClick() {
		titlescreen.OnDisappear ();
		thisButton.enabled = false;
		score.ResetForGame (false);
		audioSource.Play ();

		paddle.SetActive (true);
		paddle.GetComponent<Animator>().SetTrigger ("OnStart");
		paddle.transform.position = new Vector3 (0, -5.7f, 0);

		if (instructionArrow1 != null && instructionArrow2 != null) {
			instructionArrow1.SetActive(true);
			instructionArrow2.SetActive(true);
		}
		
		blockspawner.SetPlaying (true);
		Instantiate (ball, new Vector3(0, 1, 0), Quaternion.identity);
	}

	public void OnDisableTitlescreen() {
		thisButton.enabled = true;
	}
}
