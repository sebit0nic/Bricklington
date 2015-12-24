using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public TextMesh endScore, endHighscore;
	private Animator animator;
	private TextMesh scoreText;
	private int currentScore, highscore;

	private void Awake() {
		animator = GameObject.Find ("Score").GetComponent<Animator> ();
		scoreText = GameObject.Find ("Score").GetComponent<TextMesh> ();
		highscore = PlayerPrefs.GetInt ("Highscore");
		scoreText.text = highscore.ToString ();
	}

	public void IncreaseScore() {
		currentScore++;
		scoreText.text = currentScore.ToString ();
		animator.SetTrigger ("OnScore");
	}

	public void SetScoreText() {
		endScore.text = currentScore.ToString ();
		if (currentScore > highscore) {
			highscore = currentScore;
			PlayerPrefs.SetInt("Highscore", highscore);
			PlayerPrefs.Save();
		}
		endHighscore.text = "Top: "+highscore.ToString ();
	}

	public void ResetForGame(bool onscore) {
		currentScore = 0;
		scoreText.text = "0";
		if (onscore) {
			animator.SetTrigger ("OnScore");
		}
	}

	public void ResetForHome() {
		currentScore = 0;
		scoreText.text = highscore.ToString ();
	}
}
