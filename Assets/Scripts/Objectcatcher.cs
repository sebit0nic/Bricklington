using UnityEngine;
using System.Collections;

public class Objectcatcher : MonoBehaviour {

	public Screen gameoverScreen;
	public Animator scoreAnimator;
	public Blockspawner blockSpawner;
	private Score score;

	private void Start() {
		score = GameObject.Find ("Main Camera").GetComponent<Score> ();
	}

	private void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag.Equals ("Ball")) {
			Destroy (coll.gameObject);
			gameoverScreen.gameObject.SetActive(true);
			gameoverScreen.OnStart();
			blockSpawner.SetPlaying(false);
			scoreAnimator.SetTrigger("OnDisappear");
			score.SetScoreText();

			GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
			for (int i = 0; i < blocks.Length; i++) {
				Block block = blocks[i].GetComponent<Block>();
				block.OnDissolve();
			}
		}
		if (coll.gameObject.tag.Equals("Block")) {
			Destroy (coll.gameObject);
		}
	}
}
