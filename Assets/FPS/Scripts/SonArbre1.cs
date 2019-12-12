using System;
using UnityEngine;
using System.Collections;
 

public class SonArbre1 : MonoBehaviour
{
    private MelodyChecker melodyChecker;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        melodyChecker = FindObjectOfType<MelodyChecker>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            PlaySound();
            Destroy(other.gameObject);
        }
    }
    [ContextMenu("TryPlaySound")]
    void PlaySound()
    {
        source.Play();
        melodyChecker.TryPlaySound(this);
    }
}