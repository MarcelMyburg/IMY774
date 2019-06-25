using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour {

    public Rigidbody rb;
    public float forwardF = 500F;
    public float sidewayF = 500F;
    public float mapWidth = 0.2f;
    public Vector3 newPosition;
    public Vector3 newPosition2;

    public float speed = 500f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}


	void FixedUpdate () {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
        newPosition = rb.position + Vector3.right * x;
        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        
        rb.MovePosition(newPosition); 
    }
}
