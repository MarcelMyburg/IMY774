using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class LeapTest : MonoBehaviour {
    Controller controller;
    float HandPalmPitch;
    float HandPalmYam;
    float HandPalmRoll;
    float HandPalmRot;
    float HandPalmPitch1;
    float HandPalmYam1;
    float HandPalmRoll1;
    float HandPalmRot1;
    public GameObject shieldLeft;
    public GameObject spearRight;
    public GameObject blackhole1;
    public GameObject blackhole2;
    public GameObject target;
    public Rigidbody blockPrfab;
    public Transform[] SpawnPoints;
    public Rigidbody fingerDirection;
    float timeOut = 0;
    private bool spawned;

    void Start () {
        controller = new Controller();
        spawned = false;
    }

    void Update () {
        Frame frame = controller.Frame();
        List<Hand> hands = frame.Hands;
        if(frame.Hands.Count == 1)
        {
            Hand firstHand = hands[0];
            HandPalmYam = firstHand.PalmNormal.Yaw;   

            if (HandPalmYam < 0f && HandPalmYam > -1.75f )
            {
                shieldLeft.GetComponent<Renderer>().enabled = true;
                shieldLeft.GetComponent<MeshCollider>().enabled = true;
            }
            else
            {
                shieldLeft.GetComponent<Renderer>().enabled = false;
                shieldLeft.GetComponent<MeshCollider>().enabled = false;
                if (spawned == false)
                {
                    Rigidbody magic;
                    Vector3 targetPostition = new Vector3(fingerDirection.position.x,
                                        fingerDirection.position.y,
                                        fingerDirection.position.z);
                    SpawnPoints[0].LookAt(targetPostition);
                    AudioSource audio = GetComponent<AudioSource>();

                    audio.Play();
                    magic = Instantiate(blockPrfab, SpawnPoints[0].position, fingerDirection.rotation) as Rigidbody;
                    magic.AddForce(SpawnPoints[0].forward * 700);
                    spawned = true;
                    StartCoroutine(Nextmagic());
                }
            }

            if (HandPalmYam > 1.3f || HandPalmYam > -3f)
            {
                spearRight.GetComponent<Renderer>().enabled = true;
                spearRight.GetComponent<CapsuleCollider>().enabled = true;
            }
            else
            {
                spearRight.GetComponent<Renderer>().enabled = false;
                spearRight.GetComponent<CapsuleCollider>().enabled = false;
            }
        }
        else if(frame.Hands.Count == 2)
        {
            Hand firstHand = hands[0];
            Hand secondhand = hands[1];
            HandPalmYam = firstHand.PalmNormal.Yaw;
            HandPalmYam1 = secondhand.PalmNormal.Yaw;

            if (HandPalmYam < 0f && HandPalmYam > -1.75f || HandPalmYam1 < 0f && HandPalmYam1 > -1.75f)
            {
                shieldLeft.GetComponent<Renderer>().enabled = true;
                shieldLeft.GetComponent<MeshCollider>().enabled = true;
            }
            else
            {
                shieldLeft.GetComponent<Renderer>().enabled = false;
                shieldLeft.GetComponent<MeshCollider>().enabled = false;
                if (spawned == false)
                {
                    Rigidbody magic;
                    Vector3 targetPostition = new Vector3(fingerDirection.position.x,
                                        fingerDirection.position.y,
                                        fingerDirection.position.z);
                    SpawnPoints[0].LookAt(targetPostition);
                    AudioSource audio = GetComponent<AudioSource>();

                    audio.Play();
                    magic = Instantiate(blockPrfab, SpawnPoints[0].position, fingerDirection.rotation) as Rigidbody;
                    magic.AddForce(SpawnPoints[0].forward * 700);
                    spawned = true;
                    StartCoroutine(Nextmagic());
                }
            }

            if (firstHand.Direction.Yaw > 1.4f || firstHand.Direction.Yaw < 1.6f
                && secondhand.Direction.Yaw > 1.4f || secondhand.Direction.Yaw < 1.6f)
            {
                    
                if (timeOut == 0)
                {
                    timeOut = 1;
                    target.transform.position = new Vector3(0f, -1.627f, 19.416f);
                    blackhole1.GetComponent<MeshRenderer>().enabled = true;
                    blackhole2.GetComponent<MeshRenderer>().enabled = true;
                    StartCoroutine(Desumon());
                }
            }
        }
    }

    IEnumerator Desumon()
    {
        yield return new WaitForSeconds(8f);
        //Debug.Log("T2 " + timeOut);
        blackhole1.GetComponent<MeshRenderer>().enabled = false;
        blackhole2.GetComponent<MeshRenderer>().enabled = false;
        target.transform.position = new Vector3(-0.0058f, 1.216f, -2.995f);
        yield return new WaitForSeconds(20f);
        timeOut = 0;
    }

    IEnumerator Nextmagic()
    {
        yield return new WaitForSeconds(2f);
        if(blockPrfab.gameObject.name == "ErekiBall2(Clone)")
        Destroy(blockPrfab);
        spawned = false;
    }
}
