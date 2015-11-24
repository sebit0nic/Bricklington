using UnityEngine;
using System.Collections;

public class Objectcatcher : MonoBehaviour {

	public GameObject gameoverScreen;
	public Blockspawner blockSpawner;

	private void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag.Equals ("Ball")) {
			gameoverScreen.SetActive(true);
			blockSpawner.SetPlaying(false);

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
