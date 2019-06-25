using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMe : MonoBehaviour {

    public Transform target;
    public float moveSpeed = 2;
    // Use this for initialization
    void Start () {
        //transform.LookAt(target.position);
    }

    private void Update()
    {
        StartCoroutine(FadeAway());
    }

    IEnumerator FadeAway()
    {
        yield return new WaitForSeconds(10f);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        Destroy(gameObject, 11f);
    }
}
