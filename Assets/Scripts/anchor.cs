using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchor : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		Debug.Log (col.tag);
		if (col.CompareTag ("fist")) {
			col.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
	}
}
