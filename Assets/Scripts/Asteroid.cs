using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	public float maxInitialForce = 1000f;
	
	void Start() {
		var x = Random.Range(-maxInitialForce, maxInitialForce);
		var z = Random.Range(-maxInitialForce, maxInitialForce);
		rigidbody.AddForce(x, 0f, z);
	}
	
	void OnCollisionEnter(Collision collisionInfo) {
		if(collisionInfo.collider.CompareTag("shot")) {
			Destroy(gameObject);
			var scoreGuiText = GameObject.Find("Score").guiText;
			var score = int.Parse(scoreGuiText.text);
			scoreGuiText.text = (++score).ToString();
		}
	}
}
