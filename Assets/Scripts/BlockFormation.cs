using UnityEngine;
using System.Collections;

public class BlockFormation : MonoBehaviour {

	public float fallingSpeed = 1f;
	private Vector3 formationPos;

	private void Update() {
		float yPos = transform.position.y - fallingSpeed * Time.deltaTime;
		formationPos = new Vector3 (transform.position.x, yPos, 0);
		transform.position = formationPos;
	}
}
