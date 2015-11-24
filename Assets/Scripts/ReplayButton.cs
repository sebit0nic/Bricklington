using UnityEngine;
using System.Collections;

public class ReplayButton : MonoBehaviour {

	public Animator[] disappearAnimators;
	private Animator thisAnimator;

	public GameObject gameoverScreen;
	public Blockspawner blockspawner;
	public Ball ball;

	private float timer;
	private bool timedout = false;
	private Score score;

	private void Start() {
		thisAnimator = GetComponent<Animator> ();
		score = GameObject.Find ("Main Camera").GetComponent<Score> ();
	}

	private void Update() {
		if (timedout) {
			timer += Time.deltaTime;
			if (timer >= 1) {
				gameoverScreen.SetActive(false);
				timedout = false;
				timer = 0;
			}
		}
	}

	private void OnMouseUp() {
		for (int i = 0; i < disappearAnimators.Length; i++) {
			disappearAnimators[i].SetTrigger("OnDisappear");
		}
		thisAnimator.SetTrigger ("OnDisappear");

		blockspawner.SetPlaying (true);
		ball.ResetPosition ();
		timedout = true;
		score.Reset ();
	}
}
