using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public float fallingSpeed = 1f;
	public SpriteRenderer blockShadow;

	private Animator animator;
	private Collider2D thisCollider;
	private SpriteRenderer block;
	private Vector3 blockPos;
	private Color tempColor, tempColor2;

	private void Start() {
		animator = GetComponent<Animator> ();
		block = GetComponent<SpriteRenderer> ();
		thisCollider = GetComponent<BoxCollider2D> ();
		tempColor = new Color (0.472f, 0.25f, 0, 1);
		tempColor2 = new Color (0.742f, 0.683f, 0.41f, 1);
	}

	private void Update() {
		float yPos = transform.position.y - fallingSpeed * Time.deltaTime;
		blockPos = new Vector3 (transform.position.x, yPos, 0);
		transform.position = blockPos;

		if (transform.position.y <= -4) {
			tempColor.a -= 2 * Time.deltaTime;
			tempColor2.a -= 2 * Time.deltaTime;

			block.color = tempColor;
			blockShadow.color = tempColor2;
			if (tempColor.a <= 0 || tempColor2.a <= 0) {
				Destroy (gameObject);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals ("Ball")) {
			OnDissolve();
		}
	}

	public void OnDissolve() {
		thisCollider.enabled = false;
		animator.SetTrigger ("OnDissolve");
	}
}
