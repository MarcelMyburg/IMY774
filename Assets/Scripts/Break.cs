using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour {

    public GameObject part1;
    
    // Use this for initialization
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Asteroid 1(Clone)"
            || col.gameObject.name == "Asteroid 2(Clone)"
            || col.gameObject.name == "Asteroid 3(Clone)")
        {
            AudioSource audio = GetComponent<AudioSource>();

            audio.Play();
            Instantiate(part1, transform.position, transform.rotation);
            Destroy(gameObject, 0.3f);
        }
    }
}
