using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public float turnRate = 100f;
	public float thrustRate = 100f;
	
	void FixedUpdate() {
		var turnInput = Input.GetAxis("Horizontal");
		transform.Rotate(0f, turnInput * Time.fixedDeltaTime * turnRate, 0f);
		
		var thrust = Input.GetAxis("Vertical");
		rigidbody.AddForce(transform.forward * thrust * thrustRate * Time.fixedDeltaTime);
	}
}
