using UnityEngine;
using System.Collections;

public class Objectcatcher : MonoBehaviour {

	public bool DestroyBall;

	public Screen gameoverScreen;
	public Animator scoreAnimator, crownAnimator, pauseButton;
	public Blockspawner blockSpawner;
	private Score score;

	private void Start() {
		score = GameObject.Find ("Main Camera").GetComponent<Score> ();
	}

	private void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag.Equals ("Ball") && DestroyBall) {
			Destroy (coll.gameObject);
			gameoverScreen.gameObject.SetActive(true);
			gameoverScreen.OnStart();
			blockSpawner.SetPlaying(false);
			scoreAnimator.SetTrigger("OnDisappear");
			if (score.IsNewHighscore()) {
				crownAnimator.SetTrigger("OnDisappear");
			}
			pauseButton.SetTrigger("OnEnd");
			score.SetScoreText();

			GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
			for (int i = 0; i < blocks.Length; i++) {
				Block block = blocks[i].GetComponent<Block>();
				block.OnDissolve();
			}
		}
	}
}
