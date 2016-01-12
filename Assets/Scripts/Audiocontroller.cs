using UnityEngine;
using System.Collections;

public class Audiocontroller : MonoBehaviour {

	public float pitch = 1;

	public float GetPitch() {
		return pitch;
	}

	public void IncreasePitch(float amount) {
		pitch += amount;
	}

	public void SetPitch(float pitch) {
		this.pitch = pitch;
	}
}
