using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float initialForce = 600;
	public GameObject explosion;

	private Rigidbody2D thisRigidbody;
	private Vector3 originalPos;
	private Score score;
	private Animator animator;

	private void Awake() {
		thisRigidbody = GetComponent<Rigidbody2D> ();
		thisRigidbody.AddForce (new Vector3 (initialForce, initialForce, 0));
		originalPos = transform.position;
	}

	private void Start() {
		score = GameObject.Find ("Main Camera").GetComponent<Score> ();
		score.Reset ();
		
		animator = GetComponent<Animator> ();
	}

	private void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals ("Block")) {
			score.IncreaseScore();
		}

		Vector3 explosionPosition = new Vector3 (transform.position.x, transform.position.y, 1);
		Instantiate (explosion, explosionPosition, Quaternion.identity);
		animator.SetTrigger ("OnBounce");
	}

	public void ResetPosition() {
		thisRigidbody.velocity = Vector2.zero;
		transform.position = originalPos;
		thisRigidbody.AddForce (new Vector3 (initialForce, initialForce, 0));
	}
}
