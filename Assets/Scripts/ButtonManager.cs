using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {

	public GameObject ball;
	public GameObject explosion;
	public Blockspawner blockspawner;

	[Header("Start Button")]
	public Animator[] startAnimators;
	public Animator scoreAnimator;

	public void OnStart() {
		for (int i = 0; i < startAnimators.Length; i++) {
			startAnimators[i].SetTrigger("OnDisappear");
		}
		scoreAnimator.SetTrigger ("OnTransition");

		blockspawner.SetPlaying (true);
		ball.SetActive (true);
	}
}
