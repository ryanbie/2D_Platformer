using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // target is initialized to the GameObject Player
    public GameObject target;

    // Amount that we want the camera to follow ahead of the Player
    public float followahead;

    private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Object is attached to Main Camera -> Player
        targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        // x value: Will move the camera to follow the Player on the x-axis
        // y value: Will keep the camera at the same height by taking the MainCamera's current y-position 
        // z value: Will take the MainCamera's current z-position

        if (target.transform.localScale.x > 0f) // Player is facing right
        {
            else if (target.transform.localScale.x < 0f) // Player is facing left 
        }
	}
}
