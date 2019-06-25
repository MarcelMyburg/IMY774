using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour {

    public playermove movement;
    
    // Update is called once per frame
	void OnCollisionEnter (Collision collisionInfo) {
        if(collisionInfo.collider.tag == "Obsticle")
        {
            movement.enabled = false;
        }
		
	}
}
