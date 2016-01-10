using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float initialForce = 600;
	public GameObject explosion;
	private ObjectPool objectPool;

	private Rigidbody2D thisRigidbody;
	private Score score;
	private Animator animator;

	private void Awake() {
		thisRigidbody = GetComponent<Rigidbody2D> ();
		int random = Random.Range (0, 2);
		int offset = 0;
		if (random == 0) {
			offset = 1;
		} else {
			offset = -1;
		}
		thisRigidbody.AddForce (new Vector3 (initialForce * offset, initialForce, 0));
	}

	private void Start() {
		score = GameObject.Find ("Main Camera").GetComponent<Score> ();
		animator = GetComponent<Animator> ();
		objectPool = GameObject.Find ("Explosionpool").GetComponent<ObjectPool> ();
	}

	private void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals ("Block")) {
			score.IncreaseScore();
		}

		Vector3 explosionPosition = new Vector3 (transform.position.x, transform.position.y, 1);
		GameObject obj = objectPool.GetPooledObject ();
		if (obj != null) {
			obj.transform.position = explosionPosition;
			obj.transform.rotation = Quaternion.identity;
			obj.SetActive (true);
		}

		animator.SetTrigger ("OnBounce");
	}
}
