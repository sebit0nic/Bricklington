using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PaddleController : MonoBehaviour {

	public float paddleSpeed = 0.5f;
	public GameObject instructionArrow1, instructionArrow2;
	private bool isAndroid;
	private Vector3 playerPos = new Vector3(0, -5.7f, 0);
	private AudioSource audioSource;
	private Audiocontroller audioController;

	private void Start() {
		audioSource = GetComponent<AudioSource> ();
		audioController = GameObject.Find ("Audiocontroller").GetComponent<Audiocontroller> ();
		if (Application.platform == RuntimePlatform.Android) {
			isAndroid = true;
		}
	}

	private void Update() {
		float xPos;
		if (isAndroid) {
			float temp = 0;
			Vector3 touchPos = new Vector3();
			if (Input.touchCount > 0) {
				touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				if (touchPos.x <= 0) {
					temp = -1;
					if (instructionArrow1 != null) {
						Destroy (instructionArrow1);
					}
				} else {
					temp = 1;
					if (instructionArrow2 != null) {
						Destroy (instructionArrow2);
					}
				}
			}
			xPos = transform.position.x + temp * paddleSpeed * Time.deltaTime;
		} else {
			if (Input.GetAxis("Horizontal") < 0 && instructionArrow1 != null) {
				Destroy (instructionArrow1);
			} else if (Input.GetAxis("Horizontal") > 0 && instructionArrow2 != null) {
				Destroy (instructionArrow2);
			}
			xPos = transform.position.x + Input.GetAxis("Horizontal") * paddleSpeed * Time.deltaTime;
		}
		playerPos = new Vector3 (Mathf.Clamp (xPos, -2.7f, 2.7f), -5.7f, 0);
		transform.position = playerPos;
	}

	private void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals ("Ball")) {
			audioSource.Play ();
			audioController.SetPitch(1);
		}
	}
}
