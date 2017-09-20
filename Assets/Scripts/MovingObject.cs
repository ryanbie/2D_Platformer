using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    public GameObject objectToMove;

    public Transform startPoint;
    public Transform endPoint;

    public float moveSpeed; // How fast the platform will move

    private Vector3 currentTarget; // Where the platform should end/meet (Target) 

	// Use this for initialization
	void Start () {
        currentTarget = endPoint.position; // The Target (for the platform) will be the endPoint's position
	}
	
	// Update is called once per frame
	void Update () {
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime); // The platform should move from its current position to the currentTarget position at a certain movement speed and FPS. 

        /* If the platform's position is equal to the endPoint's position, 
         * the currentTarget will shift back to the starting position. 
         * Thus, the platform should end/meet at the startPoint position.
         */ 
       
        if(objectToMove.transform.position == endPoint.position)
        {
            currentTarget = startPoint.position; 
        }

	   /* However, if the platform's position is equal to the startPoint's position, 
		* the currentTarget will shift back to the ending position. 
		* Thus, the platform should end/meet at the endPoint position.
		*/

		if(objectToMove.transform.position == startPoint.position)
        {
            currentTarget = endPoint.position;
        }
    }
}
