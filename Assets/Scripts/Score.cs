using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public bool resetHighscore;

	public TextMesh endScore, endHighscore;
	public Animator crownAnimator;
	private Animator animator;
	private TextMesh scoreText;
	private int currentScore, highscore;
	private bool crownAnimPlayedOnce, newHighscore;

	private void Awake() {
		animator = GameObject.Find ("Score").GetComponent<Animator> ();
		scoreText = GameObject.Find ("Score").GetComponent<TextMesh> ();

		if (resetHighscore) {
			PlayerPrefs.SetInt("Highscore", 0);
			PlayerPrefs.Save ();
		}

		highscore = PlayerPrefs.GetInt ("Highscore");
		scoreText.text = highscore.ToString ();
	}

	public void IncreaseScore() {
		currentScore++;
		scoreText.text = currentScore.ToString ();
		animator.SetTrigger ("OnScore");
		if (currentScore > highscore) {
			newHighscore = true;

			if (!crownAnimPlayedOnce) {
				crownAnimator.SetTrigger("OnNew");
				crownAnimPlayedOnce = true;
			}
		}
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
		crownAnimPlayedOnce = false;
		newHighscore = false;

		if (onscore) {
			animator.SetTrigger ("OnScore");
		}
	}

	public void ResetForHome() {
		scoreText.text = highscore.ToString ();
	}

	public bool IsNewHighscore() {
		return newHighscore;
	}
}
