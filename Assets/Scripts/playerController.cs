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

		Vector3 movement = new Vector3 (moveHorizontal, -1.0f, moveVertical);
		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3 (
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
			-1.0f,
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
		);

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 100f, (1 << 8))) {
			transform.LookAt (new Vector3 (hit.point.x, transform.position.y, hit.point.z));
		}

		main.transform.position = new Vector3 (transform.position.x, transform.position.y + 11, transform.position.z - 9);
	}
		
	public void punch(string identifier) {
		
		if (identifier.Equals ("left")) {
			anim.Play ("punch_r", 1, 0f);

		} else if (identifier.Equals ("right")) {
			anim.Play ("punch_l", 0, 0f);
		} else if (identifier.Equals ("left_hook")) {
			anim.Play ("punch_r_hook", 1, 0f);
		} else if (identifier.Equals ("right_hook")) {
			anim.Play ("punch_l_hook", 0, 0f);
		}
	}

}
