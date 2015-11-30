using UnityEngine;
using System.Collections;

public class Screen : MonoBehaviour {

	public Animator[] startAnimators;
	public Animator[] transitionAnimators;

	public void OnStart() {
		for (int i = 0; i < startAnimators.Length; i++) {
			startAnimators[i].SetTrigger("OnStart");
		}
		for (int i = 0; i < transitionAnimators.Length; i++) {
			transitionAnimators[i].SetTrigger("OnStart");
		}
	}

	public void OnDisappear() {
		for (int i = 0; i < startAnimators.Length; i++) {
			startAnimators[i].SetTrigger("OnDisappear");
		}
		for (int i = 0; i < transitionAnimators.Length; i++) {
			transitionAnimators[i].SetTrigger("OnTransition");
		}
	}
}
