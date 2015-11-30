using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

	public Screen titlescreen;
	public GameObject ball;
	public GameObject explosion;
	private Blockspawner blockspawner;
	private Button thisButton;

	private void Start() {
		blockspawner = GameObject.Find ("Blockspawner").GetComponent<Blockspawner>();
		thisButton = GetComponent<Button> ();
	}
	
	public void OnClick() {
		titlescreen.OnDisappear ();
		thisButton.enabled = false;
		
		blockspawner.SetPlaying (true);
		Instantiate (ball, new Vector3(0, 1, 0), Quaternion.identity);
	}

	public void OnDisableTitlescreen() {
		thisButton.enabled = true;
	}
}
