using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class playerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;
	private Rigidbody rigidbody;
	public Camera main;

	public GameObject leftAnchor;
	public GameObject left;
	private Rigidbody leftRB;
	public GameObject rightAnchor;
	public GameObject right;
	private Rigidbody rightRB;
	private Vector3 dest;
	private Animator anim;
	public bool leftBool;
	public bool rightBool;

	void Start() {
		rigidbody = GetComponent<Rigidbody> ();
		leftRB = left.GetComponent<Rigidbody> ();
		rightRB = right.GetComponent<Rigidbody> ();
		rigidbody.position = new Vector3 (rigidbody.position.x, 0.0f, rigidbody.position.z);
		leftRB.position = new Vector3 (leftRB.position.x, 0.0f, leftRB.position.z);
		rightRB.position = new Vector3 (rightRB.position.x, 0.0f, rightRB.position.z);
		anim = gameObject.GetComponent<Animator> ();
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3 (
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
		);

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 100f, (1 << 8))) {
			dest = new Vector3 (hit.point.x, transform.position.y, hit.point.z);
			transform.LookAt (dest);
		}
			
		main.transform.position = new Vector3 (transform.position.x, transform.position.y + 11 * transform.localScale.y, transform.position.z - 9 * transform.localScale.z);
	}
		
	public void punch(string identifier) {
		//yes, I mixed up the files when I made them.
		if (identifier.Equals ("left")) {
			leftRB.AddForce (new Vector3 (transform.forward.x, 0.0f, transform.forward.z) * transform.localScale.x * 5000);

		} else if (identifier.Equals ("right")) {
			rightRB.AddForce (new Vector3 (transform.forward.x, 0.0f, transform.forward.z) *transform.localScale.x* 5000);
		} else if (identifier.Equals ("left_hook")) {
			anim.Play ("punch_r_hook", 1, 0f);
		} else if (identifier.Equals ("right_hook")) {
			anim.Play ("punch_l_hook", 0, 0f);
		}
	}

	//this handles the parent object collision. We need the fist collisions.
	/*void OnCollisionEnter(Collision col) {
		if (col.gameObject.CompareTag ("enemy")) {
			Vector3 tempEnemy = col.gameObject.transform.localScale;
			col.gameObject.transform.localScale = new Vector3 (tempEnemy.x - 0.1f, tempEnemy.y - 0.1f, tempEnemy.z - 0.1f);
			Vector3 tempPlayer = gameObject.transform.localScale;
			gameObject.transform.localScale = new Vector3 (tempPlayer.x + 0.1f, tempPlayer.y + 0.1f, tempPlayer.z + 0.1f);
		}
	}*/
}
