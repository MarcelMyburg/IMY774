using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowing : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 2;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;

        Vector3 playerPos = new Vector3(target.position.x, target.position.y, target.position.z);

    }

    void FixedUpdate()
    {
        transform.LookAt(target.position);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

}
