using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 cPosition;
	
	// Update is called once per frame
	void Update () {
        transform.position = player.position + cPosition;
	}
}
