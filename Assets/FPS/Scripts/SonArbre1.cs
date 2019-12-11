using System;
using UnityEngine;
using System.Collections;
 

public class SonArbre1 : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            GetComponent<AudioSource> ().Play ();
            Destroy(other.gameObject);
        }
    }
}