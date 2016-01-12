using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	private AudioSource audioSource;

	private void Start() {
		audioSource = GetComponent<AudioSource> ();
	}

	private void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals ("Ball")) {
			audioSource.Play ();
		}
	}
}
