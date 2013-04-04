using UnityEngine;
using System.Collections;

public class ShootingController : MonoBehaviour {
	public GameObject shotPrefab;
	public Transform dynamicObjects;
	public float shotLifeInSeconds = 0.5f;
	public float shotInitialForce = 1000f;
	
	Collider[] colliders; // cache the colliders used by the ship
	
	void Start() {
		colliders = GetComponentsInChildren<Collider>();
	}
	
	void Update() {
		if(Input.GetButtonDown("Fire1")) {
			var shot = (GameObject)Instantiate(shotPrefab, transform.position, Quaternion.identity);
			foreach(var childCollider in colliders) {
		 		Physics.IgnoreCollision(shot.collider, childCollider);
			}
			shot.transform.parent = dynamicObjects;
			shot.rigidbody.AddForce(transform.forward * shotInitialForce);
			Destroy(shot, shotLifeInSeconds);
		}
	}
}
