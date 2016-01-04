using UnityEngine;
using System.Collections;

public class Blockspawner : MonoBehaviour {
	
	public GameObject block;
	private float interval = 5;
	private float timer = 2;
	private int lineCount;
	private bool playing;

	public Vector2[] spawnLocations;
	private int maxAllowedBlocks = 1;
	private int listIndexPointer = 0;

	private void Update() {
		if (playing) {
			timer += Time.deltaTime;
			
			if (timer >= interval) {
				SpawnBlocks();
				timer = 0;
				interval = Random.Range (3, 5);

				if (lineCount <= 2) {
					maxAllowedBlocks = 1;
				} else if (lineCount > 2 && lineCount <= 4) {
					maxAllowedBlocks = 3;
				} else if (lineCount > 4 && lineCount <= 19) {
					maxAllowedBlocks = 5;
				} else if (lineCount > 19 && lineCount % 5 == 0 && maxAllowedBlocks < 20) {
					maxAllowedBlocks += 1;
				}
			}
		}
	}

	private void SpawnBlocks() {
		int amountOfBlocks = Random.Range (1, maxAllowedBlocks);
		int[] placedBlocks = new int[30];

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
				placedBlocks[listIndexPointer] = randomLocation;
				listIndexPointer++;
				amountOfBlocks--;
			}
		}
		lineCount++;
		listIndexPointer = 0;
	}

	public void SetPlaying(bool playing) {
		interval = 5;
		timer = 2;
		lineCount = 0;
		maxAllowedBlocks = 1;

		this.playing = playing;
	}
}
