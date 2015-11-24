using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PaddleController : MonoBehaviour {

	public float paddleSpeed = 0.5f;
	private bool isAndroid;
	private Vector3 playerPos = new Vector3(0, -5.7f, 0);

	private void Start() {
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
				} else {
					temp = 1;
				}
			}
			xPos = transform.position.x + temp * paddleSpeed * Time.deltaTime;
		} else {
			xPos = transform.position.x + Input.GetAxis("Horizontal") * paddleSpeed * Time.deltaTime;
		}
		playerPos = new Vector3 (Mathf.Clamp (xPos, -2.7f, 2.7f), -5.7f, 0);
		transform.position = playerPos;
	}
}
