using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	private Animator animator;
	private TextMesh scoreText;
	private int currentScore;

	private void Awake() {
		animator = GameObject.Find ("Score").GetComponent<Animator> ();
		scoreText = GameObject.Find ("Score").GetComponent<TextMesh> ();
	}

	public void IncreaseScore() {
		currentScore++;
		scoreText.text = currentScore.ToString ();
		animator.SetTrigger ("OnScore");
	}

	public void Reset() {
		currentScore = 0;
		scoreText.text = "0";
	}
}
