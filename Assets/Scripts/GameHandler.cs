using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	public GameObject player;
	private playerController playerCont;

	// Use this for initialization
	void Start () {
		playerCont = player.GetComponent<playerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//left punch
			playerCont.punch("left");
		}
		if (Input.GetMouseButtonDown (1)) {
			//right punch
			playerCont.punch("right");
		}
		if (Input.GetMouseButtonDown (0) && Input.GetKey(KeyCode.Space)) {
			//left hook
			playerCont.punch("left_hook");
		}
		if (Input.GetMouseButtonDown (1) && Input.GetKey (KeyCode.Space)) {
			//right hook
			playerCont.punch("right_hook");
		}
	}
}
