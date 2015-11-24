using UnityEngine;
using System.Collections;

public class Blockspawner : MonoBehaviour {
	
	public GameObject block;
	public float startInterval = 5;
	private float timer = 2;
	private int blockCount;
	private bool playing;

	private float[] spawnlocations1 = {-2.7f, -1.6f, -0.5f, 0.6f, 1.7f, 2.8f};
	private float[] spawnlocations2 = {-2.2f, -1.1f, 0f, 1.1f, 2.2f};
	private bool line1 = false;
	private int possibleBlocksPerLine = 1, minBlocksPerLine = 1;

	private void Update() {
		if (playing) {
			timer += Time.deltaTime;
			
			if (timer >= startInterval) {
				SpawnBlocks();
				
				line1 = !line1;
				timer = 0;
				if (blockCount > 10) {
					possibleBlocksPerLine = 2;
				}
				if (blockCount > 30) {
					possibleBlocksPerLine = 3;
				}
				if (blockCount > 60) {
					minBlocksPerLine = 2;
					possibleBlocksPerLine = 4;
				}
				if (blockCount > 100) {
					minBlocksPerLine = 3;
				}
			}
		}
	}

	private void SpawnBlocks() {
		int currentBlocksPerLine = Random.Range (minBlocksPerLine, possibleBlocksPerLine+1);
		float[] placedBlocks = new float[20];
		int pointer = 0;

		while (currentBlocksPerLine > 0) {
			bool canBePlaced = true;
			int random;
			float spawnlocation;

			if (line1) {
				random = Random.Range (0, 6);
				spawnlocation = spawnlocations1[random];
			} else {
				random = Random.Range (0, 5);
				spawnlocation = spawnlocations2[random];
			}

			for (int i = 0; i < placedBlocks.Length; i++) {
				if (spawnlocation == placedBlocks[i]) {
					canBePlaced = false;
				}
			}
			if (canBePlaced) {
				placedBlocks[pointer] = spawnlocation;
				pointer++;
				Instantiate(block, new Vector3(spawnlocation, transform.position.y, 0), Quaternion.identity);
				blockCount++;
				currentBlocksPerLine--;

				if (blockCount % 30 == 0 && startInterval > 1) {
					startInterval -= 0.25f;
				}
			}
		}
	}

	public void SetPlaying(bool playing) {
		startInterval = 5;
		timer = 2;
		possibleBlocksPerLine = 1;
		minBlocksPerLine = 1;
		line1 = false;
		blockCount = 0;

		this.playing = playing;
	}
}
