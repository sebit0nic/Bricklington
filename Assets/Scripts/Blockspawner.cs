using UnityEngine;
using System.Collections;

public class Blockspawner : MonoBehaviour {
	
	public GameObject block;
	public float startInterval = 5;
	private float timer = 2;
	private int lineCount;
	private bool playing;

	public Vector2[] spawnLocations;
	private int maxAllowedBlocks = 1;
	private int[] placedBlocks = new int[30];

	private void Update() {
		if (playing) {
			timer += Time.deltaTime;
			
			if (timer >= startInterval) {
				SpawnBlocks();
				timer = 0;

				if (lineCount <= 2) {
					maxAllowedBlocks = 1;
				} else if (lineCount > 2 && lineCount <= 4) {
					maxAllowedBlocks = 3;
				} else if (lineCount > 4 && lineCount <= 19) {
					maxAllowedBlocks = 6;
				} else if (lineCount > 19 && lineCount % 5 == 0 && maxAllowedBlocks < 30) {
					maxAllowedBlocks += 2;
				}
			}
		}
	}

	private void SpawnBlocks() {
		int amountOfBlocks = Random.Range (1, maxAllowedBlocks);
		placedBlocks = new int[30];

		while (amountOfBlocks > 0) {
			bool canBePlaced = true;
			int randomLocation = Random.Range (0, 30);

			for (int i = 0; i < placedBlocks.Length; i++) {
				if (placedBlocks[i] == randomLocation) {
					canBePlaced = false;
					break;
				}
			}

			if (canBePlaced) {
				Instantiate(block, spawnLocations[randomLocation], Quaternion.identity);
				placedBlocks[placedBlocks.Length-1] = randomLocation;
				amountOfBlocks--;
			}
		}
		lineCount++;
	}

	public void SetPlaying(bool playing) {
		startInterval = 5;
		timer = 2;
		lineCount = 0;
		maxAllowedBlocks = 1;

		this.playing = playing;
	}
}
