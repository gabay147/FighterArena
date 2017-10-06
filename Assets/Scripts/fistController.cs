using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fistController : MonoBehaviour {

	public GameObject body;
	public GameObject left;
	public GameObject right;
	public GameObject leftAnchor;
	public GameObject rightAnchor;

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.CompareTag ("enemy")) {
			Vector3 tempEnemy = col.gameObject.transform.localScale;
			col.gameObject.transform.localScale = new Vector3 (tempEnemy.x - 0.1f, tempEnemy.y - 0.1f, tempEnemy.z - 0.1f);
			Vector3 tempPlayer = body.transform.localScale;
			body.transform.localScale = new Vector3 (tempPlayer.x + 0.1f, tempPlayer.y + 0.1f, tempPlayer.z + 0.1f);
			left.transform.localScale = new Vector3 (left.transform.localScale.x + 0.1f, left.transform.localScale.y + 0.1f, left.transform.localScale.z + 0.1f);
			right.transform.localScale = new Vector3 (right.transform.localScale.x + 0.1f, right.transform.localScale.y + 0.1f, right.transform.localScale.z + 0.1f);
			leftAnchor.transform.localScale = new Vector3 (leftAnchor.transform.localScale.x + 0.1f, leftAnchor.transform.localScale.y + 0.1f, leftAnchor.transform.localScale.z + 0.1f);
			rightAnchor.transform.localScale = new Vector3 (rightAnchor.transform.localScale.x + 0.1f, rightAnchor.transform.localScale.y + 0.1f, rightAnchor.transform.localScale.z + 0.1f);
		}
	}
}
