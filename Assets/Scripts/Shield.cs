using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shield : MonoBehaviour
{
    private GameObject target;

    void Start()
    {
        target = GameObject.FindWithTag("Enemy");
    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Asteroid 1(Clone)"
            || col.gameObject.name == "Asteroid 2(Clone)"
            || col.gameObject.name == "Asteroid 3(Clone)")
        {
            //Destroy(col.gameObject, 0f);
            //Instantiate(col.gameObject, transform.position,  transform.rotation);
            //target.gameObject.GetComponent<EnemyFollowing>().enabled = false;

            target.gameObject.GetComponent<EnemyFollowing>().moveSpeed = 0;
        }
    }


}
