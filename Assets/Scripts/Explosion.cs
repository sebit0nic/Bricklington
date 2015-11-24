using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	private Vector3 scaling;
	private Color coloring;

	private void Start() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		scaling = new Vector3 (0.2f, 0.2f, 1);
		coloring = new Color (0.742f, 0.683f, 0.41f, 0.5f);
	}

	private void Update() {
		scaling.x += Time.deltaTime * 5;
		scaling.y += Time.deltaTime * 5;
		transform.localScale = scaling;

		coloring.a -= Time.deltaTime;
		spriteRenderer.color = coloring;

		if (coloring.a <= 0) {
			Destroy(gameObject);
		}
	}
}
