using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSound : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        AudioSource audio = GetComponent<AudioSource>();
        if (GetComponent<MeshRenderer>().enabled == false)
        {       
            audio.Play();
        }
    }
}
