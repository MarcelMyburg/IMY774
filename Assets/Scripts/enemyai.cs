using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class enemyai : MonoBehaviour {
    public Transform target;
    int moveSpeed = 3;
    int rotationSpeed = 3;
    float range=10f;
 float range2=10f;
 float stop=0;
 public Transform myTransform;
    private Interactable interactable;

    private void Awake()
    {
        myTransform = transform;
    }

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        interactable = this.GetComponent<Interactable>();

    }

    private void Update()
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
    private void RumbleController(float duration, float strength)
    {
        StartCoroutine(RumbleControllerRoutine(duration, strength));
    }

    IEnumerator RumbleControllerRoutine(float duration, float strength)
    {
        strength = Mathf.Clamp01(strength);
        float startTime = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup - startTime <= duration)
        {
            int valveStrength = Mathf.RoundToInt(Mathf.Lerp(0, 3999, strength));

            interactable.attachedToHand.TriggerHapticPulse((ushort)valveStrength);

            yield return null;
        }
    }
}
