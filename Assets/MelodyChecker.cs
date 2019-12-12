using System.Collections;
using System.Collections.Generic;
using Unity.Connect.Share.Editor.store;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MelodyChecker : MonoBehaviour
{
    private AudioSource source;
    public List<SonArbre1> listeAFaire;
    public int index = 0;
    public GameObject uiFinish;
    public bool alreadyWin;

    public PostProcessVolume volume1;
    public PostProcessVolume volume2;
    
    public float fonduDuration;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        alreadyWin = false;
    }

    public void TryPlaySound(SonArbre1 arbreToTry)
    {
        if (alreadyWin == false)
        {
            //Win();
            if (listeAFaire[index] == arbreToTry)
            {
                index += 1;
                if (index >= listeAFaire.Count)
                {
                    index = 0;

                    Win();
                }
            }
        
            else
            {
                index = 0;
            }
     }
    }

    //Quand on gagne
    private void Win()
    {
        alreadyWin = true;
        source.Play();
        StartCoroutine((CoroutineWin()));
        
    }

    //Cinématique
    IEnumerator CoroutineWin()
    {
        float timer = fonduDuration;
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            
            float lerp = Mathf.Lerp(1f, 0f, Mathf.InverseLerp(fonduDuration, 0f, timer));
            volume1.weight = lerp;
            volume2.weight = 1-lerp;
            source.volume = 1-lerp;
            
            yield return new WaitForEndOfFrame();

        }
        uiFinish.SetActive(true);
        Invoke("CloseUIFinish", 5f);
        yield return null;
    }
    
    //Quand l'écran de victoire disparaît
    private void CloseUIFinish()
    {
        uiFinish.SetActive(false);
        source.Stop();
    }

}
