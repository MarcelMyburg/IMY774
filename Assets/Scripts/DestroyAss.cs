using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyAss : MonoBehaviour {
    public Barrel_DL1 barrel;
    public Vector3 newPosition;
    public GameObject target;
    public int counter = 0;
    public float slowDown = 10f;
    public GameObject bottle1, bottle2, bottle3, bottle4, bottle5, bottle6, bottle7, bottle8;
    public GameObject bottle9, bottle10, bottle11, bottle12, bottle13, bottle14, bottle15, cracked;

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
            Destroy(col.gameObject);
            counter++;
            stop();
        }
    }

    void stop()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        switch (counter)
        {
            case 1:
                Instantiate(cracked, transform.position, transform.rotation);
                Destroy(bottle1, 0f);
                break;
            case 2:
                //StartCoroutine(RestartLevel());
                Instantiate(cracked, transform.position, transform.rotation);
                Destroy(bottle2, 0f);
                break;
            case 3:
                Instantiate(cracked, transform.position, transform.rotation);
                Destroy(bottle3, 0f);
                break;
            case 4:
                Instantiate(cracked, transform.position, transform.rotation);
                Destroy(bottle4, 0f);
                break;
            case 5:
                Instantiate(cracked, transform.position, transform.rotation);
                Destroy(bottle5, 0f);
                break;
            case 6:
                Instantiate(cracked, transform.position, transform.rotation);
                Destroy(bottle6, 0f);
                break;
            case 7:
                Instantiate(cracked, transform.position, transform.rotation);
                Destroy(bottle7, 0f);
                break;
            case 8:
                Instantiate(cracked, transform.position, transform.rotation);
                Destroy(bottle8, 0f);
                break;
            case 9:
                Instantiate(cracked, transform.position, transform.rotation);
                Destroy(bottle9, 0f);
                break;
            case 10:
                Instantiate(cracked, transform.position, transform.rotation);
                Destroy(bottle10, 0f);
                break;
            case 11:
                Instantiate(cracked, transform.position, transform.rotation);
                Destroy(bottle11, 0f);
                break;
            case 12:
                Instantiate(cracked, transform.position, transform.rotation);
                Destroy(bottle12, 0f);
                break;
            case 13:
                Instantiate(cracked, transform.position, transform.rotation);
                Destroy(bottle13, 0f);
                break;
            case 14:
                Instantiate(cracked, transform.position, transform.rotation);
                Destroy(bottle14, 0f);
                break;
            case 15:
                Instantiate(cracked, transform.position, transform.rotation);
                Destroy(bottle15, 0f);
                break;
            //default:
            //    StartCoroutine(RestartLevel());
            //    break;
        }

        if (counter == 16)
            transform.position = new Vector3(-0.0058f, 0.7719164f, -3.854f);
        if (counter == 18)
        {
            StartCoroutine(RestartLevel());
        }
    }
        IEnumerator RestartLevel()
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("Base");

        }

}
