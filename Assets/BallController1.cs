using UnityEngine;
using System.Collections;

public class BallController1 : MonoBehaviour {
	
	public float force = 9.8f;
	
	void FixedUpdate () {
		Vector3 dir = new Vector3(Input.acceleration.x, Input.acceleration.y, 0.0F);
		Physics.gravity = dir * force;
	}
}
