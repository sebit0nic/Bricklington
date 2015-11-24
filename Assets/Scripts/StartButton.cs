using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	public GameObject titlescreen;
	public GameObject ball;
	public GameObject explosion;
	private Blockspawner blockspawner;
	private Animator thisAnimator;
	public Animator scoreAnimator, titleAnimator, highscoreAnimator;

	private void Start() {
		blockspawner = GameObject.Find ("Blockspawner").GetComponent<Blockspawner>();
		thisAnimator = GetComponent<Animator> ();
	}
	
	public void OnClick() {
		thisAnimator.SetTrigger ("OnDisappear");
		titleAnimator.SetTrigger ("OnDisappear");
		highscoreAnimator.SetTrigger ("OnDisappear");
		scoreAnimator.SetTrigger ("OnTransition");
		
		blockspawner.SetPlaying (true);
		ball.SetActive (true);
	}

	public void OnDisableTitlescreen() {
		titlescreen.SetActive (false);
	}
}
