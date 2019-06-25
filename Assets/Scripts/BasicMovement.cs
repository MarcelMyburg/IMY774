using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    Transform target;
    int moveSpeed = 3;
    int rotationSpeed = 3;
    float range = 10f;
    float range2 = 10f;
    float stop = 0;
    Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;

    }

    void Update()
    {
        //rotate to look at the player
        var distance = Vector3.Distance(myTransform.position, target.position);
        if (distance <= range2 && distance >= range)
        {
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
        }


        else if (distance <= range && distance > stop)
        {
            //move towards the player
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        }
        else if (distance <= stop)
        {
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
        }


    }
}