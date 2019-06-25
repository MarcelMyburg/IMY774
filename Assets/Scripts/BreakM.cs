using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakM : MonoBehaviour {
    public Vector3 newPosition;
    public int totalCounter = 0;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Asteroid 1(Clone)" 
            || col.gameObject.name == "Asteroid 2(Clone)" 
            || col.gameObject.name == "Asteroid 3(Clone)")
        {
            Destroy(col.gameObject);
            totalCounter++;
        }
    }
    
}
